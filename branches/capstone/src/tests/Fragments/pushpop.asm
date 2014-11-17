	.i86
;; pushpop.asm
	
main proc
	mov cx,0x14
	call foo
	mov [si],ax
	;; fall thru.
	endp
	
foo proc
	push	si
	push	di

	mov		si,0
again:
	cmp		cx,0
	jz		done
	add		si,[di]
	add		di,2
	jmp		again
done:
	mov		ax,si
	pop		di
	pop		si
	ret
foo endp
