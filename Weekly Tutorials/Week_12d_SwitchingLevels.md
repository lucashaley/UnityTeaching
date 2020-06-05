# Week 12: Top-Down Shooter: Switching Levels

## PERSISTENT DATA

The previous PDF demonstrated a simple means by which we can switch from one scene
to another. The code that was provided can be readily adapted to switch scenes at any time, based on a trigger event or a keypress, for example.

But when the player completes a level with 67,003 points, two lives and the Über-Thruster
power-up, we need to begin the next level with those values in place. This involves passing
data somehow from the current scene to the next one.

So that’s the goal of this PDF. To achieve this, we’ll use Unity’s SceneManagement library and write some code that itself generates a file that contains ‘user preferences’.

UserPrefs is a broad term for settings and values (specific to the user) that are to be kept and adjusted between multiple sessions—even if the game was quitted between sessions.

**SETTING INITIAL VALUES VIA ‘PLAYERPREFS’**

We’ll start by setting up initial values in the MainMenu script (eg. starting health) that populate our existing variables in the first level. This is the first step towards making these values persistent between levels and sessions.

>Note: We should probably be putting this stuff inside a GameManager script, but for our purposes, it’ll be fine to simply add to the MainMenu script.

-	Open the **MainMenu** script that we created in the last PDF.

-	Add to the script as follows:

```C#
public class MainMenu : Monobehaviour
{
  [Header(“PUBLIC REFERENCES”)]
  public string startLevel;			// Reference name for the first level of the game

  [Header(“PERSISTENT SETTINGS”)]
  public int startLives = 123;		// Number of lives to begin the game with
  public int startScore = 123;		// Player score to begin the game with
  public int startHealth = 123;		// Health Level to begin the game with

  public void NewGame()
  {
    // This loads the first scene
    SceneManager.LoadScene(startLevel);

    // This sets the initial value of PlayerCurrentLives
    PlayerPrefs.SetInt(“PlayerCurrentLives”, startLives);

    // This sets the initial value of PlayerCurrentScore
    PlayerPrefs.SetInt(“PlayerCurrentScore”, startScore);

    // This sets the initial value of PlayerCurrentLives
    PlayerPrefs.SetInt(“PlayerCurrentHealth”, startHealth);
  }
```

>Note: On the previous page, some of the code we added applies to systems that you don’t necessarily have in place, yet (ie. score and lives). That’s okay—add all that code anyway. We’re going to create variables that can be set via  _PlayerPrefs_, which will form the starting point for those systems, should you decide to develop them later.

>Also note: We’ve also given those variables some **strange values (123)**. This is for testing purposes. When we see those values appear in our first level, we’ll know the script is working and we can then change those values to something more practical.

The _PlayerPrefs_ class allows us to store integers, floats and strings between game sessions.  So far, we’ve just used it to store those initial values in the _MainMenu_ script.

-	Save the **MainMenu** script and open your **PlayerHealth** script.

-	Add the following two variables to the **PlayerHealth** script:

```C#
[Header(“UI / SETTINGS”)]
public int lives;				      // The player’s starting number of lives
public int score;				      // The player’s starting score
public int health = 1000;			  // The player’s staring health
public Slider healthSlider;		    // Reference to the UI health bar
public int power = 1000;			   // 1. The player’s starting power - uncomment this for droid power
public Slider powerSlider;		     // 2. Reference to the UI power bar - uncomment this for droid power
public float powerEfficiency = 10.0f;  // 3. How slowly the droid loses power (higher number is slower)
```

-	Add the following to the **PlayerHealth** script’s _Start_ method:

```C#
void Start()
{
  // This sets the initial value of lives (inherited from MainMenu)
  lives = PlayerPrefs.GetInt(“PlayerCurrentLives”);

  // This sets the initial value of score (inherited from MainMenu)
  score = PlayerPrefs.GetInt(“PlayerCurrentScore”);

  // This sets the initial value of health (inherited from MainMenu)
  health = PlayerPrefs.GetInt(“PlayerCurrentHealth”);
  healthSlider.value = health; 	// This updates the healthSlider

  // This makes sure the smoke effect won’t play on start
  smokeEffect.GetComponent<ParticleSystem>().Stop();

  // Player does not start with critical damage (this is a silly line of code)
  damageCritical = false;

  // Testing
  // Debug.Log(“PowerUsage = ” + powerUsage);
}
```

-	In the **PlayerHealth** script’s  Awake  method, **delete** the line that begins with:

          •	healthSlider.value = health;

We’ve just moved that into the  **Start**  method so that it’s set after our initial values.

--------------------------------------------------------------------

## IF YOU’RE USING THE DROID POWER SYSTEM:

Repeat the above steps to set the droid’s initial power level (and ultimately store it between levels and sessions).

ie.:

-	In the **MainMenu** script, add a _startPower_ variable

- 	In the **MainMenu** script’s  _NewGame_  method, add:
```C#
// This sets the initial value of PlayerCurrentPower
PlayerPrefs.SetInt(“PlayerCurrentPower”, startPower);
```

-	**Save** this script.

-	In the **PlayerHealth** script’s  _Start_  method, add:
```C#
// This sets the initial value of power (inherited from MainMenu)						
power = PlayerPrefs.GetInt(“PlayerCurrentPower”);
powerSlider.value = power;   // This updates the powerSlider
```

-	In the  _Update_  method, in the first  if  condition
(just after the _powerSlider_ is upated), add:
```C#
PlayerPrefs.SetInt(“PlayerCurrentPower”, startPower);
```

--------------------------------------------------------------------

-	**Save** the **PlayerHealth** script and head back to **Unity**.

-	In the **MainMenu** scene, select the **MainMenuCanvas** object.

-	Check that all exposed variables in the **PERSISTENT SETTINGS** are set to **123**.
We need to do this because values in the Inspector override those in scripts.

-	Hit **Play** to test this out.

  When the first level loads, select **Player01**. If those initial values are 123, then you’ve
successfully created [and drawn from] a _PlayerPrefs_ file, through script.

-	If this works as it should, you can now adjust the values in the **Inspector** (with the
**MainMenuCanvas** object selected) to something more practical.
eg. Start Lives: 3, Start Score: 0, etc.

  You can read more about _PlayerPrefs_ on [this page](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html) of the Unity documentation.

Next, we’ll make it so that the  _PlayerPrefs_  file is updated when a life is gained or lost.

## FULL PERSISTENCE

The current goal is to make it so that the player’s values are persistent between levels.

To ensure this happens, we need to make sure the _PlayerPrefs_ file is updated every time these values change.

Once we’re done, we’ll use the health [and power] HUD to gauge whether it’s worked or not.

-	Open your **PlayerHealth** script and locate your _TakeDamage_ method.

-	Add the following lines just after health is reduced (when the player takes a hit).

```C#
public void TakeDamage(int damage)
{
  damaged = true;

  // Reduce health value
  health -= damage;

  // Update the health slider
  healthSlider.value = health;

  // Update PlayerPrefs
  PlayerPrefs.SetInt(“PlayerCurrentHealth”, health);

  // If player health is below critial damage value..
  if (health <= criticalDamageLevel)
```

-	Now we need to do the same thing when we gain health (eg. via pick-ups).

  Locate the **AddHealth** method (here in the **PlayerHealth** script) and add the following.

```C#
public void AddHealth(int healthValue)
{
  // Increase health value
  health += healthValue;

  // Update the health slider
  healthSlider.value = health;

  // Update PlayerPrefs
  PlayerPrefs.SetInt(“PlayerCurrentHealth”, health);

  // Debug.Log(“Health received from pickup: “ + healthValue);

  // If health goes above critical damage level
  if (health >= criticalDamageLevel)
  {
    // Debug
    damageCritical = false;
```

-	And we need to do the same thing when the player dies and its health is reset..

  Locate your _resetHealth_ method and add the following.

```C#
// Used after the PlayerDeath script has run
public void resetHealth()
{  
  health = startingHealth;				               // reset health
  healthSlider.value = health;				           // update health slider
  PlayerPrefs.SetInt(“PlayerCurrentHealth”, health); 	// update PlayerPrefs
  power = startingPower;					             // reset power
  powerSlider.value = power;				             // update power slider
  PlayerPrefs.SetInt(“PlayerCurrentPower”, power); 	  // update PlayerPrefs
  damagecritial = false;					             // reset critical damage
  isDead = false;					                    // lower the isDead flag
}
```

So, this should now work.. But we have some loose ends to tie up before we can test it.

First of all, after the first time the player dies, we’re drawing the player’s refreshed health value from the _PlayerHealth_ script’s initial _Health_ value (via the _startingHealth_ variable, which is set in the  **Awake**  method).

We should fix this so that when the player dies, the player’s refreshed health [and power] comes from the  _PlayerPrefs_  instead. That way, if a player begins level 2 with 63% health, and then they die on that level, they’ll go back to 63%—as though the start of the level was a checkpoint (and, indeed, this would work for checkpoints within a single level).

-	First, let’s rename startingHealth [and startingPower], because that’s misleading.

In the // **PRIVATE VARIABLES** section, **rename**  _startingHealth_  and  _startingPower_
to _resetHealthOnDeath_  and  _resetPowerOnDeath_ (respectively).

-	In the  **Awake**  method, replace these lines:

            •	startingHealth = health;
		    •	startingPower = power;

        with these lines:

```C#
void Awake()
{
  // Set up initial values
  playerController = GetComponent<PlayerControl>();
  fireProjectile = GetComponent<FireProjectile>();
  resetHealthOnDeath = PlayerPrefs.GetInt(“PlayerCurrentHealth”);
  resetPowerOnDeath = PlayerPrefs.GetInt(“PlayerCurrentPower”);
  powerUsage = (powerEfficiency / 10);
}
```

-	Finally, in the resetHealth method, replace these lines:

          •	health = startingHealth;

          •	power = startingPower;

  with these lines:

```C#
void resetHealth()
{
  health = resetHealthOnDeath;				           // reset health
  healthSlider.value = health;				           // update health slider
  PlayerPrefs.SetInt(“PlayerCurrentHealth”, health); 	// update PlayerPrefs
  power = resetPowerOnDeath;				             // reset power
  powerSlider.value = power;				             // update power slider
  PlayerPrefs.SetInt(“PlayerCurrentPower”, power); 	  // update PlayerPrefs
  damagecritial = false;					             // reset critical damage
  isDead = false;					                    // lower the isDead flag
}
```

-	Make sure all your **scripts** are **saved** and head back to **Unity**.

So now all these main values are drawn from the _PlayerPrefs_ file—which is kept up to date across the board.

True, we haven’t dealt with _Lives, Score_ or _Inventory_—but you now know how to make their values persistent, should you decide to add those systems to your game. Plus we’ve begun setting up the lives and score system already—you only need to make it so the player a) counts lives and b) is awarded points when an enemy is destroyed, for example. Just make sure that you update the _PlayerPrefs_ file wherever these values change.

Inventory can be tracked by **ints** just like we’ve done in this PDF. eg. **numberOfLandmines**; So you now have the skills to ensure the player still has that _Über-Thruster_ power-up when they start the next level.

## Switching Levels

To test this persistent system across multiple levels, we obviously need multiple levels and the means to switch between them. Perhaps your game has this, by now, in which case you can go ahead and test this system out.

But here are two suggestions as to how you might go about it.

**SUGGESTION 01**

- Give your enemies points values (the variables are already set up in the **EnemyHealth** script).

- Once you’ve added all the enemies to your level, add up the total number of points they’re
worth, for example:

  -	3 soldiers @ 50pts each = 150
  -	2 turrets @ 800pts each = 1600
  -	**Total points value = 1750**


-	In the **PlayerHealth** script, write an _AddPoints_ method that receives the points value from
dying enemies (refer to the _AddHealth_ method in the **PlayerHealth** script for cues).

-	When points are added, run a check:
```C#
  if (score >= 1750)
  {
      SceneManager.LoadScene(level02);
  }
```

**SUGGESTION 02**

-	Use a trigger zone at the end of your level that the player must reach, having destroyed slews of bad guys.

-	In a _TriggerScript_, call the scene change (as above) via an _OnTriggerEnter_ method.

**REMEMBER:** If you want to use **SceneManager**, you need to add:
```C#
using UnityEngine.SceneManagement;  
```
at the top of your script.

Here’s an example trigger script:

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RiviaGeraltOf
{
  public class EndLevel01Trigger : Monobehaviour
  {
    public string level02;				          // Reference name for the second level of the game

    private void OnTriggerEnter(Collider other)
    {
      // Testing
      Debug.Log(“Trigger triggered”);

      if(other.gameObject.tag == “Player”)		  // Make sure only the player can trigger level change
      {
        // Testing
        Debug.Log(“Player detected”);

        // Load level 2
        SceneManager.LoadScene(level02);
      }
    }
  }
}
```

**REMEMBER:** You need to copy the name of the second level and paste it into the empty
**level02** field in the **Inspector**.

In order to switch levels, each target level needs to be represented in the game’s build settings.

-	Open the scene that you wish to use as your second level.

-	In the top menu bar, go to **File » Build Settings**.

-	Hit **Add Open Scenes**.

-	If your **MainMenu** isn’t in this list, open ithat scene and add it in the same way.

  This is important for when you build your game.

-	If your scenes aren’t in order, drag them up and down so that **MainMenu** is on top and the
levels number off sequentially thereafter.

-	Close the window. You should now be able to switch to level 2.

## TESTING PERSISTENCE

Once you’re able to switch between scenes, you can test the persistence of your player’s values. To see if it’s working:

-	Start a new game from the **MainMenu** scene.

-	Take some damage from the enemy—enough to be obvious.

-	Let your power run down—again, make it an obvious change from its starting value.

-	Do whatever you need to do in order to switch levels.

  Hopefully, those values are still in place!

  If not, go back over this PDF and check that you didn’t miss anything.. those Gets and Sets
look awfully similar..
