using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRDetector : MonoBehaviour
{
    public bool blockedLR = false;
    public bool sameTeamLR = false;

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedLR = true;
        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamLR = true;
        }
    }


    void OnTriggerStay2D(Collider2D collided)
    {

        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedLR = true;

        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamLR = true;
        }
    }

    void OnTriggerExit2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedLR = false;

        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamLR = false;
        }
    }
}
