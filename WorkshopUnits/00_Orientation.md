# Unit 00: Orientation

## Introduction

For this course, we'll be taking a dive into Unity as a game development platform. We'll be making a top-down shooter game over the next 12 weeks.

> This first unit will be light on information, as the majority of content is better presented in-person in the workshop. This document will help as a reminder.

## Goal

The goal of this unit is to become familiar with the Unity workspace and usage. These are fundamental skills that will be carried throughout the rest of the course and onwards.

## Process

### Opening Unity

Unity gets updated frequently, and often the different versions can have quite large codebase differences. To avoid issues with breaking code with updating, Unity has a separate application called Unity Hub that allows users to install different versions, and open projects in the correct versions.

![Unity Hub](images/00_UnityHub.png)

Open Unity Hub from the Start menu, and create a new project using version [[NEED VERSION FROM ITS]].

From the selection of templates, choose the "Massey" template, and let Unity open.

### The User Interface

![Unity Interface](images/00_UnityInterface.png)

#### UI panels

1. Scene

    This is where you can manipulate objects in a 3d space.

2. Project

    These are all of the assets available in your project.

3. Heirarchy

    These are the assets/GameObjects that are currently in your scene.

4. Inspector

    This is a contextual panel, allowing you to manipulate the currently selected objects.

5. Game

    Behind the Scene panel is the Game panel, which shows what your game actually looks like during play.

6. Playmode

    The play button starts and stops the game.

> Pay attention to this button -- it acts as a toggle, so to stop the game you must push the Play button again. The Pause button is used during debugging.

> Remember that any changes you make while the game is in the play mode will not be saved when you exit the play mode.

### Moving around the scene

You'll need to be able to move around in the 3d space of the scene. If you've used other 3d applications (Maya, etc.), this should be familiar.

The **Q** key activates the Hand tool, which allows you to pan around in the scene. Holding down the **Alt/Option** key while using this tool allows you to rotate the scene.

You can also activate this same functionality by holding down the **Alt/Option** key, which puts you into the scene rotate mode. You can add the **Control/Command** key to pan.

If you're familiar with wasd-style games, you can also get around that way. Hold down the **right mouse button**, and use **WASD** to move around and the mouse to rotate. **Q** and **E** move you down and up. Holding **Shift** speeds up the camera.

## Focusing

You can focus on an object by either double-clicking it in the Hierarchy, or by selecting it in the Scene and hitting the **F** key. This also makes the scene rotate around that object.

## Wrap-Up

You should get as comfortable as possible in navigating around the Unity Scene. Keep exploring and trying different key strokes.

## Further Material

- [Unity Manual: Navigating](https://docs.unity3d.com/Manual/SceneViewNavigation.html)