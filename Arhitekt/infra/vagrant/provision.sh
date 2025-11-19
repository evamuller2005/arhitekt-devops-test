sudo apt update -y
sudo apt install -y docker.io
sudo systemctl enable docker
sudo systemctl start docker

#zalaufamo MS SQL Server v dockerju
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Arhitekt2025" -e "MSSQL_PID=Developer" -p 1433:1433 --name arhitekt-sql -d mcr.microsoft.com/mssql/server:2025-latest

#počakamo da se SQL Server postavi
sleep 25

#instaliramo .net SDK
sudo apt-get install -y dotnet-sdk-8.0

#clonam o project v /home/vagrnat
cd /home/vagrant
git clone https://github.com/evamuller2005/arhitekt-devops.git

#se premaknem v project mapo
cd arhitekt-devops/Arhitekt/
#sudo dotnet tool install --global dotnet-ef --version 8.0.2
#sudo -u vagrant -H dotnet tool install --global dotnet-ef --version 8.0.2

# dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
sudo dotnet ef database update

sudo dotnet run &
