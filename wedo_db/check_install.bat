title WeDo ���������α׷� ��ġ Ȯ��

@echo off
set curdir=%~dp0

set disk=%~d0

set work_dir=%disk%\MiniCTI\mysql-5.5.19-win32\bin

%work_dir%\mysql -u root -p --password=Genesys!@# < %work_dir%\..\scripts\check_count.sql
pause
exit