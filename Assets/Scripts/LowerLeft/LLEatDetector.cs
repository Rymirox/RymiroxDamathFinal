using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLEatDetector : MonoBehaviour
{
    public bool eatBlockedLL = false;

    void OnTriggerEnter2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedLL = true;
        }

    }

    void OnTriggerStay2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedLL = true;
        }

    }

    void OnTriggerExit2D(Collider2D collided)
    {

        if (collided.CompareTag("RedChip") || collided.CompareTag("BlueChip"))
        {
            eatBlockedLL = false;
        }

    }

}
