title WeDo 고객관리프로그램 설치 확인

@echo off
set curdir=%~dp0

set disk=%~d0
set disk=C:

set work_dir=%disk%\MiniCTI\mysql-5.5.19-win32\bin

%work_dir%\mysqladmin -h 127.0.0.1 -u root -p --password=Genesys!@# version

rem %work_dir%\mysqld --skip-grant

rem %work_dir%\mysql -h 192.168.0.29 -u root -p --password=Genesys!@# < %work_dir%\..\scripts\check_count.sql
%work_dir%\mysql -h 127.0.0.1 -u root -p --password=Genesys!@# 
use wedo_db;
rem pause
rem exit