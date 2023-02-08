using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URDetector : MonoBehaviour
{
    public bool blockedUR = false;
    public bool sameTeamUR = false;

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedUR = true;
        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamUR = true;
        }
    }

    void OnTriggerStay2D(Collider2D collided) 
    {

        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedUR = true;

        }
        
        if (collided.tag == gameObject.tag)
        {
            sameTeamUR = true;
        }
        

    }

    void OnTriggerExit2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueChip") || collided.CompareTag("RedChip"))
        {
            blockedUR = false;

        }

        if (collided.tag == gameObject.tag)
        {
            sameTeamUR = false;
        }
    }
}
