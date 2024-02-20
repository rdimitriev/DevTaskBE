# XML to JSON file handling demo

This is a sample project demonstrating XML file upload, XML to JSON conversion and JSON download using [FastEndpoints](https://fast-endpoints.com/).

## Configuration

Storage location of all processed json files changed in the `Config.cs` file in the root of the project by modifying `StoragePath` prop.

## Start project

Start the project API serving on [http://localhost:3001](http://localhost:3001) with the following command from the Source directory:

### `dotnet run`

## Run tests

Run test project from Tests directory from the console:

### `dotnet test`

## API Schema

After you start the project, you can navigate to [http://localhost:3001/swagger/index.html#/](http://localhost:3001/swagger/index.html#/) to see the API endpoints and try them directly.

## Frontend

There's a separete React frontend (DevTaskFE) which could be build and run which is integrated with this project. Refer to its README.md documentation.

## Prerequisites
- .Net 8.0
