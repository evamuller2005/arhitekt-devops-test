# Arhitekt — Platforma za arhitekte

# Avtorja  

Gregor Vidrih - 63220356    
Eva Müller - 63220501  

# Cilji in Opis

Arhitekt je spletna platforma, ki arhitektom omogoča raziskovanje projektov, povezovanje z drugimi arhitekti, objavljanje lastnih del ter pregledovanje skupnosti.

- Povezovanje arhitektov.
- Deljenje idej in projektov.
- Promocija dosežkov arhitektov.
- Gradnja mreže strokovnjakov.

Sistem je sestavljen iz:
- ASP.NET Core 8 web aplikacije
- MSSQL podatkovne baze
- Redis strežnika za caching / sessions
- Docker containerjev
- Vagrant + Ansible provisioning (DevOps setup)

# Glavne funkcionalnosti

1. Uporabniški profili  
   - Registracija in prijava z e-pošto.  
   - Seznam objavljenih projektov pod My Projects.
   - Možnost urejanja profila. 

2. Objava projektov
   - Arhitekti lahko dodajo svoje projekte z naslednjimi podatki:
     - Naslov projekta.
     - Opis projekta.
     - Slika.
     - Datum ustvarjanja projekta.

3. Brskanje in raziskovanje
   - Vsi projekti so prikazani na domači strani v obliki mreže.  
   - Iskanje po imenih projektov, arhitektih in ključnih besedah.  
   - Klik na projekt prikaže podrobnosti o njem.

# Tehnologije
- Backend - ASP.NET Core 8
- Frontend	- Razor Pages / HTML / Bootstrap
- Podatkovna baza -	MSSQL Server (Docker)
- Cache	Redis 7 - (Docker)
- Avtentikacija - ASP.NET Identity
- ORM - Entity Framework Core
- DevOps - Vagrant + Ansible
- Containerji	- Docker

# Izvedba Nalog

Gregor Vidrih:
- Nastavitev podatkovne baze in implementacija avtentikacije uporabnikov.
- Razvoj Android aplikacije in implementacija funkcionalnosti za iskanje projektov.
- Razvoj sistema za dodajanje in prikazovanje projektov.

Eva Müller:
- Oblikovanje uporabniškega vmesnika spletne aplikacije, vključno z izgledom strani, prikazom slik in postavitvijo vsebine.
- Objava spletne storitve v oblak.
- Optimizacija vizualnih elementov spletne strani.

# Development način

#### Posodobi pakete:

sudo apt update  
sudo apt upgrade -y  

#### Namesti Docker:

sudo apt install -y docker.io  
sudo systemctl enable docker  
sudo systemctl start docker  

#### Zaženi MSSQL:

sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Arhitekt2025" -e "MSSQL_PID=Developer" -p 1433:1433 --name arhitekt-sql -d mcr.microsoft.com/mssql/server:2025-latest  

#### Zaženi Redis:

sudo docker run -p 6379:6379 --name arhitekt-redis -d redis:7  

#### Namesti .NET SDK:

sudo apt install -y dotnet-sdk-8.0  

#### Kloniraj projekt 

git clone https://github.com/evamuller2005/arhitekt-devops.git  
cd arhitekt-devops/Arhitekt  

#### Izvedi migracije

dotnet tool install --global dotnet-ef --version 8.0.2  
export PATH="$PATH:$HOME/.dotnet/tools"  

dotnet ef database update

#### 4. Zaženi development

dotnet run

##### Aplikacija bo dostopna na http://localhost:5059

# Production način

#### Publish aplikacije

cd ~/arhitekt-devops  
dotnet publish -c Release -o ~/arhitekt-published  

#### Systemd service

#### ustvari /etc/systemd/system/arhitekt.service:

[Unit]
Description=Arhitekt ASP.NET Core Application  
After=network.target docker.service docker.socket

[Service]
WorkingDirectory=/home/vagrant/arhitekt-published
ExecStart=/usr/bin/dotnet /home/vagrant/arhitekt-published/Arhitekt.dll
Restart=always
RestartSec=10
User=vagrant

Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=ASPNETCORE_URLS=http://0.0.0.0:5059
Environment=ConnectionStrings__DefaultConnection=Server=localhost,1433;Database=Arhitekt;User Id=sa;Password=Arhitekt2025;TrustServerCertificate=True;
Environment=Redis__Host=localhost:6379

[Install]
WantedBy=multi-user.target

#### Zaženi arhitekt.service

sudo systemctl daemon-reload  
sudo systemctl enable arhitekt.service  
sudo systemctl start arhitekt.service  
sudo systemctl status arhitekt.service  

# DevOps Deployment (Vagrant + Ansible)

- Navodila za Ubuntu 22.04 / 24.04

#### virtualBox, vagrant, ansible

sudo apt install -y virtualbox   
sudo apt install -y vagrant   
sudo apt install -y ansible   

#### run vagrant

vagrant up
