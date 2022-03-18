[![Codacy Badge](https://app.codacy.com/project/badge/Grade/44e0255e3b034055a02a1b92855582b3)](https://www.codacy.com/gh/RonnieLutalo/ExpenseTracker/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=RonnieLutalo/ExpenseTracker&amp;utm_campaign=Badge_Grade)

## Expense Tracker

### Overview
An intuitive solution that attempts to free the user from as much as possible the burden of manual calculation while keeping track of their expenditure easily.

#### Motivation 💡
Instead of keeping a diary or a log of the expenses, this solution enables the user to not just keep the control on the expenses but also to generate and save reports.

With the help of this solution, the user can manage their expenses on a daily, weekly and monthly basis. Users can insert and delete transactions as well as can generate and save their reports. The goal is to have a solution that appeals to the user more and is easy to understand.

#### Technologies Used🚀
- [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet) 6 for API and MVC Razor Pages
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/) and Microsoft SQL Server for Data Access
- [MediatR](https://www.nuget.org/packages/MediatR/) 
- [AutoMapper](https://automapper.org/) for Domain model and Data Transfer Object mapping
- [Fluent Validation](https://fluentvalidation.net/) 
- [xUnit](https://xunit.net/) for Unit Tests in ASP.NET Core
- [React.js](https://reactjs.org/) and [MVC-Razor Pages](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc) for Frontend Client Applications
- [BootStrap](https://getbootstrap.com/) for styling Frontend/UI/Client Applications 

### System Architecture 
This System uses the [Onion Architecture (Clean Architecture)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) for it's implementation

#### Data/Domain Model

