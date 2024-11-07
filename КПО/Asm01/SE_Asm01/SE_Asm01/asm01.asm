.586P													;������� ������(��������� Pentium)
.MODEL FLAT, STDCALL									;������ ������, ���������� � �������
includelib kernel132.lib								;������������: ����������� � kernel132

ExitProcess PROTO : DWORD								;�������� ������� ��� ���������� ��������
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD	;�������� API-������� MessageBoxA 

.STACK 4096								;��������� �����

.CONST									;������� ��������

.DATA									;������� ������
MB_OK	EQU 0							;EQU ���������� ���������
STR1	DB "��� ������ ���������", 0	;������, ������ ������� ������ + ������� ���
STR2	DB "������, ����!", 0
HW		DD ?

.CODE									;������� ����

main PROC 								;����� ����� main
START:

	INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK

	push - 1							;��� �������� (-1) �������� Windows(�������� ExitProcess)
	call ExitProcess					;���������� �������� Windows
main ENDP								;����� ���������

end main								;����� ������ main