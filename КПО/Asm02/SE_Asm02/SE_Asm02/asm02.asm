.586P													;система команд(процессор Pentium)
.MODEL FLAT, STDCALL									;модель памяти, соглашение о вызовах
includelib kernel32.lib									;компоновщику: компоновать с kernel132
includelib user32.lib

ExitProcess PROTO : DWORD								;прототип функции для завершения процесса
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD	;прототип API-функции MessageBoxA 

.STACK 4096								;выделение стека

.CONST									;сегмент констант

.DATA									;сегмент данных

MB_OK	EQU		0
a	DB			2
b	DB			4
STR1	DB		"СУММА", 0	
RESULT	DB	"Результат сложения = < >", 0
HW			DD ?

.CODE									;сегмент кода

main PROC 								;точка входа main
START:

	mov al, a
	add al, b
	add eax, 30h
	mov str1+28, al
	INVOKE MessageBoxA, HW, OFFSET RESULT, OFFSET STR1, MB_OK

	push -1								;код возврата (-1) процесса Windows(параметр ExitProcess)
	call ExitProcess					;завершение процесса Windows
main ENDP								;конец процедуры

end main