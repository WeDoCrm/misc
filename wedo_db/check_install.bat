title WeDo 고객관리프로그램 설치 확인

@echo off
set curdir=%~dp0

set disk=%~d0

set work_dir=%disk%\MiniCTI\mysql-5.5.19-win32\bin

%work_dir%\mysql -u root -p --password=Genesys!@# < %work_dir%\..\scripts\check_count.sql
pause
exit