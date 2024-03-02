# SimpleLog

SimpleLog is a basic logger for .NET applications. It is easy to use and has a simple API

```csharp
Log.Debug("This is a Debug Log");
Log.Information("This is a Information Log");
Log.Warning("This is a Warning Log");
Log.Error("This is a Error Log");
Log.Fatal("This is a Fatal Log");
```
By default a Folder is created called "logs" you can change the directory
```csharp
Log.FilePath = Path.Combine(Directory.GetCurrentDirectory(), "LogFiles");
```
You can add a prefix to the log file like "MyApplication" that will create a file "MyApplication_0.log"
```csharp
Log.FilePrefix = "MyApplication";
```
You can also limit how big the file will by in bytes
```csharp
Log.MaxFileSize = 200000;
```
You can ommit what types of logs will be logged
```csharp
Log.FileLoggingLevel = Level.Warning;
```
As well as writing the log to a file they also get printed in the console, again like logs you can ommit which level of logs get printed
```csharp
Log.ConsoleLoggingLevel = Level.Information;
```
