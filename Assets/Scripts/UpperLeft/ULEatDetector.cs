using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULEatDetector : MonoBehaviour
{
    public bool eatBlockedUL = false;


    void OnTriggerEnter2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedUL = true;
        }


    }

    void OnTriggerStay2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedUL = true;
        }


    }

    void OnTriggerExit2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedUL = false;
        }


    }
}
