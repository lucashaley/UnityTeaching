# Unit 08: Audio  <!-- omit in toc -->

<!-- TOC START min:2 max:4 link:true asterisk:false update:true -->
- [Introduction](#introduction)
- [Goal](#goal)
- [Process](#process)
  - [Sourcing the audio](#sourcing-the-audio)
  - [Importing the audio](#importing-the-audio)
- [Wrap-Up](#wrap-up)
- [Further Material](#further-material)
<!-- TOC END -->

## Introduction

In this unit we will integrate audio into our game. Boom!

There are two (2) main kinds of audio in games: **diegetic** and **non-diegetic**.

Diegetic audio is audio that occurs within the game world itself. This could be explosions, creature roars, dialogue, and the like: anything that, if you were in the narrative, you could hear.

Non-diegetic audio happens *outside* of the narrative. A soundtrack, for example, can be heard by the human player, but probably not the character they are playing.

The way audio works in Unity is through 3d simulation. You can have an **AudioSource**, which generates audio at a particular location, and an **AudioListener**, which hears audio at a particular location. Unity then *attenuates* the audio by distance, making far sounds quieter. So if the AudioSource and AudioListener are far apart, the audio heard will be quite quiet. In addition, you can also create stereo (left/right) effects.

## Goal

The goal of this unit is to create diegetic and non-diegetic audio.

## Process

### Sourcing the audio

There are plenty of places to get free sound effects (see below for some). When you're grabbing files, make sure it's in one of these formats:

| Format | Extensions |
|---     |            |
| MPEG layer 3 | .mp3 |
| Ogg Vorbis | .ogg |
| Microsoft Wave | .wav |
| Audio Interchange File Format | .aiff / .aif |
| Ultimate Soundtracker module | .mod |
| Impulse Tracker module | .it |
| Scream Tracker module | .s3m |
| FastTracker 2 module | .xm |

And pay attention to any licenses for attribution crediting.

For this project, we have supplied a couple of files you can use:

- Gun shot

### Importing the audio


## Wrap-Up

## Further Material
