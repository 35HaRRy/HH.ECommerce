param ($sonarQubeLoginId)

dotnet sonarscanner begin /k:"HH.ECommerce" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login=$sonarQubeLoginId /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml /d:sonar.exclusions=HH.ECommerce.Data/Migrations/**
dotnet build
dotnet-coverage collect 'dotnet test' -f xml -o 'coverage.xml'
dotnet sonarscanner end /d:sonar.login=$sonarQubeLoginId