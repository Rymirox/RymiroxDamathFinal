using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public int redChipLeft = 12;
    public int blueChipLeft = 12;

    public Transform cameraTransform;
    public Transform[] ChipSprites;

    public List<RedChip> r;
    public List<BlueChip> b;
 
    public List<BlueChip> bSwitchPicked;
    public List<RedChip> rSwitchPicked; 


    // Update is called once per frame
    void Update()
    {
        if (rSwitchPicked.Count == 2)
        {
            if (rSwitchPicked[0] == rSwitchPicked[1])
            {
                rSwitchPicked.Remove(rSwitchPicked[0]);

            }
            else
            {
                rSwitchPicked[0].Reset();
                rSwitchPicked.Remove(rSwitchPicked[0]);
            }
        }

        if (bSwitchPicked.Count == 2)
        {
            if (bSwitchPicked[0] == bSwitchPicked[1])
            {
                bSwitchPicked.Remove(bSwitchPicked[0]);

            }
            else
            {
                bSwitchPicked[0].Reset();
                bSwitchPicked.Remove(bSwitchPicked[0]);
            }
        }
    }

    public void switchTurnToBlue()
    {
        for (int i = 0; i < r.Count; i++)
        {
            r[i].redTurn = false;
        }

        for (int i = 0; i < b.Count; i++)
        {
            b[i].blueTurn = true;
            b[i].disabled = false;
            b[i].disableMove = false;
        }

        rSwitchPicked.Clear();
        cameraTransform.rotation = Quaternion.Euler(0, 0, 180);

        

        for (int i = 0; i < ChipSprites.Length; i++)
        {
            Vector3 Scaler = ChipSprites[i].localScale;
            Scaler.x *= -1;
            Scaler.y *= -1;
            ChipSprites[i].localScale = Scaler;
        }

    }

    public void switchTurnToRed()
    {
        for (int i = 0; i < r.Count; i++)
        {
            r[i].redTurn = true;
            r[i].disabled = false;
            r[i].disableMove = false;
        }

        for (int i = 0; i < b.Count; i++)
        {
            b[i].blueTurn = false;
        }

        bSwitchPicked.Clear();
        cameraTransform.rotation = Quaternion.Euler(0, 0, 0);


        for (int i = 0; i < ChipSprites.Length; i++)
        {
            Vector3 Scaler = ChipSprites[i].localScale;
            Scaler.x *= -1;
            Scaler.y *= -1;
            ChipSprites[i].localScale = Scaler;
        }
    }

    public void disableOthers()
    {
        for (int i = 0; i < r.Count; i++)
        {
            r[i].disabled = true;
        }

        for (int i = 0; i < b.Count; i++)
        {
            b[i].disabled = false;
        }
    }

    public void disableRedMoveOthers()
    {

        for (int i = 0; i < r.Count; i++)
        {
            r[i].disableMove = true;
        }

    }

    public void disableBlueMoveOthers()
    {
        for (int i = 0; i < b.Count; i++)
        {
            b[i].disableMove = true;
        }
    }

    public void enableRedMoveOthers()
    {
        for (int i = 0; i < r.Count; i++)
        {
            r[i].disableMove = false;
        }

    }

    public void enableBlueMoveOthers()
    {
        for (int i = 0; i < b.Count; i++)
        {
            b[i].disableMove = false;
        }
    }
}
