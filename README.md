# Dotnet mongo test

Repository created to study NoSql with mongo and the integration with dotnet.

## Running the application

You will need an instance of mongo running. I sugest using docker containers for it, to start a container of mongo simply type the following command on console:

```
$ docker run -d -p 27017:27017 mongo
```

And run the application with:

```
$ dotnet run -p src/DotnetMongoTest.ConsoleApp/
```

*Note:* If you are using windows, do not run the application with git bash

## Built with

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) - _Software Developmet Kit (SDK)_
- [MongoDB](https://www.mongodb.com/) - _Mongo db_