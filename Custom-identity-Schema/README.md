[![Build Status](https://travis-ci.org/Dev-On-Demand/Blog-Examples.svg?branch=master)](https://travis-ci.org/Dev-On-Demand/Blog-Examples) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
# Custom Identity Schema
This example looks at how you  can implement the Identity framework in asp.net Core to use a custom database schema that contains your users and roles. While these types of implementations can get very complex at a database level, this will look at a simple scenario of three tables:
 - User
 - Role
 - UserRole

 While this is very simple and pretty much what the Identity Framework implements in it's own database schema that it deploys, we are showing you how to provide a way to use your schema. 
