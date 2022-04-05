# Api2Csv

Console app to read data from REST Api in json format and save gathered data in a .csv table.

## Getting Started
First edit App.config file and add desired api server URL and file locations.
If the API authentication token is not used, just leave the field empty.

To use the app simply run the app with comma separated arguments, each arg will be a separate GET request to the API server.

Example:
Api2Csv.exe 1,2,3

### Dependencies
tested only on Windows 10

