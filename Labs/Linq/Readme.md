## Overview
Query our movie database using LInQ.

| | |
| --------- | --------------------------- |
| Exercise Folder | Linq |
| Builds On | Streams |
| Time to complete | 30 minutes

This lab is a continuation of the Streams lab. In this lab, you will use Linq to query the movie database.

### Refactoring MovieDb
1. At the bottom of `Program.cs`, add a new class named *MovieDb*.
2. Create a private field named *movies* of type `List<Movie>`.
3. Create a constructor that initializes the *movies* field with a new list of movies.
    - copy the old code that read the file and deserialized the json into the constructor.
4. In the top-level code, create a new instance of *MovieDb*.
5. Use Linq to query the movie database.
    - find movies with your favorite actor
    - find movies from 2008 that were rated PG-13
    - find movies with 2 of your favorite actors
