using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSDetector : MonoBehaviour
{
    public MainGameManager MGManager;
    public BlueChip blueChipCode;
    public Transform[] TPLocation;

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.CompareTag("BlueDamaDetector"))
        {
            blueChipCode.dama = true;
        }

        if ((collided.CompareTag("RedChip")) && (blueChipCode.isEatingToLL || blueChipCode.isEatingToLR || blueChipCode.isEatingToUL || blueChipCode.isEatingToUR))
        {
            RedChip redChipCode = collided.transform.parent.GetComponent<RedChip>();
            if (redChipCode != null)
            {
                redChipCode.removeMeToR();
                redChipCode.destroyMe();
                collided.transform.parent = null;
            }
            MGManager.redChipLeft--;
            collided.transform.position = TPLocation[0].position;
        }

    }
}
