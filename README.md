# flashcards

Flashcards used to prepare for job interviews and to refresh programming knowledge. Some topics include computer science concepts such as datatypes, datastructures, and other terminology; meanwhile, other topics focus on the programming language itself.

This is my first real attempt at writing a full-stack application using C#.

## Using Visual Studio

### Setting Up The Editor

STEP 1: download the [Visual Studio Community](https://visualstudio.microsoft.com/free-developer-offers/) package.  
STEP 2: Navigate through the displayed download prompts.  
STEP 3: Select desired workload packages:  
* .NET desktop development
* ASP.NET and web development
* etc.  
STEP 4: Click install  
STEP 5: Launch Application  

### Setting Up The project

STEP 1: Select `Create a new project`  
STEP 2: Select `C#`, `Windows`, and `Web` to narrow search results  
STEP 3: Click `ASP.NET Core Web Application`  
STEP 4: Click `Next` 
STEP 5: Name project and set path  
STEP 6: Click `Create`  
STEP 7: Select `Web Application (Model-View-Controller)`  
STEP 8: Change authentication to `Individual User Accounts`  
STEP 9: Click `Create`  

### Build Application

STEP 1: Click `IIS Express`

## Using VS Code

### Setting Up The Editor

STEP 1: download [Visual Studio Code](https://code.visualstudio.com/).  
STEP 2: Install the C# Extension by Microsoft.  
STEP 3: Install [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet).  
STEP 4: Verify installation in terminal: `dotnet --version`  

### Setting Up The Project

STEP 1: In the terminal, cd into your working directory and run:  
* `dotnet new console` for a console application  
* `dotnet new web` for a web application  
STEP 2: Open the project by running `code MyProjectName`  
STEP 3: Build and run your project by entering `dotnet run` into the terminal.