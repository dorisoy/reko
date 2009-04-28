using Decompiler.Core.Absyn;
using Decompiler.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Structure
{
    public abstract class StructuredGraph
    {
        public static StructuredGraph Seq = new SeqStructType(); // sequential statement (default)
        public static StructuredGraph Loop = new LoopStructType();					// Header of a loop only
        public static StructuredGraph Cond = new CondStructType();					// Header of a conditional only (if-then-else or switch)
        public static StructuredGraph LoopCond = new LoopCondStructType();			    // Header of a loop and a conditional

        public abstract void WriteCode(AbsynCodeGenerator gen, StructureNode node, StructureNode latch, List<StructureNode> followSet, List<StructureNode> gotoSet, List<AbsynStatement> HLLCode);
    }

    public class SeqStructType : StructuredGraph
    {
        public override void WriteCode(AbsynCodeGenerator gen, StructureNode node, StructureNode latch, List<StructureNode> followSet, List<StructureNode> gotoSet, List<AbsynStatement> HLLCode)
        {
            gen.WriteSequentialCode(node, latch, followSet, gotoSet, HLLCode);
        }
    }

    public class LoopStructType : StructuredGraph
    {
        public override void WriteCode(AbsynCodeGenerator gen, StructureNode node, StructureNode latch, List<StructureNode> followSet, List<StructureNode> gotoSet, List<AbsynStatement> HLLCode)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class CondStructType : StructuredGraph
    {
        public override void WriteCode(AbsynCodeGenerator gen, StructureNode node, StructureNode latch, List<StructureNode> followSet, List<StructureNode> gotoSet, List<AbsynStatement> HLLCode)
        {
            gen.WriteCondCode(node, latch, followSet, gotoSet, HLLCode);
        }
    }
    public class LoopCondStructType : StructuredGraph
    {
        public override void WriteCode(AbsynCodeGenerator gen, StructureNode node, StructureNode latch, List<StructureNode> followSet, List<StructureNode> gotoSet, List<AbsynStatement> HLLCode)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}