title WeDo ���������α׷� ��ġ

@echo off
set curdir=%~dp0

set servicename=WedoSql
rem set disk=%~d0
rem echo %disk%

set work_dir=%disk%\MiniCTI\mysql-5.5.19-win32\bin
set work_ini=%disk%\MiniCTI\mysql-5.5.19-win32\my.ini


echo "��ġ ���� ������ Ǳ�ϴ�."
	rem ������ġ���� ����
	if exist %disk%\MiniCTI\mysql-5.5.19-win32 (
		net stop %servicename%
		%work_dir%\mysqld --remove %servicename%
		rmdir /s /q %disk%\MiniCTI\mysql-5.5.19-win32
	)


REM Folder changed
echo "create work dir.."
set unzipfile=mysql-5.5.19-win32.zip
    set TEMPDIR=%curdir%\temp\mysql-5.5.19-win32
    set TEMPDIR2=%curdir%\temp\mysql-5.5.19-win32
    set TARGETDIR=\MiniCTI\mysql-5.5.19-win32
    set TARGETMOVEDIR=\MiniCTI
    
	    if exist %TEMPDIR% rmdir /s /q %TEMPDIR%
	    if exist %TARGETDIR% rmdir /s /q %TARGETDIR%
   mkdir %TEMPDIR%

echo %curdir%\script\unzip -o %unzipfile% -d %TEMPDIR2%
%curdir%\script\unzip -o %curdir%\%unzipfile% -d %TEMPDIR2%
if exist %TARGETDIR% (
xcopy %TEMPDIR2% %TARGETDIR% /e /h /k /y
rmdir /s /q %TEMPDIR2%
) else (
mkdir %TARGETDIR%
xcopy %TEMPDIR2% %TARGETDIR% /e /h /k /y
rmdir /s /q %TEMPDIR2%
rem echo move %TEMPDIR2% %TARGETMOVEDIR%
)

rem goto final

echo "DB ���񽺸� ����մϴ�. "
rem stop & remove
cd %work_dir% rem cd C:\MiniCTI\mysql-5.5.19-win32\bin


:menu
cls

net stop %servicename%
%work_dir%\mysqld --remove %servicename%
rem register
%work_dir%\mysqld --install %servicename% --defaults-file="%work_ini%" 
rem mysqld --defaults-file="%work_ini%" %servicename%

echo "DB ���񽺸� �⵿�մϴ�. "
net start %servicename%

rem set password
%work_dir%\mysql -u root < %work_dir%\..\scripts\create_user_01.sql

rem create user
rem %work_dir%\mysql -u root -p --password=Genesys!@# < %work_dir%\..\scripts\create_user_02.sql

rem create database
%work_dir%\mysql -u root -p --password=Genesys!@# < %work_dir%\..\scripts\create_database.sql

rem create table
%work_dir%\mysql -u root -p --password=Genesys!@# < %work_dir%\..\scripts\create_table.sql

rem insert data
%work_dir%\mysql -u root -p --password=Genesys!@# < %work_dir%\..\scripts\insert_data.sql
rem %work_dir%\mysql -u root -p --password=Genesys!@# < %work_dir%\..\scripts\insert_company.sql

:final

echo "���α׷���ġ�� �Ϸ�Ǿ����ϴ�."
pause
exit