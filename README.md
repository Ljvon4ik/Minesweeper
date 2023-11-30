# Minesweeper
The game architecture is based on the use of a Finite State Machine. More precisely, several: game FSM - manages global game states and is responsible for the process of transition between scenes. Each of the scenes also has its own FSM, which controls the switching of logic within this scene.
Zenject is responsible for dependency injection.
For the first time for myself, I am using reactive programming for UI.
