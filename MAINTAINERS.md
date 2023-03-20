# Maintainers

## Deploying new verison

Bump version in `Criipto.Signatures/Criipto.Signatures.csproj`.

Build release version `dotnet pack -c Release Criipto.Signatures`

Push new version `dotnet nuget push Criipto.Signatures/bin/Release/Criipto.Signatures.{VERSION}.nupkg --api-key {NUGET_KEY} --source https://api.nuget.org/v3/index.json`