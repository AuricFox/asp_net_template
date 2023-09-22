# flashcards

Flashcards used to prepare for job interviews and to refresh programming knowledge. Some topics include computer science concepts such as datatypes, datastructures, and other terminology; meanwhile, other topics focus on the programming language itself.

This is my first real attempt at writing a full-stack application using C# and MVCs (models views and controllers).  

Model: class/object that manages the behavior and data  
View: manages the display of the web page (in this case a Razor HTML page)  
Controller: connects models, business logic, and web pages

## Creating a Model

create a C# class/model.

STEP 1: Right click the file named `Model`, select `Add` then `Class`  
STEP 2: Select `class` and give it a class name `Card`  

## Creating a Controller

Creates a new controller with corresponding view pages.

STEP 1: Right click `Controllers`, select `Add` and `Controller`  
STEP 2: Select `MVC Controller with views, using Entity Framework`  
STEP 3: Select model/class that will be used (i.e. `Card`)  
STEP 4: Rename New data context type to `FlashcardsWebApp.Data.ApplicationDbContext`  
STEP 5: Click `Add`  
STEP 6: Check `Generate View`, `Reference script library`, and `Use a layout page`  
STEP 7: Click `Add`  

## Creating a View

## Creating a Database (Data Migration)

This enables the migration of model/class atributes to a database table.

STEP 1: In the top left corner click `View`, select `Other Windows` and click `Package Manager Console`  
STEP 2: In the package manager console enter:
```
PM> enable-migrations
PM> add-migration "DbName"  //DbName can be anything
PM> update-database         //Creates tables for you
```

## Project Setup

### Visual Studio (IDE)

STEP 1: Select `Create a new project`  
STEP 2: Select `C#`, `Windows`, and `Web` to narrow search results  
STEP 3: Click `ASP.NET Core Web Application`  
STEP 4: Click `Next` 
STEP 5: Name project and set path  
STEP 6: Click `Create`  
STEP 7: Select `Web Application (Model-View-Controller)`  
STEP 8: Change authentication to `Individual User Accounts`  
STEP 9: Click `Create`  

### VS Code (Text Editor)

STEP 1: In the terminal, cd into your working directory and run:  
* `dotnet new console` for a console application  
* `dotnet new web` for a web application  

STEP 2: Open the project by running `code MyProjectName`  
STEP 3: Build your project by entering `dotnet build` into the terminal.

## Running Application

In Visual Studio click `IIS Express` or a green play button with the project name next to it.  
When using a terminal, cd into your working directory and enter the command `dotnet run`.

## Setting Up Editor

### Visual Studio (IDE)

STEP 1: download the [Visual Studio Community](https://visualstudio.microsoft.com/free-developer-offers/) package.  
STEP 2: Navigate through the displayed download prompts.  
STEP 3: Select desired workload packages:  
* .NET desktop development
* ASP.NET and web development
* etc.  

STEP 4: Click install  
STEP 5: Launch Application  

### VS Code (Text Editor)

STEP 1: download [Visual Studio Code](https://code.visualstudio.com/).  
STEP 2: Install the C# Extension by Microsoft.  
STEP 3: Install [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet).  
STEP 4: Verify installation in terminal: `dotnet --version`  