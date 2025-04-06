# Elevens
Elevens is a console app in which the user selects pairs of cards that add to 11 from a table of 10 cards until the deck is exhausted. The user may also select 3 unique face cards (Jack, Queen, King) to remove from the table as well.

Once the deck is exhausted and the table is empty, the user has won. If the user reaches a point where no pair of cards adds to 11, the user has lost. Once a game ends, the user is given the option to restart.

## Local Setup
### Prerequisites
Install the [.NET SDK](https://dotnet.microsoft.com/en-us/download) if not installed already.

Clone this repository by entering `git clone https://github.com/chanielm/Elevens.git` into the command line **OR** [download this repository](https://github.com/chanielm/Elevens/archive/refs/heads/main.zip) and unzip the contents.

_If you choose to download this repository, the repository folder may be named `Elevens-main` instead of `Elevens`. Use whichever name that the repository folder has in place of `Elevens` if it is different._

### Visual Studio Code
1. Open the repository.

2. Open "Program.cs", or any .cs file within the repository.

3. Click on the triangle at the top right corner that has the label "Run project associated with this file".

### Command Line
1. Change your directory to the repository using `cd [path-to-repo]\Elevens`.

2. Run the project using `dotnet run`.

*This is also possible using Visual Studio Code's integrated terminal.*

Alternatively, you may use `dotnet run --project [path-to-repo]\Elevens` to avoid changing directories. Replace `[path-to-repo]` with the path that leads to the repository.

## Changelog

See [CHANGELOG.md](CHANGELOG.md).
