# Week 06: Top-Down Shooter

## Introduction

In this series of workshops, you’ll be building a top-down or isometric shooter game. Notable differences to your Myst-like / Island game include:

- 2.5D or isometric graphics
- A follow-cam
- AI agents
- Navigation mesh that allow the bad guys to chase you around corners
- projectiles
- health and damage, including user interface
- and a greater emphasis on hand-eye coordination and reaction-based gameplay

### Group Work

For this project, you are encouraged to work in pairs. Two people is the default number of people per team.

In certain circumstances, you may work solo or in a group of three—but these arrangements are to made by special negotiation with your tutor. All partners need to be in your own workshop.

We suggest you try to work with someone that has complimentary skills to your own. For example, if you love your coding, find an artist who focuses on environment and props. If you love your modeling and animation and want to focus on that, you may be able to form a group of 3.

As before - (but this time, with stricter adherence) - we’ll run to concurrent projects.

1. SOLO WORKSHOP PROJECT

    - keep this safe and backed up on your Media Server drive
    - add to it each week
    - use this project for experimentation

2. GROUP ASSIGNMENT PROJECT

   - Worked on by both team members
   - Each member is expected to give 7 hours of self-directed time to the project per week. ie. a pair will contribute 14 hours to each project per week as ‘homework’.
   - The final project should look like 70 hours of work in total.

### Initial Assets

You’ll find a range of initial assets on Stream. Download all of those now and let’s make a start on our workshop projects.

## Set Up

1. Create a project in the regular way

![Unity create dialog](images/week06_create.png)

2. Once Unity has loaded, in the Assets root folder, create a **TopDownShooter** folder, and 10 new folders and name them as follows:
- TopDownShooter
    - Audio
    - Effects
    - Fonts
    - Images
    - Materials
    - Models
    - Prefabs
    - Scenes
    - Scripts
    - Textures

> Pay careful attention to capitalisation and spelling.

![Initial folder setup](images/week06_folders.png)

3. Import the TopDownShooter_Assets.unitypackage from the Stream site.

> Note how your assets are placed into the correct folders.

4. In the top file menu Save As and call the scene *Level00_00*.

> Make sure it’s saved to the **TopDownShooter>Scenes** folder.

![Initial folder setup](images/week06_saveScene.png)

## Create a Player01 Material

- Go to your Materials and creat a subfolder (alongside Basic) called Characters.
- Inside that folder, right click and Create » Material.
Call it Player01Mat.
- Select DroidModel in the Hierarchy, look over in the Inspector and make sure the Materials dropdown is expanded.
- Hit the Element 0 circle selector &#10687; and choose **Player01Mat** from the material options. This way we can observe changes in the model as we build that material.
- Select Player01Mat in its folder in the Project tab, and look to the Inspector.
- Hit the **Albedo** circle selector and choose the green Player01_1001_BaseColor texture. The model should now have a basic paint-job in the Scene window.
- Hit the **Metallic** circle selctor and choose the black Player01_1001_Metallic texture. The model should now have a reflective gun barrel and base.
- Hit the Normal Map circle selector and choose the purple Player01_1001_Normal texture. This will have very little effect, in this case, but can have a profound effect in some cases. Low-poly rocks, for example, can suddenly look photorealistic at this point.
- You should now have something like this in your Scene view:

![Finished player material](images/week06_playerMaterial.png)

## Create a Player01 Prefab
> Unity has a Prefab asset type that allows you to store a GameObject object complete with its components and properties. The prefab acts as a template from which you can create new object instances in the scene. Any edits made to a prefab asset are immediately reflected in all instances produced from it but you can also override components and settings for each instance individually.

- Simply drag the Player01 (Parent) GameObject from the **Hierarchy** into your **Prefabs** folder.

> Now, changes made to Player01 (and applied) in this scene will cascade throughout all instances of Player01 in your project. We’ll learn more about Prefabs soon.

## Add the Ground

- Create a new Cube GameObject and call it Ground
- Manually enter its Transform values as follows:

![Ground transform settings](images/week06_groundTransform.png)

- Go to your Materials folder and drag the YellowDark material out and drop it on the cube to set this as its material.

## Check Player Transform

- Before we move on, double-check that both the **Droid** and **Player01** GameObjects in the Project tab each have their transform settings set like this:

![Player transform settings](images/week06_playerTransform.png)

The droid should be sitting on the Ground cube neatly like this:

![Player sitting nicely](images/week06_playerSitting.png)

## Setting up the Camera

> PLEASE NOTE: in the PDF it has information about using an isometric view. We are not allowing that view, as it causes too many issues than it offers benefits.

- Rename your **Main Camera** in the Hierarchy to **CameraTopDown**.
- Select CameraTowpDown.
- Set its Transform properties as follows:

![Camera transform settings](images/week06_cameraTransform.png)

- In the Camera component (in the Inspector), switch the Projection method from Perspective to Orthographic.
- Adjusting the Size property effectively adjusts the camera’s Field of View. Tweak this value to achieve a good frame on your player and its surroundings. I recommend a value of about 6.

> You can see in the Camera Preview insert (in the Viewport) what this looks like. Testing your game will obviously give you an even better idea of how this looks.

- Drag the camera into your **Prefabs** folder to save it as a prefab.
- Save your scene

## Listening for Input

> The Unity **InputManager** allows the developer to define the project’s various input axes and actions.

- Via the top menu bar, go to **Edit » Project Settings**
- In the Inspector, choose **Input Manager**.

![Input Manager](images/week06_inputManager.png)

> This is the InputManager. If you expand the Horizontal and Vertical dropdowns, you can see that horizontal input is made via the ← and → arrow keys as well as A and D—while vertical input is made via the ↑ and ↓ arrow keys as well as W and S.

> In our previous project, we used an existing script to control our character.
This time, we’ll be making our own.

> Let’s being by getting our game to listening for user input, so that we can move our character.

- In your Scripts folder, create a new C# script and call it PlayerControl.
- Add your namespace.
- Attach the script to the **Player01** GameObject (as a component in the Inspector).
- Adjust and add to the script as follows:

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucasHaley
{
  public class PlayerControl : MonoBehaviour
  {
    // Update gets called once per frame
    void Update ()
    {
      // This declares a private variable of type 'float', names
      // it 'vertical' and get the vertical axis values, i.e.
      // up and down arrows or w and s keys
      float vertical = Input.GetAxis("Vertical");

      // if vertical DOES NOT equal zero (as a float)
      if (vertical != 0f)
      {
        // Test for input
        Debug.Log("Vertical value: " + vertical);
      }
    }
  }
}
```

- Save the script and test the game. Any vertical input (up/down cursor keys, W/S keys, analog sticks, etc.) will log a vertical value between -1 and 1.
- Now, edit the above code so that, *instead of printing out the values in the console*, the vertical input value is instead added to the Player’s current Z-position – ie. makes Player01 move. Begin by ‘commenting out’ the Debug.Log we wrote, and adding the following line:

```
      // Test for input
      // Debug.Log("Vertical value: " + vertical);
      transform.position += Vector3.forward * vertical;
```

- Save the script and test it out. The player character should now move along the Z axis when vertical input is received.

> Note: This approach will prove a little problematic once obstacles are added to the scene—but we’ll leave it like this for now.

- Save your project.
