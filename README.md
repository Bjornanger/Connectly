# Connectly 

## 🎟️ Eventbokningsapplikation – ASP.NET Core Blazor  

## 📌 Beskrivning  
Denna applikation hanterar **eventbokning och administration** där en **Admin** kan skapa och publicera inbjudningar samt hantera material som delas efter eventet. Applikationen säkerställer att endast registrerade deltagare kan få tillgång till dokument, bilder och annan information relaterad till eventet.  

Applikationen är byggd i **ASP.NET Core Blazor Server med .NET 8** och använder **Microsoft SQL Server** för datalagring. **Entity Framework** hanterar objektrelationell avbildning (ORM).  

## 🔧 Funktioner  

📅 **Eventhantering**  
- Skapa och publicera inbjudningar till event.  
- Administrera registrerade deltagare.  
- Hantera eventmaterial, såsom bilder, dokument och sammanfattningar.  

🔒 **Användarautentisering & Roller**  
- **Admin** skapar och administrerar event samt tillhörande material.  
- **Deltagare** kan registrera sig för ett event och får **ett genererat konto** för åtkomst till eventspecifikt material.  
- Endast deltagare som har **varit med på eventet** kan ta del av dess material.  

📂 **Filhantering**  
- Ladda upp och hantera bilder, PDF-filer och dokument kopplade till ett event.  
- Ge registrerade användare tillgång till specifika event-filer.  

📊 **Excel-hantering**  
- Importera och exportera data via Excelfiler.  

🏗️ **Modern arkitektur**  
- Applikationen har uppgraderats från **Blazor WebAssembly (.NET 5)** till **Blazor Server (.NET 8)** med individuella användarkonton.  
- Refaktorerad till **Clean Architecture**.  
- Implementering av **designmönster**: Repository, Unit of Work, Factory Method.  
- Tillämpar **SOLID-principer** för en strukturerad och skalbar kodbas.  

## 🛠️ Tekniker och Verktyg  
- **C# & .NET 8**  
- **ASP.NET Core Blazor Server**  
- **Entity Framework (ORM)**  
- **Microsoft SQL Server**  
- **HTML, CSS & Bootstrap**  
- **Git (Versionshantering)**  
- **Excel-hantering**  
- **Clean Architecture**  
