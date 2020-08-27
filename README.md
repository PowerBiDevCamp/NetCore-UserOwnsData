# :monkey_face:  .NET Core User-Owns-Data Sample
This sample provides a starter web application for Power BI embedding using .NET Core 3.1 and the new Microsoft Authentication Library named `Microsoft.Identity.Web`. You can use this sample application to create your own Power BI embedding prototype.

## :clipboard: Requirements for running this sample application.
To run this sample application on your development workstation you must meet the following prerequisites.
Your developer workstation must be configured to allow for the execution of PowerShell scripts. Your developer workstation must also have the following software and developer tools installed.

- PowerShell cmdlet library for AzureAD - [download](https://docs.microsoft.com/en-us/powershell/azure/active-directory/install-adv2?view=azureadps-2.0)
- DOTNET Core SDK 3.1 or later - [download](https://dotnet.microsoft.com/download)
- Node.js - [download](https://nodejs.org/en/download/)
- Visual Studio Code] - [download](https://code.visualstudio.com/Download)
- Visual Studio 2019 (optional) - [download](https://visualstudio.microsoft.com/downloads/)

## :scroll: Downloading and configuring this sample application.
Once you have installed the prequisite software and developer tools, you must complete the following steps to run this sample application on your development workstation.

 - Download the code for the **UserOwnsData** project.
    1. Download the [ZIP archive](https://github.com/TedPattison/NetCore-UserOwnsData/archive/master.zip)  with the UserOwnsData project **or**
    2. Run the GIT command `git clone https://github.com/TedPattison/NetCore-UserOwnsData.git`
 - Open the **UserOwnsData** project in Visual Studio Code.
 - Run the PowerShell script named [`CreateAzureADApplication.ps1`](https://github.com/TedPattison/NetCore-UserOwnsData/blob/master/CreateAzureADApplication.ps1) to create a new Azure AD application. 
    1. When you run the open Notepad with JSON configuration data for the Azure AD application
    2. You must copy this JSON into the clipboard for the next step 
 - Paste the JSON configuration data for the Azure AD Application into `appsettings.json`.
 - Open the Visual Studio Code console and run these commands.
	```	
	npm install
	npm run build
	dotnet dev-cert https --clean 
	dotnet dev-cert https --trust
	dotnet restore
	dotnet run
	```