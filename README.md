# SimpleLog

SimpleLog is a lightweight, flexible logging library for .NET applications. It provides an easy way to log messages at various levels including Debug, Information, Warning, Error, and Fatal. The library allows logging to both the console and to files, with customizable settings for each.

## Features

- **Console and File Logging**: Log messages to the console and/or to files based on the defined levels.
- **Log Level Control**: Independently set the minimum log level for console and file outputs.
- **Automatic File Rotation**: Prevent log files from growing indefinitely by setting a maximum file size. Once reached, a new log file is created.
- **Customizable File Naming**: Prefix log files with a custom string to help organize and identify log files easily.
- **Log Message Details**: Each log message includes the timestamp, log level, class, and method name from where it was logged, providing a clear context for each entry.

## Getting Started

### Prerequisites

- .NET compatible development environment

### Installation

Currently, SimpleLog is not packaged as a NuGet package, so you'll need to include it directly in your project:

1. Clone this repository or download the source code.
2. Include the `SimpleLog.cs` file in your project.

### Usage

1. **Configure Logging Levels and Paths:**

    Before logging any messages, you may want to configure the logging levels and file paths according to your needs. This can be done by setting the properties of the `Log` class.

    ```csharp
    Log.ConsoleLoggingLevel = Level.Error; // Only log errors and above to the console
    Log.FileLoggingLevel = Level.Information; // Log information and above to files
    Log.FilePrefix = "myapp"; // Prefix for log files
    Log.FilePath = @"C:\Logs"; // Directory for log files
    Log.MaxFileSize = 1000000; // Maximum file size in bytes
    ```

2. **Logging Messages:**

    Log messages by calling the respective method for the desired log level.

    ```csharp
    Log.Debug("This is a debug message.");
    Log.Information("This is an informational message.");
    Log.Warning("This is a warning message.");
    Log.Error("This is an error message.");
    Log.Fatal("This is a fatal message.");
    ```

## Configuration

- `ConsoleLoggingLevel`: Minimum level of messages logged to the console.
- `FileLoggingLevel`: Minimum level of messages logged to files.
- `FilePrefix`: Prefix string for log file names.
- `FilePath`: Path to the directory where log files are stored.
- `MaxFileSize`: Maximum size of a log file in bytes. When exceeded, a new file is created.

## Contributing

Contributions are welcome! If you have a feature request, bug report, or a suggestion, please open an issue or submit a pull request.

## License

SimpleLog is released under [MIT License](LICENSE).

