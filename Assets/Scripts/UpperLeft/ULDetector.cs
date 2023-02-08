using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULDetector : MonoBehaviour
{
    public bool blockedUL = false;
    public bool sameTeamUL = false;

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedUL = true;
        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamUL = true;
        }
    }


    void OnTriggerStay2D(Collider2D collided)
    {

        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedUL = true;

        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamUL = true;
        }
    }

    void OnTriggerExit2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedUL = false;
        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamUL = false;
        }
    }
}
