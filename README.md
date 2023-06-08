
# Welcome to Eating @ Labyrinth!

This project was created in 2015 as part of my studies.
It is a pac man like game with option of "bot-solving" via implemented A*-algorithm.
Basically you can:

- Play single player
- Let bot autosolve
- load own labyrinth

A sample labyrinth is included and will be automatically loaded on start.
Individual labyrinths can be given as arguments via "Eating@Labyrinth.exe myMap.dat" or simply set in-game by clicking "Change Labyrinth".
<br><br>

There are some things to mention:

1. The Labyrinth has to contain just "#" as walls and "." as items.
1. Exactly one field has to be a space, declaring the starting point.
1. Keep it at max 75 width and 28 height to sustain a reliable experience.

As demonstration, the file should look like this:

myMap.dat
```
19
13
###################
#.................#
#.#.###.#.#.###.#.#
#.#.#...#.#...#.#.#
#.#.###.#.#.###.#.#
#.................#
#.#.#.### ###.#.#.#
#.................#
#.#.###.#.#.###.#.#
#.#.#...#.#...#.#.#
#.#.###.#.#.###.#.#
#.................#
###################

```
If you encounter problems starting the game, just delete the GameEnv_ChangeLog.txt in the games directory.

Have fun!



