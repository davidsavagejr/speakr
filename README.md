# SpeakR #

SpeakR is an R&D project on how to facilitate feedback for public speakers.

## Contributing ##

If you want to contribute, check with me first about what to work on.
Otherwise, you can branch/fork then submit a PR

Check out the wiki for [getting your dev environment setup](https://github.com/HeadspringLabs/speakr/wiki/Development-Environment).

## Understanding the Project Structure ##

Right now there are 4 projects:

* **Web** - this is the UI
* **Core** - all of the request handlers / requests.  There shouldn't be any models in here; instead, put properties on the request object and use Automapper to go from the request -> data model
* **Data** - data access only, no handlers, models generated by TT file.
* **Test** - unit tests project

In the future we will add an API project that will interact with **Core**
