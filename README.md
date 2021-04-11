# Battleship State Tracker
This project is the implementation of Battleship state tracker API.

## Project scope
The task is to implement a Battleship state tracking API for a single player that must support the following logic:

- Create a board
- Add a battleship to the board
- Take an “attack” at a given position, and report back whether the attack resulted in a hit or a miss.

## Solution Structure
There are four projects in the solution
- OfxCodeExercise.Battleship.Api.StateTracker
   
   This is the Web Api implementation of battleship state tracker
- OfxCodeExercise.Battleship.Lib
   
   This libary contains the shared domain models, business logic and a simple in-memory service provider for battleship game.
- OfxCodeExtercise.Battleship.Tests
   
   Unit Test Project contains unit tests for the library
- OfxCodeExercise.Battleship.Api.IntegrationTesting
   
    Web Api test project for StateTracker Web api

## Azure Deployment
The State Tracker Web Api has been deployed to Azure and is available here: https://ofxcodeexercisebattleshipapistatetracker20210411204905.azurewebsites.net/swagger/index.html

##
