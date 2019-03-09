# BettingParlor

Client-Server desktop betting application written in C#.

Fun game which simulates the process of playing at a parlor.

## Installation

Simply download the BettingParlor.zip archive which contains the installer.

You can find it here: [BettingParlor installer](https://github.com/LeszekBlazewski/BettingParlor/releases)

Run the setup.exe file. This will automatically install all the required dependencies for you.

### Requirements

* Windows

* Microsoft .NET Framework 4.6.1

* SQL Server 2012 Express LocalDB

The installer will take care of the .Net framework and localDB so don't bother about them :smile:

## Usage

:warning: **Administrator account must be always logged in as first and maintained until all clients disconnect** :warning:

#### This steps represents the process of starting the application:

1. Login to administrator account in order to start local server with these credentials:

   * Login: admin

   * Password: admin

2. Create as many clients’ accounts as you wish and start their applications within different instances of Setup.exe.

3. Enjoy the fun ! :grin:

## Background information

This application was built for my computer science class project - OOP. We were supposed to write an application from scratch which represents the main principles of object oriented programming. I thought that it would be cool if I can extend the app a little bit and ad a Server-Client model which uses a SQL database. I tried to polish the code as much as possible with design patterns, most of the SOLID principles and by following the rules of clean code. Moreover I also created a use-case diagram which represents the basic operations included in the project and a class diagram which shows the relations between different classes among the software.

## Short description

#### Frameworks used to develop the main core of the application:

1. [Winforms](https://docs.microsoft.com/en-us/dotnet/framework/winforms/)

2. [LINQ to SQL](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/)

3. [SignalR](https://www.asp.net/signalr)

#### Other tools used in the project:

1. [Sandcastle Help File Builder](https://github.com/EWSoftware/SHFB)

2. [Microsoft unit testing tool](https://docs.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing)

The application is displayed as a Winforms window which also handles all the user interactions with the software. LINQ to SQL provides an implementation of the standard query operators for objects associated with tables in a relational database. It's really easy to setup and LINQ statements provide rapid access to all of the tables stored in database. Moreover SignalR handles connections between the server and clients by using Hub instances. This framework works like a charm by hosting local server on HTTPS and takes care of all the request/responses sent between server and clients. Sandcastle Help File Builder was used to generate a full interactive documentation of the whole project from XML comments. You can find the documentation site in the project repository. Last but not least the built-in unit testing tool provided by Microsoft allowed me to write various tests. I also tried to follow the TDD convention therefore I used this unit testing tool.

##### :exclamation::exclamation::exclamation: Polish readers :exclamation::exclamation::exclamation:

If you are a polish reader I highly recommend checking out the whole documentation for the project which includes detailed description about the development process and more in-depth explanation of certain parts of the code.

You can find it here: [Polish documentation](https://github.com/LeszekBlazewski/BettingParlor/blob/master/Documentation/Dokumentacja%20%20projektowa.pdf)

## Why local SQL database instead of SQL server?

When i first created the project I used SQL server 2017 for maintaining my  database. The main idea was to create an desktop application which will connect to remote SQL server hosted on a VPS and that will result in having a multiplayer betting app. All of the clients would connect to that instance and share data with it. Sadly i can't afford buying myself a VPS therefore i downgraded from SQL 2017 to SQL 2014 and used a local DB.  Now I can distribute the application and the local database is already included in the setup files. Users can host a server themselves and start multiple instances of client applications in order to observe that all of the described functionality is provided. Using the local DB also resulted in significantly decreasing the size of setup files because users no longer have to install the SQL server. They just need a lightweight local database which is installed as a prerequisite for the app during the installation process.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
