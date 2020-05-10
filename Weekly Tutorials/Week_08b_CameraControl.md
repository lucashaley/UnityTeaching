# Week 08: Top-Down Shooter: Camera Control

## Introduction

This week, we’re focusing on firing projectiles. But before we get into that, we should set up the camera to follow the player. We’ll also quickly add a cardboard box prop to shoot at while we wait for some enemies to turn up.

## Set up the camera follow

- Download this week’s assets from Stream - put them in a temporary folder to draw from as
you follow along with the PDF.
- In Unity, make a new subfolder in your **Scripts** folder called **Cameras**.
- Import the **TopDownCam** script to your **Cameras** folder.
(Right click in folder » Import Assets or simply drag them in from your OS file browser).
- Select your main camera in the Hierarchy (eg. CameraTopDown) and attach to it the
appropriate script as a component (eg. TopDownCam).
- With your main camera selected in the Hierarchy, drag Player01 into the empty Player
Position field in the new Script component. (this is a public variable of type `Transform` that
has been exposed in the Inspector).
- Hit Play to test it out. The camera should now follow your Player01 character.

> Notice also that the camera eases in to the player’s position with a slight delay. You can adjust the feel of this via the `Dampening` parameter.

- Open the script to learn more about how this achieved — and add your namespace.
