
- Basic Notes:
- Low level design and code with best  practices
- Service used Directly to Connect with Database instead of Repostry pattern due to its low level architecture.
- The openAi API has been set up as a Rest API for text validation.
- This Web Application Created with .NET 6.0

How to Configure:
- Add ConnectionString into appsettings.json section under "DefaultConnection".
- Go to Tools > NuGet Package Manager > Pacakage Manager Console
- On the Pacakage Manager Console select -> Steve.Data as Default Project then Run "Update-Database" command.
 
-Add default data into your database for login.
--INSERT INTO tblUsers VALUES('admin','admin','admin','0000000000','admin@gmail.com',GETDATE(),GETDATE())

For API Configuration:
- Replace <KEY> with Your APIKEY into appsettings.json Under "OpenAIConfiguration"
