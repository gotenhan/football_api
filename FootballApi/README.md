Solution to recruitment assignment Football Api
Author: Adrian Dylinski

It is a Web Api 2/Owin web application. It was set up and tested to be hosted on IIS. To do this, create a new website and point it to FootballApi project directory.
Installation guid:
1. Create a new "FootballApi" website in IIS console that uses "FootballApi" app pool; Point it to FootballApi project directory;
2. Open solution and go to package manager console. Run Update-Database. This will create initial version of db named FootballApi.Data.FootballApiContext.
3. Run FootballApi.Seed console application to seed database with teams.
4. Create a database login "IIS APPPOOL\FootballApi". Select db_owner role for this login  for FootballApi.Data.FootballApiContext db. Set default schema to "dbo".