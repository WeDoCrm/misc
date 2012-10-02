SET PASSWORD FOR 'root'@'localhost' = PASSWORD('Genesys!@#');
SET PASSWORD FOR 'root'@'127.0.0.1' = PASSWORD('Genesys!@#');
SET PASSWORD FOR 'root'@'::1' = PASSWORD('Genesys!@#');
SET PASSWORD FOR ''@'localhost' = PASSWORD('Genesys!@#');

CREATE USER 'root'@'%' IDENTIFIED BY 'Genesys!@#';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%';
FLUSH PRIVILEGES;
