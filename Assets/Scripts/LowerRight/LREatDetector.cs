using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LREatDetector : MonoBehaviour
{
    public bool eatBlockedLR = false;

    void OnTriggerEnter2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedLR = true;
        }


    }

    void OnTriggerStay2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedLR = true;
        }


    }

    void OnTriggerExit2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
           eatBlockedLR = false;
        }

    }
}
