using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpritesDetector : MonoBehaviour
{
    public MainGameManager MainGManager;
    public RedChip redChipCode;
    public Transform[] BlueTPLocation;

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.CompareTag("RedDamaDetector"))
        {
            redChipCode.dama = true;
        }

        if ((collided.CompareTag("BlueChip")) && (redChipCode.isEatingToUL || redChipCode.isEatingToUR || redChipCode.isEatingToLR || redChipCode.isEatingToLL))
        {
            BlueChip blueChipCode = collided.transform.parent.GetComponent<BlueChip>();

            if (blueChipCode != null)
            {
                blueChipCode.removeMeToB();
                MainGManager.blueChipLeft--;
                blueChipCode.destroyMe();
                collided.transform.parent = null;

            }

            collided.transform.parent.transform.position = BlueTPLocation[MainGManager.redChipLeft].position;

        }

    }
}

