# Azure Functions Integration Testing #

This provides a sample app and test for Azure Functions integration testing in a CI/CD pipeline.


## Prerequisites ##

* [Azure Functions Core Tools](https://docs.microsoft.com/azure/azure-functions/functions-run-local?WT.mc_id=github-0000-juyoo)
* [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1?WT.mc_id=github-0000-juyoo)


## Getting Started ##

### Build Solution ###

```bash
dotnet restore .
dotnet build .
```


### Run Azure Functions App as a Background Process ###

* Run the function app as a background process in bash shell

    ```bash
    # Bash
    cd ./src/FunctionApp

    func start &
    bg
    ```

* Run the function app as a background process in PowerShell (Non-Windows)

    ```powershell
    # PowerShell
    cd ./src/FunctionApp

    Start-Process -NoNewWindow func @("start","--verbose","false")
    ```

* Run the function app as a background process in PowerShell (Windows)

    ```powershell
    # PowerShell
    cd ./src/FunctionApp

    $func = $(Get-Command func).Source.Replace(".ps1", ".cmd")
    Start-Process -NoNewWindow "$func" @("start","--verbose","false")
    ```


### Run Test Project ###

```bash
cd ./test/FunctionApp.Tests

dotnet test
```
