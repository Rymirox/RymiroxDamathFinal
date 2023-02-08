using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLDetector : MonoBehaviour
{
    public bool blockedLL = false;
    public bool sameTeamLL = false;

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedLL = true;
        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamLL = true;
        }
    }

    void OnTriggerStay2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedLL = true;
        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamLL = true;
        }
    }

    void OnTriggerExit2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedLL = false;

        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamLL = false;
        }
    }
}
