## Overview
Use streams and Json to read a file and convert the data to a record type.

| | |
| --------- | --------------------------- |
| Exercise Folder | Streams |
| Builds On | None |
| Time to complete | 30 minutes

In this folder, you will find a text file containing a list of movies - [Movies](ReducedMoviesJson.txt).  Take a moment to review the file.

The file is not in a pure json format.  Each line contains a json object, but the file itself is not a json object.  You will need to read the file line by line and convert each line to a json object.  Once you have the json object, you will need to convert it to a record type.

## Instructions
1. Create a new console application
2. Create a new record type called Movie
    - Add properties to the record to reflect the data in the json object
3. Open the file and read the data line by line
4. Convert each line to a json object
5. Convert the json object to a Movie record
6. Add the record to a list
7. Print the list of movies to the console
