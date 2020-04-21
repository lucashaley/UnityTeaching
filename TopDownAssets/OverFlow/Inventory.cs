using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("INVENTORY ITEMS")]
    public int bullets = 1000;
    public int proximityMines = 3;
    public int timeBombs = 3;

    [Header("UI")]
    public Image mineImage01;
    public Image mineImage02;
    public Image mineImage03;

    // Start is called before the first frame update
    void Update()
    {

    }

    public void useMine()
    {
        // decrement the value of proximityMines
        proximityMines--;

        if (proximityMines == 3)
        {
            mineImage01.gameObject.SetActive(true);
            mineImage02.gameObject.SetActive(true);
            mineImage03.gameObject.SetActive(true);

            // Tell FireProjectile script that player has mines to place
            gameObject.GetComponent<FireProjectile>().PlayerHasMinesTrue();
        }

        if (proximityMines == 2)
        {
            mineImage01.gameObject.SetActive(false);
            mineImage02.gameObject.SetActive(true);
            mineImage03.gameObject.SetActive(true);

            // Tell FireProjectile script that player has mines to place
            gameObject.GetComponent<FireProjectile>().PlayerHasMinesTrue();
        }

        if (proximityMines == 1)
        {
            mineImage01.gameObject.SetActive(false);
            mineImage02.gameObject.SetActive(false);
            mineImage03.gameObject.SetActive(true);

            // Tell FireProjectile script that player has mines to place
            gameObject.GetComponent<FireProjectile>().PlayerHasMinesTrue();
        }

        if (proximityMines == 0)
        {
            mineImage01.gameObject.SetActive(false);
            mineImage02.gameObject.SetActive(false);
            mineImage03.gameObject.SetActive(false);

            // Tell FireProjectile script that player has NO mines to place
            gameObject.GetComponent<FireProjectile>().PlayerHasMinesFalse();
        }
    }

    public void getMine()
    {
        // increment the value of proximityMines
        proximityMines++;
    }
}
