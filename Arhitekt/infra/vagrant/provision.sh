#!/bin/bash

#updatam sistem
sudo apt update -y

#installam docker, enablam, in startam
sudo apt install -y docker.io
sudo systemctl enable docker
sudo systemctl start docker

#zalaufam MS-SQL server v dockerju
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Arhitekt2025" -e "MSSQL_PID=Developer" -p 1433:1433 --name arhitekt-sql -d mcr.microsoft.com/mssql/server:2025-latest

#počakam da se SQL Server postav
sleep 30

#instaliram .net SDK
sudo apt-get install -y dotnet-sdk-8.0

#clonam project na vm
git clone https://github.com/evamuller2005/arhitekt-devops.git #gre v /home/vagrant/arhitekt-devops

#se premaknem v mapo da loh publisham
cd /home/vagrant/arhitekt-devops/Arhitekt/

#publisham dotnet app v arhitekt-published mapo
dotnet publish -c Release -o /home/vagrant/arhitekt-published

#ustvarim systemd service file
sudo tee /etc/systemd/system/arhitekt.service <<EOF
[Unit]
Description=Arhitekt ASP.NET Core Application
After=network.target

[Service]
WorkingDirectory=/home/vagrant/arhitekt-published
ExecStart=/usr/bin/dotnet /home/vagrant/arhitekt-published/Arhitekt.dll
Restart=always
RestartSec=10
User=vagrant
Environment=ASPNETCORE_URLS=http://0.0.0.0:5059

[Install]
WantedBy=multi-user.target
EOF

#startam in enablam service
sudo systemctl daemon-reload
sudo systemctl start arhitekt.service
sudo systemctl enable arhitekt.service


#zazenem app da runna na 
#sudo dotnet run 








