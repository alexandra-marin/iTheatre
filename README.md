## iTheatre

## What is it?

iTheatre is a macOS application built with Xamarin.Mac. It’s searching IMDB for movies currently running in theaters and displays the cast’s average age for each one.

## Project structure

The project includes the application folder iTheatre and the tests project iTheatre.Tests. 

The application follows the MVC model, with files split in between the Views, Models and Controllers folders and an additional Helpers folder. 

Views folder groups the storyboard and other files helping rendering views. 

Only one view controller is used in the app, residing in the Controllers folder. 

The models used are movie and actor. A movie has a title and a cast made of actors. In the actor model we mostly care about the birthdate to calculate the average age. 

The data is pulled from a local service called MovieAPI which connects to the IMDB website. The service implements a basic IMoviesAPI interface and can be easily changed.

The Tests folder contains unit and integration tests, separated in own folders. Tests are written using NUnit, Shouldly and FakeItEasy.

## Installation

Run Install script (find it in the root folder) by right clicking and selecting “Open with Terminal” and enter your password when prompted.
