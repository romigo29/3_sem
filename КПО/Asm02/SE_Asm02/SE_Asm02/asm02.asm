.586P													;������� ������(��������� Pentium)
.MODEL FLAT, STDCALL									;������ ������, ���������� � �������
includelib kernel32.lib									;������������: ����������� � kernel132
includelib user32.lib

ExitProcess PROTO : DWORD								;�������� ������� ��� ���������� ��������
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD	;�������� API-������� MessageBoxA 

.STACK 4096								;��������� �����

.CONST									;������� ��������

.DATA									;������� ������

MB_OK	EQU		0
a	DB			2
b	DB			4
STR1	DB		"�����", 0	
RESULT	DB	"��������� �������� = < >", 0
HW			DD ?

.CODE									;������� ����

main PROC 								;����� ����� main
START:

	mov al, a
	add al, b
	add eax, 30h
	mov str1+28, al
	INVOKE MessageBoxA, HW, OFFSET RESULT, OFFSET STR1, MB_OK

	push -1								;��� �������� (-1) �������� Windows(�������� ExitProcess)
	call ExitProcess					;���������� �������� Windows
main ENDP								;����� ���������

end main