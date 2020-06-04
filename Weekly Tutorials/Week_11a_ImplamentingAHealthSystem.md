# Week 11: Top-Down Shooter: upgrading Line renderer & Enemy Bullets

## LINE RENDERER MKII



- 	Download the **LineRendererMaterialMkII** package from **Stream**.

-	Once you’ve imported the package, go into your **Materials** folder and locate the
**lineRendererMaterialMk2** material. It should be in a new materials folder (called _LineRenderer_).
-	Select the player’s **ProjectileOrigin** in the **Hierarchy** and expand the **Materials** dropdown in t
- Replace the **Element 0** material with the new **Mk2** version.
-	Hit **Play** to test it out. It should fade in more subtly, like this:

 ![Rectangle_60536.png](images/Rectangle_60536.png)




# ENEMY BULLET MKII



-	Download the **EnemyBullet** and **PlayerHealth** scripts from the **Stream** assets and import t




>Also note: Our project now has lots of scripts.. it’s a good idea to make folders to organise these. eg. Enemy, Player, Gadgets, Cameras and Utility (for scripts like ObjectExpiry).

- 	Open the new scripts and add your **namespace** (if you’re using namespaces in your project).

-	Select the **TurretBullet** (in the your **Prefabs** folder) and remove the **TurretBullet** script
componn.
- Replace it with the new **EnemyBullet** script.
-	In the **Enemy Bullet** script component, check **Is Turret Ammo**.


![Rectangle_62456.png](images/Rectangle_62456.png)

You can add to this script for as many different enemies as you have in your game.

-	You can test it out, but you’ll notice no immediate change. This was just in preparation for what comes next.