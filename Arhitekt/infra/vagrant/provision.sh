#!/bin/bash

#updatam sistem
sudo apt update -y

##za bazo
sudo mysql -u root <<EOF
CREATE DATABASE IF NOT EXISTS ArhitektDb;
CREATE USER IF NOT EXISTS 'sa'@'localhost' IDENTIFIED BY 'Arhitekt2025';
GRANT ALL PRIVILEGES ON ArhitektDb.* TO 'sa'@'localhost';
FLUSH PRIVILEGES;
EOF

# #installam docker, enablam, in startam
# sudo apt install -y docker.io
# sudo systemctl enable docker
# sudo systemctl start docker

# #zalaufam MS-SQL server v dockerju
# sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Arhitekt2025" -e "MSSQL_PID=Developer" -p 1433:1433 --name arhitekt-sql -d mcr.microsoft.com/mssql/server:2025-latest

# #počakam da se SQL Server postav
# sleep 30

#instaliram .net SDK
sudo apt-get install -y dotnet-sdk-8.0

#clonam project v /home/vagrnat
#cd /home/vagrant
git clone https://github.com/evamuller2005/arhitekt-devops.git

#se premaknem v mapo
cd arhitekt-devops/Arhitekt/

#ne rabm dotnet toolsov ker je to itak devtool, niti nerabm dbjev updatat ker migracije so sam pr spremmbi strukture baze

#zazenem app da runna na 
sudo dotnet run 




