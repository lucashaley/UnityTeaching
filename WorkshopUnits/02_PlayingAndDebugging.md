# Unit 02: Playing and Debugging <!-- omit in toc -->

- [Introduction](#introduction)
- [Goal](#goal)
- [Process](#process)
  - [Playing the game](#playing-the-game)
  - [Editing during play](#editing-during-play)
  - [Debugging using the console](#debugging-using-the-console)
- [Wrap-Up](#wrap-up)
- [Further Material](#further-material)

## Introduction

Games are meant to be played! So, as developers, we need to play our games. But we also need to be able to figure out the problems in our games –– to test and "debug" them. This unit is all about testing and debugging.

## Goal

The goal of this unit to to try the Unity play mode, and learn different techniques and issues around debugging our work. To do so, we'll also create our first script.

## Process

### Playing the game

As we saw in [Unit 00](00_Orientation.md), Unity has a **Playmode** toggle at the center top of the user interface:

![Playmode Toggle](images/02_PlaymodeToggle.png)

1. Press the Play button. Note that it turns blue, the UI darkens, and focus automatically switches to the **Game** panel.

![Playmode On](images/02_PlaymodeOn.png)

2. Select the `FirstCube` from the Heirarchy panel. Note that the inspector panel changes to show the Cube properties.
3. Change the Position values to zero, and note how the cube centers on the Game panel screen.
4. Click on the Position's X label, and drag left and right. Note how the cube moves left and right. Make sure to check how your position values change in the Inspector.

> Note how when Playmode is on, you **cannot** select anything in the Game panel.

5. To exit the Playmode, click on the blue Play button.

> Note that this button is a *toggle*, which means the same buttons turns it on and off. We'll see what the Pause button does shortly.

6. With the Playmode turned off, note how the Position values for the cube return to the pre-play values.

> When the Playmode is on, any edits you make to variables *do not get saved* when you turn the Playmode off. Remember this!

### Editing during play

As we saw in the last section, you can edit most of the values for objects during play. This is a critical element to game development –– playtesting. No game ever was made perfectly on the first pass. Playing, tweaking, playing again.

When we start making our game elements, we'll be tweaking speeds, damage, mass, etc. using this mode.

And remember that the values aren't saved, so make sure you've got a pad of paper nearby!

### Debugging using the console

Now we'll take a look at how we can use testing to track our scripts and discover errors in our code. We'll be making our first script!

> If you've never coded before, *do not worry*. We'll be going pretty slowly. Ask for help if you need it –– that's why we're here!

## Wrap-Up

## Further Material