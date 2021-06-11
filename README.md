# Game Prototype VOLT

Hello, this is a prototype of a mobile game.
The current version works for both PC and Android.

# Files

The files contained in this repository is a complete project for Unity, just open the **Prototype_PauloJunior** folder and follow the guidelines below.


## Guidelines

-  **Biuld PC:**  Just download the **PauloJunior_Volt_PC.zip** file from the project root, extract and run on Windows.

-  **Biuld Android APK:**  Just download the **Paulojjunior_Volt.apk** file from the project root, send to an android or emulator.
- 
 - The **Unity**  version used in the project is  **2020.3.9f1**.
 -  For better flow and understanding, when loading the project for the first time, please load the scene **Menu**.
 - For better viewing set Aspect to **1920x1080 Portrait or 1080x1920**.

## Explanations of Mechanics

- **Movement mechanics:** When the player touches the screen and drags down, it creates a trajectory on the screen showing the direction of the jump, when leaving the touch the player jumps.
-  **Movement mechanics:** When the player touches the screen and drags down, it creates a trajectory on the screen showing the direction of the jump, when leaving the touch the player jumps.
- **Colors:**
 -- The player starts the game with a neutral color, being able to choose the wall he wants to jump.
 -- When the player touches a wall for the first time, it changes its color to indicate which wall he should touch next, if the player touches a wall that is not correct, he will bounce, and may die.
The next walls follow the same logic.

- **Life:**
 -- The player has a "LIFE" which is decremented according to a pre-set time. At the end of this time the player's exterior becomes transparent and the player loses the ability to stick to the wall.
 -- When health reaches zero, the player's center changes color to indicate the current state, and the player's transpoarency is also displayed in the UI.
 -- To regain health, the player must Collect small green boxes during the level.
 
- **GameOver:**
The player loses when he exceeds a predetermined negative height limit.

- **Win:**
Player wins when he reaches the Green block at the end of the level.

## Levels

There is only one playable level, a very difficult level to show all the mechanics. However, the prototype is prepared with a level select scene to receive as many levels as needed, just change the amount of levels in the inspector and create new levels.

## Any Questions please contact me

**Paulo Jorge Junior**
 - **E-mail:** paulojorgejunior@gmail.com
-  https://paulojjunior.com

