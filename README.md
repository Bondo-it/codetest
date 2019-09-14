# Codetest

# Requirements
  - [Nodejs](https://nodejs.org/en/)
  - [Dotnet core 2.2 Runtime](https://dotnet.microsoft.com/download/dotnet-core/2.2)
  - [Dotnet core 2.2 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.2)

# Before we start
  - Clone repository
  - Install dependencie:
```sh
    npm install
    dotnet restore
```
### Run:
  - Use the debug function in either visual studio or vs code
  - Or just run this command:
```
dotnet run codetest.csproj
```
# Gerneral information about the project
The project is a standard dotnet core 2.2 MCV project.

# Database
  - We use a mongodb for this project, but feel free to switch if you prefer another option.
  - The database is publicly open, and the connectionstring in the appsettings.json is filled in, ready and working.

# Controllers:
## Modal Controller:
Modal controller returns html from a view. Useful in e.g. modals or ajax like calls.
  - [Route("api/[controller]/[action]")]
  
## User Controller:
Get users, update users, delete users.
  - [Route("api/[controller]/[action]")]

## Home Controller:
Returns your base-view.
  - [Route("[controller]/[action]")]
  
# Test objectives:

In general, we want to have at least some code in the following three languages.
  - Javascript (TypeScript)
  - C#
  - CSS (SCSS)

Using any external library is allowed, the same goes for old code in your repository. Utilizing external libraries does have to be utilized for a good reason though.

# What do we find important
- Think scalable
- Write readable code, with meaning function and variable names
- Extract your code to classes where a class or a function only have one specifik purpose
- Only write comments, if code is not self-explainatory(which it should be for the most part)
- Write your own code, dont import libraries from all over the place. We rate it very highly that you are able to write your own code.

# Write pretty code
- We have some coding guidelines that we would like all our code to follow, it would be nice if you could read it, and follow it as much as you can.

	- [the overall guidelines](https://github.com/luftborn-ivs/design-guide)

	- [C#](https://github.com/luftborn-ivs/design-guide/blob/master/c%23/readme.md)

	- [Javascript](https://github.com/luftborn-ivs/design-guide/blob/master/js/readme.md)

	- [SCSS](https://github.com/luftborn-ivs/design-guide#styling)