# Star Catcher

Star Catcher is a 2D arcade game made in Unity. Move your ship left and right to catch falling stars, dodge asteroids, build combos, and grab power-ups. It gets faster the longer you survive.

## Play it
[Play Star Catcher on itch.io](https://amarakondaamogh9.itch.io/star-catcher)

## How to play
- **Move:** Arrow keys or A / D
- **Pause:** Escape button
- **Goal:** Catch as many stars as you can. Asteroids cost you a life, and you lose when all 3 lives are gone.

## Features
- **Combo multiplier:** Catch stars in a row to build a combo. 5 in a row gives x2 points, 10 gives x3, and 20 gives x5. Getting hit resets it. The combo text pops and flashes when it grows, hits a new tier, or breaks.
- **Power-ups:**
    - **Shield** (cyan): blocks the enxt asteroid hit and protects your combo
    - **Slow-motion** (green): everything falling moves at half speed for 5 seconds, but you don't slow down
    - **Magnet** (pink): pulls nearby stars toward you for 5 seconds
- **Different falling objects:**
    - **Golden stars** are rare, spin, and are worth 5 points
    - **Zigzag asteroids** swing side to side as they fall
    - **Fast asteroids** are small, red, and fall much faster
- **Difficulty ramp:** objects spawn more often and fall faster over time
- **Survival timer** showing how long you've lasted
- **High score** that stays saved after closing the game
- **Main menu, pause menu, and game over screen**

## How it's built
Made in Unity 6 with C#

- **GameManager** handles the game rules: score, lives, combo, survival time, and game over. It doesn't touch the UI directly. Instead it uses C# events to announce what happened, such as 'OnScoreChanged' and 'OnLivesChanged'
- **UIManager** listens to those events and updates the text on screen, including the combo pop animations, done with coroutines.
- **FallingObject** is the base class for everything that falls. **GoldenStar**, **ZigzagAsteroid**, and **PowerUp** inherit from it and override 'Move()' to add spinning, a sine-wave zigzag, or power-up behaviour. Fast Asteroids just use a speed multiplier.
- **Spawner** picks what to spawn using random chances and arrays of prefabs, and speeds up over time.
- **PowerUpManager** sites on the player and handles the shield, the slow-motion countdown (using a shared static speed value), and the magnet pull.
- **PauseMenu** and **MainMenu** handle pausing with 'Time.timeScale' and switching scenes.

## What I learned
This was my first Unity game. I learned how to move obkects with code, detect collisions with triggers, build UI, swtich scenes, and save data with PlayerPrefs. The biggest concepts were inheritance (one base class for every falling object), events (keeping game logic seperate from the UI), and coroutines for animations. I also learned a lot about how to debug, like figuring out when a script was on the wrong object or a slot in the Inspector was empty.

## AI use
I used Claude as a tutor throughout the project to help me when I was really confused about an idea. But, Claude made no edits to my game or my code.

## Tools
- Unity 6
- C#
- Visual Studio Code
- Hackatime