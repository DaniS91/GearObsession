# _Gear Obsession_

#### By _Dani Steely_
#### And _Geoffrey Gao_

#### _App for comparing and organizing backpacking backpacking gear, or any gear! Uses database to help the user organize, sort, and plan gear._

## Technologies Used

* C#_
* ASP.NET Core MVC
* Entity Framework Core
* MySQL
* [SyncFusion Interactive Chart Library](https://www.syncfusion.com/aspnet-core-ui-controls/charts/chart-types/pie-chart)

## Description
This application was a collaborative project as part of [Epicodus][Epicodus] coursework in C# and .NET. The application was created to demonstrate ability to use the Entity Framework Core and MySQL databases with many-to-many relationships; it also uses ASP.NET Core MVC to handle routing and requests and uses Entity FrameWork Core to communicate to a MySql database using .NET objects. The website itself displays items, categories, and users and lists their details. All categories and items are listed on the home page; the items view is formatted using a table that can be sorted by property. The users view includes a chart created using [SyncFusion Interactive Chart Library][Syncfusion] and a table that calculates the total weight of all items assigned to that user.
![screenshot of users page including table and chart](https://raw.githubusercontent.com/DaniS91/GearObsession/main/GearObsession/wwwroot/chartimg.jpg)

## Setup/Installation Requirements

#### Setting up directories
* clone this repo to your desktop
* navigate to project directory in your terminal
* you may want to include a .gitignore file in your root directory
* in your .gitignore file you can include the appsettings.json file that you will need to create in the next step
#### Creating an appsettings file
* navigate to "GearObsession" directory (production directory)
* create a new file called appsettings.json
* the following code should go in the appsettings.json file:
```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE-NAME];uid=[USERNAME];pwd={PASSWORD};"
  }
}
```
* within the appsettings.json file, you will need to replace `[DATABASE-NAME]` with the name of the database, `[USERNAME]` with your username, and `[PASSWORD]` with your password

## License

_MIT License_

Copyright (c) _3/14/23_ _Dani Steely_

[Epicodus]: https://www.learnhowtoprogram.com/tracks/c-and-react-part-time
[Syncfusion]: https://www.syncfusion.com/aspnet-core-ui-controls/charts/chart-types/pie-chart