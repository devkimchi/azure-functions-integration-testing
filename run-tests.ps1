$rootDir = $pwd.Path
cd ./test/FunctionApp.Tests
dotnet test . -c Debug
cd $rootDir
