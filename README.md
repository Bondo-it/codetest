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
```sh
dotnet run codetest.csproj
```

# Gerneral information about the project
The project is a standard dotnet core 2.2 MCV project.

No libraries are used in the javascript. We utilize Gulp to bundle and compile both the TypeScript and the SCSS.

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

## Surggestions to the test
### CRUD
A surggestion to this test is to create the frontend that utilizes all the CRUD operations in the api controller (ADD, DELETE, EDIT).

### Login
Login functionality might be a great addition. We almost always need to implement login on our soulutions.

### UnitTesting
Unit testing could be a very nice addition to this project.

### Change the gulp bundler/compiler
Right now we use gulp to compile everything. Maybe this can be improved.

### Your own touch
We really want you to have freedom to do whatever you'd like in this test. Our focus is to see your ability and your focus, so what you do exactly is 100% up to you. If you want to implament a big framework, thats fine. - I'm currently pretty hooked on [svelte](https://svelte.dev) btw :)

# What do we find important
- Think scalable. Our solution needs to be maintainable and scalable.
- Write readable code, with meaningfull function and variable names
- Extract your code to classes where a class or a function only have one specific purpose
- Only write comments, if code is not self-explainatory(which it should be for the most part)
- Try to write your own code. Importing libraries has to be for a good reason. We rate it very highly that you are able to write your own code
- Remember logging. Any project without logging will never be production ready.

# Write pretty code
- We have some coding guidelines that we would like all our code to follow, it would be nice if you could read it, and follow it as much as you can.

	- [the overall guidelines](https://github.com/luftborn-ivs/design-guide)

	- [C#](https://github.com/luftborn-ivs/design-guide/blob/master/c%23/readme.md)

	- [Javascript](https://github.com/luftborn-ivs/design-guide/blob/master/js/readme.md)

	- [SCSS](https://github.com/luftborn-ivs/design-guide#styling)