using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UREatDetector : MonoBehaviour
{
    public bool eatBlockedUR = false;

    void OnTriggerEnter2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
           eatBlockedUR = true;
        }

    }

    void OnTriggerStay2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedUR = true;
        }

    }

    void OnTriggerExit2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedUR = false;
        }

    }
}
