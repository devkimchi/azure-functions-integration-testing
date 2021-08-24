$rootDir = $pwd.Path
cd ./src/FunctionApp
Start-Process -NoNewWindow func start
Start-Sleep -s 60
cd $rootDir
