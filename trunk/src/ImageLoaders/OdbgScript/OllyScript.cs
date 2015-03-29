﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Decompiler.ImageLoaders.OdbgScript
{
    /// <summary>
    /// Represents loaded Odbg script state
    /// </summary>
    public class OllyScript
    {
        public class Line
        {
            public uint linenum;
            public string line;
            public bool is_command;
            public string command;
            public Func<string[], bool> commandptr;
            public string[] args = new string[0];
        }

        public bool log;
        public string path;
        public List<Line> lines;
        public Dictionary<string, uint> labels;
        private Host Host;

        public OllyScript(Host host)
        {
            this.Host = host;
            this.IsLoaded = false;
            this.log = false;
            this.lines = new List<Line>();
            this.labels = new Dictionary<string, uint>();
        }

        public bool IsLoaded { get; private set; }

        public void Clear()
        {
            IsLoaded = false;
            path = "";
            lines.Clear();
            labels.Clear();
        }

        void parse_insert(List<string> toInsert, string currentdir)
        {
            uint curline = 1;
            bool in_comment = false, in_asm = false;

            IsLoaded = true;

            for (int i = 0; i < toInsert.Count; i++, curline++)
            {
                string scriptline = Helper.trim(toInsert[i]);
                bool nextline = false;
                int curpos = 0; // for skipping string literals

                while (!nextline)
                {
                    // Handle comments and string literals
                    int linecmt = -1, spancmt = -1, strdel = -1;

                    if (curpos < scriptline.Length)
                        if (in_comment)
                        {
                            spancmt = 0;
                        }
                        else
                        {
                            int min = -1, tmp;
                            tmp = scriptline.IndexOf("//", curpos);
                            if (tmp < min)
                                min = linecmt = tmp;
                            tmp = scriptline.IndexOf(';', curpos);
                            if (tmp < min)
                                min = linecmt = tmp;
                            tmp = scriptline.IndexOf("/*", curpos);
                            if (tmp < min)
                                min = spancmt = tmp;
                            tmp = scriptline.IndexOf('\"', curpos);
                            if (tmp < min)
                                min = strdel = tmp;

                            curpos = min;

                            if (linecmt != min)
                                linecmt = -1;
                            if (spancmt != min)
                                spancmt = -1;
                            if (strdel != min)
                                strdel = -1;
                        }

                    if (strdel >= 0)
                    {
                        curpos = scriptline.IndexOf('\"', strdel + 1); // find end of string
                        if (curpos >= 0)
                            curpos++;
                    }
                    else if (linecmt >= 0)
                    {
                        scriptline = scriptline.Remove(linecmt);
                    }
                    else if (spancmt >= 0)
                    {
                        int start = in_comment ? spancmt : spancmt + 2;
                        int end = scriptline.IndexOf("*/", start);
                        in_comment = (end < 0);
                        if (in_comment)
                            scriptline = scriptline.Remove(spancmt);
                        else
                            scriptline = scriptline.Remove(spancmt) + scriptline.Substring(end - spancmt + 2);
                    }
                    else
                    {
                        scriptline = Helper.trim(scriptline);
                        int len = scriptline.Length;

                        if (len != 0)
                        {
                            string lcline = scriptline.ToLowerInvariant();

                            // Check for label
                            if (!in_asm && len > 1 && scriptline[len - 1] == ':')
                            {
                                scriptline = scriptline.Remove(len - 1);
                                labels[Helper.trim(scriptline)] = (uint)(lines.Count);
                            }
                            // Check for #inc and include file if it exists
                            else if (0 == lcline.IndexOf("#inc"))
                            {
                                if (len > 5 && Char.IsWhiteSpace(lcline[4]))
                                {
                                    string args = Helper.trim(scriptline.Substring(5));
                                    if (args.Length > 2 && args[0] == '\"' && args.EndsWith("\""))
                                    {
                                        string dir;
                                        string philename = Helper.pathfixup(args.Substring(1, args.Length - 2), false);
                                        if (!Helper.isfullpath(philename))
                                        {
                                            philename = currentdir + philename;
                                            dir = currentdir;
                                        }
                                        else
                                            dir = Helper.folderfrompath(philename);

                                        parse_insert(Helper.ReadLinesFromFile(philename), dir);
                                    }
                                    else Host.MsgError("Bad #inc directive!");
                                }
                                else this.Host.MsgError("Bad #inc directive!");
                            }
                            // Logging
                            else if (!in_asm && lcline == "#log")
                            {
                                log = true;
                            }
                            // Add line
                            else
                            {
                                Line cur = new Line();

                                if (in_asm && lcline == "ende")
                                    in_asm = false;

                                cur.line = scriptline;
                                cur.linenum = curline;
                                cur.is_command = !in_asm;

                                if (!in_asm && lcline == "exec")
                                    in_asm = true;

                                ParseArgumentsIntoLine(scriptline, cur);

                                lines.Add(cur);
                            }
                        }
                        nextline = true;
                    }
                }
            }
        }

        public static void ParseArgumentsIntoLine(string scriptline, Line cur)
        {
            int pos = scriptline.IndexOfAny(Helper.whitespaces.ToCharArray());
            if (pos >= 0)
            {
                cur.command = scriptline.Substring(0, pos).ToLowerInvariant();
                cur.args = Helper.split(',', scriptline.Substring(pos + 1))
                    .Select(s => s.Trim())
                    .ToArray();
            }
            else
            {
                cur.command = scriptline.ToLowerInvariant();
            }
        }

        public int next_command(int from)
        {
            while (from < lines.Count && !lines[from].is_command)
            {
                from++;
            }
            return from;
        }

        public bool load_file(string file, string dir = null)
        {
            Clear();

            string cdir = Environment.CurrentDirectory;
            string curdir = Helper.pathfixup(cdir, true);
            string sdir;

            path = Helper.pathfixup(file, false);
            if (!Helper.isfullpath(path))
            {
                path = curdir + path;
            }
            if (string.IsNullOrEmpty(dir))
                sdir = Helper.folderfrompath(path);
            else
                sdir = dir;

            List<string> unparsedScript = Helper.ReadLinesFromFile(path);
            parse_insert(unparsedScript, sdir);

            //TSErrorExit = false;
            return true;
        }

        public bool load_buff(string buff, string dir = null)
        {
            Clear();

            string curdir = Helper.pathfixup(Environment.CurrentDirectory, true);
            string sdir;

            path = "";
            if (dir == null)
            {
                sdir = curdir;
            }
            else
                sdir = dir;

            List<string> unparsedScript = Helper.ReadLines(new StringReader(buff));
            parse_insert(unparsedScript, sdir);

            //$LATER TSErrorExit = false;
            return true;
        }

        public bool is_label(string s)
        {
            return (labels.ContainsKey(s));
        }
    }
}
