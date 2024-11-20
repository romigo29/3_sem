.586P													;система команд(процессор Pentium)
.MODEL FLAT, STDCALL									;модель памяти, соглашение о вызовах
includelib kernel32.lib									;компоновщику: компоновать с kernel132

ExitProcess PROTO : DWORD								;прототип функции для завершения процесса
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD	;прототип API-функции MessageBoxA 

.STACK 4096								;выделение стека

.CONST									;сегмент констант

.DATA									;сегмент данных
MB_OK	EQU 0							;EQU определяет константу
STR1	DB "Моя первая программа", 0	;строка, первый элемент данных + нулевой бит
STR2	DB "Привет, БГТУ!", 0
HW		DD ?

.CODE									;сегмент кода

main PROC 								;точка входа main
START:

	INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK

	push - 1							;код возврата (-1) процесса Windows(параметр ExitProcess)
	call ExitProcess					;завершение процесса Windows
main ENDP								;конец процедуры

end main								;конец модуля main
