# HH.ECommerce
A single service api for generating discounts, invoice and customers

Please, first check "UML class diagrams"
  ### Data

  ![Data](/UML.Class.Diagrams/Data.png "Data")
  ### Entities

  ![Entities](/UML.Class.Diagrams/Entities.png "Entities")
  ### Services

  ![Services](/UML.Class.Diagrams/Services.png "Services")

## .Net SDK
Download and istall the .NET 6 SDK
>https://dotnet.microsoft.com/en-us/download/dotnet/6.0

# Setup & Run & Test
## Visual Studio
- Simply open the solution file <code>HH.ECommerce.sln</code>

  and
    >wait for project restore. 
  
  then

    >build/run.

## Visual Studio Code
- After cloning run 
  >dotnet restore
  
  to restore all packages and dependencies
 
## Migration
- Run migration to gain access to the seeded data
- For Package Manager Console Visual Studio 
  >Update-Database
  
- For cmd/cli (Visual studio code)
  >dotnet ef database update
 
## Launch
- To launch the project
  > dotnet run (on the CLI or Package Manager Console)

## Test
- To test the project
  > dotnet test

# SonarQube Scan
- Install dotnet-sonarscanner and dotnet-coverage tools
  >dotnet tool install --global dotnet-sonarscanner
  
  >dotnet tool install --global dotnet-coverage
- Start SonarQube docker container
  >docker run -d --name sonarqube -e SONAR_ES_BOOTSTRAP_CHECKS_DISABLE=true -p 9000:9000 sonarqube:latest
- And then you can start a scan by following below commands in order
  >dotnet sonarscanner begin /k:"HH.ECommerce" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="[SonarQubeLoginId]" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml /d:sonar.exclusions=HH.ECommerce.Data/Migrations/**
  
  >dotnet build

  >dotnet test --collect "Code Coverage"
  
  >dotnet sonarscanner end /d:sonar.login="[SonarQubeLoginId]"
- Or you can simply use StartSonarQubeScan.sp1
  >.\StartSonarQubeScan.sp1 -sonarQubeLoginId "[SonarQubeLoginId]"

- Example scan results
  ![SonarQubeScan](/SolutionFiles/SonarQubeScan1.png "SonarQube Scan")