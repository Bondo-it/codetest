
[![N|Solid](https://www.luftborn.com/img/logo.svg)](https://www.luftborn.com)

#Luftborn codetest

# Before we start
  - Clone repository
  - Run:
```
    submodule update --init --recursive
    npm install
    dotnet restore
    gulp
```

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

## Undefined test:
*Define your own test*

Suggestions could be:
  - Add authentication
  - Add functionality in the frontend for adding, deleting and updating users
  - Improve UI/styling


## Defined test:
  - Add functionality in the frontend for adding, deleting and updating users
  - Improve UI/styling

# What do we find important
- Think scalable
- Write readable code, with meaning function and variable names
- Extract your code to classes where a class or a function only have one specifik purpose
- Only write comments, if code is not self-explainatory(which it should be for the most part)
- Write your own code, dont import libraries from all over the place. We rate it very highly that you are able to write your own code.



