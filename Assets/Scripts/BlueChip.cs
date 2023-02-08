using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueChip : MonoBehaviour
{
    public ScoreBoard SBCode;
    public MainGameManager MGManager;

    public bool blueTurn;
    public bool disabled = false;
    public bool disableMove = false;

    public bool isMovingToUL = false;
    public bool isMovingToUR = false;
    public bool isMovingToLL = false;
    public bool isMovingToLR = false;

    public bool isEatingToUL = false;
    public bool isEatingToUR = false;
    public bool isEatingToLL = false;
    public bool isEatingToLR = false;


    //Availability in moving (We set that we cannot move in the beginning of the game unless we select a chip.)
    public bool okToMoveUL = false;
    public bool okToMoveUR = false;
    public bool okToMoveLL = false;
    public bool okToMoveLR = false;

    //Availability in eating (We set that we cannot move in the beginning of the game unless we select a chip.)
    public bool okToEatUL = false;
    public bool okToEatUR = false;
    public bool okToEatLL = false;
    public bool okToEatLR = false;

    //For highlight of the selected chip (No highlighted as default unless we select a chip.)
    public bool onHighlight = false;

    //Checking for blocked chip when moving (We set as no chip blocked in the beginning of the game.)
    public LLDetector LLMD;
    public LRDetector LRMD;
    public URDetector URMD;
    public ULDetector ULMD;

    //For dama (Normal chip first as default in the game.)
    public bool dama = false;

    //Checking for blocked chip when eating (We set as no chip blocked in the beginning of the game.)
    public LLEatDetector LLED;
    public LREatDetector LRED;
    public UREatDetector URED;
    public ULEatDetector ULED;

    //Setting the Gameobject
    //MovePlate
    public GameObject upperLeftMP;
    public GameObject upperRightMP;
    public GameObject lowerLeftMP;
    public GameObject lowerRightMP;
    //Eat Plate
    public GameObject upperLeftEP;
    public GameObject upperRightEP;
    public GameObject lowerLeftEP;
    public GameObject lowerRightEP;
    //Highlight
    public GameObject highlight;

    //Getting the location of Move/Eat Plates
    public Transform uLLocation;
    public Transform uRLocation;
    public Transform lLLocation;
    public Transform lRLocation;
    public Transform eatURLocation;
    public Transform eatULLocation;
    public Transform eatLLLocation;
    public Transform eatLRLocation;

    private Vector2 uLLastLocation;
    private Vector2 uRLastLocation;
    private Vector2 lLLastLocation;
    private Vector2 lRLastLocation;
    private Vector2 eatULLastLocation;
    private Vector2 eatURLastLocation;
    private Vector2 eatLLLastLocation;
    private Vector2 eatLRLastLocation;

    public float moveSpeed;
    public float eatSpeed;

    //Checking if picked
    public bool picked = false;

    // int 
    public int ownChipPoints;
    private int nothingToEat;

    void Start()
    {
        setLastLocation();
    }


    //We are setting each plate to be active or not by the conditions stated in the if statements.
    void Update()
    {
        if (isMovingToUL == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, uLLastLocation, moveSpeed * Time.deltaTime);
            Reset();

            if (transform.position.x == uLLastLocation.x && transform.position.y == uLLastLocation.y)
            {
                isMovingToUL = false;
                setLastLocation();
                MGManager.switchTurnToRed();

            }
        }

        if (isMovingToUR == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, uRLastLocation, moveSpeed * Time.deltaTime);
            Reset();

            if (transform.position.x == uRLastLocation.x && transform.position.y == uRLastLocation.y)
            {
                isMovingToUR = false;
                setLastLocation();
                MGManager.switchTurnToRed();

            }
        }

        if (isMovingToLL == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, lLLastLocation, moveSpeed * Time.deltaTime);
            Reset();

            if (transform.position.x == lLLastLocation.x && transform.position.y == lLLastLocation.y)
            {
                isMovingToLL = false;
                setLastLocation();
                MGManager.switchTurnToRed();

            }
        }

        if (isMovingToLR == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, lRLastLocation, moveSpeed * Time.deltaTime);
            Reset();

            if (transform.position.x == lRLastLocation.x && transform.position.y == lRLastLocation.y)
            {
                isMovingToLR = false;
                setLastLocation();
                MGManager.switchTurnToRed();

            }
        }

        if (isEatingToUL == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, eatULLastLocation, eatSpeed * Time.deltaTime);
            Reset();

            if (transform.position.x == eatULLastLocation.x && transform.position.y == eatULLastLocation.y)
            {
                isEatingToUL = false;
                setLastLocation();
                CheckAgain();
                

            }
        }

        if (isEatingToUR == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, eatURLastLocation, eatSpeed * Time.deltaTime);
            Reset();

            if (transform.position.x == eatURLastLocation.x && transform.position.y == eatURLastLocation.y)
            {
                isEatingToUR = false;
                setLastLocation();
                CheckAgain();


            }
        }

        if (isEatingToLR == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, eatLRLastLocation, eatSpeed * Time.deltaTime);
            Reset();

            if (transform.position.x == eatLRLastLocation.x && transform.position.y == eatLRLastLocation.y)
            {
                isEatingToLR = false;
                setLastLocation();
                CheckAgain();


            }
        }

        if (isEatingToLL == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, eatLLLastLocation, eatSpeed * Time.deltaTime);
            Reset();

            if (transform.position.x == eatLLLastLocation.x && transform.position.y == eatLLLastLocation.y)
            {
                isEatingToLL = false;
                setLastLocation();
                CheckAgain();

            }
        }

        if (LLMD.blockedLL == false)
        {
            okToMoveLL = true;
        }
        else
        {
            okToMoveLL = false;
        }

        if (LRMD.blockedLR == false)
        {
            okToMoveLR = true;
        }
        else
        {
            okToMoveLR = false;
        }

        if ((URMD.blockedUR == true) && (URED.eatBlockedUR == false) && (URMD.sameTeamUR == false))
        {
            okToEatUR = true;
            MGManager.disableBlueMoveOthers();
        }
        else
        {
            okToEatUR = false;
        

        }

        if ((ULMD.blockedUL == true) && (ULED.eatBlockedUL == false) && (ULMD.sameTeamUL == false))
        {
            okToEatUL = true;
            MGManager.disableBlueMoveOthers();
        }
        else
        {
            okToEatUL = false;
        }

        if ((LLMD.blockedLL == true) && (LLED.eatBlockedLL == false) && (LLMD.sameTeamLL == false))
        {
            okToEatLL = true;
            MGManager.disableBlueMoveOthers();
        }
        else
        {
            okToEatLL = false;
        

        }

        if ((LRMD.blockedLR == true) && (LRED.eatBlockedLR == false) && (LRMD.sameTeamLR == false))
        {
            okToEatLR = true;
            MGManager.disableBlueMoveOthers();
        }
        else
        {
            okToEatLR = false;
     
        }

        if (dama == true)
        {
            if (ULMD.blockedUL == false)
            {
                okToMoveUL = true;
            }
            else
            {
                okToMoveUL = false;
            }
            if (URMD.blockedUR == false)
            {
                okToMoveUR = true;
            }
            else
            {
                okToMoveUR = false;
            }

        }


    }

    //Once the chip is being selected, these are the code that checks if it is ok to move or eat then by the stated conditions (Blocking).

    public void Selected()
    {
        if (blueTurn == true)
        {
            onHighlight = !onHighlight;
            picked = !picked;
            MGManager.bSwitchPicked.Add(this);

            //Highlight
            if (onHighlight == true)
            {
                highlight.SetActive(true);
            }
            else
            {
                highlight.SetActive(false);
            }

            //Disabling Move
            if (disableMove == false)
            {
                //Moving
                if (okToMoveUL == true && picked == true)
                {
                    upperLeftMP.SetActive(true);
                }
                else if (okToMoveUL == true && picked == false)
                {
                    upperLeftMP.SetActive(false);
                }

                if (okToMoveUR == true && picked == true)
                {
                    upperRightMP.SetActive(true);
                }
                else if (okToMoveUR == true && picked == false)
                {
                    upperRightMP.SetActive(false);
                }

                if (okToMoveLL == true && picked == true)
                {
                    lowerLeftMP.SetActive(true);
                }
                else if (okToMoveLL == true && picked == false)
                {
                    lowerLeftMP.SetActive(false);
                }

                if (okToMoveLR == true && picked == true)
                {
                    lowerRightMP.SetActive(true);
                }
                else if (okToMoveLR == true && picked == false)
                {
                    lowerRightMP.SetActive(false);
                }
            }

            //Eating
            if (okToEatUR == true && picked == true)
            {
                upperRightEP.SetActive(true);
            }
            else if (okToEatUR == true && picked == false)
            {
                upperRightEP.SetActive(false);
            }

            if (okToEatUL == true && picked == true)
            {
                upperLeftEP.SetActive(true);
            }
            else if (okToEatUL == true && picked == false)
            {
                upperLeftEP.SetActive(false);
            }

            if (okToEatLL == true && picked == true)
            {
                lowerLeftEP.SetActive(true);
            }
            else if (okToEatLL == true && picked == false)
            {
                lowerLeftEP.SetActive(false);
            }

            if (okToEatLR == true && picked == true)
            {
                lowerRightEP.SetActive(true);
            }
            else if (okToEatLR == true && picked == false)
            {
                lowerRightEP.SetActive(false);
            }
        } 
    }

    public void destroyMe()
    {
        Destroy(gameObject);
    }

    public void setLastLocation()
    {
        uLLastLocation = new Vector2(uLLocation.position.x, uLLocation.position.y);
        uRLastLocation = new Vector2(uRLocation.position.x, uRLocation.position.y);
        lLLastLocation = new Vector2(lLLocation.position.x, lLLocation.position.y);
        lRLastLocation = new Vector2(lRLocation.position.x, lRLocation.position.y);
        eatULLastLocation = new Vector2(eatULLocation.position.x, eatULLocation.position.y);
        eatURLastLocation = new Vector2(eatURLocation.position.x, eatURLocation.position.y);
        eatLLLastLocation = new Vector2(eatLLLocation.position.x, eatLLLocation.position.y);
        eatLRLastLocation = new Vector2(eatLRLocation.position.x, eatLRLocation.position.y);
    }

    //This function resets all of the variable for checking for the availibility to move/ eat and for checking the blocked chip.

    public void Reset()
    {
        upperLeftMP.SetActive(false);
        upperRightMP.SetActive(false);
        lowerLeftMP.SetActive(false);
        lowerRightMP.SetActive(false);
        upperLeftEP.SetActive(false);
        upperRightEP.SetActive(false);
        lowerLeftEP.SetActive(false);
        lowerRightEP.SetActive(false);
        highlight.SetActive(false);
        picked = false;
        onHighlight = false;
        disabled = false;
        nothingToEat = 0;
    }


    public void removeMeToB()
    {
        MGManager.b.Remove(this);
    }



    ///Move
    //Function when moving to the Upper Left.
    public void MoveToUL()
    {
        if (okToMoveUL == true)
        {
            isMovingToUL = true;

        }
    }

    //Function when moving to the Upper Right.
    public void MoveToUR()
    {
        if (okToMoveUR == true)
        {
            isMovingToUR = true;
        }
    }

    //Function when moving to the Lower Left.
    public void MoveToLL()
    {
        if (okToMoveLL == true)
        {
            isMovingToLL = true;

        }
    }

    //Function when moving to the Lower Right.
    public void MoveToLR()
    {
        if (okToMoveLR == true)
        {
            isMovingToLR = true;
        }
    }

    //Eat
    //Function when eating to the Upper Right.
    public void EatToUR()
    {
        if (okToEatUR == true)
        {
            isEatingToUR = true;
        }
    }

    //Function when eating to the Upper Left.
    public void EatToUL()
    {
        if (okToEatUL == true)
        {
            isEatingToUL = true;
        }
    }

    //Function when eating to the Lower Left
    public void EatToLL()
    {
        if (okToEatLL == true)
        {
            isEatingToLL = true;
        }
    }

    //Function when eating to the Lower Right
    public void EatToLR()
    {
        if (okToEatLR == true)
        {
            isEatingToLR = true;
        }
    }

    public void CheckAgain()
    {
        if (okToEatUL == true)
        {
            upperLeftEP.SetActive(true);
            MGManager.disableOthers();
        }
        else
        {
            nothingToEat++;
        }
        if (okToEatUR == true)
        {
            upperRightEP.SetActive(true);
            MGManager.disableOthers();
        }
        else
        {
            nothingToEat++;
        }
        if (okToEatLL == true)
        {
            lowerLeftEP.SetActive(true);
            MGManager.disableOthers();
        }
        else
        {
            nothingToEat++;
        }
        if (okToEatLR == true)
        {
            lowerRightEP.SetActive(true);
            MGManager.disableOthers();
        }
        else
        {
            nothingToEat++;
        }
        if (nothingToEat == 4)
        {
            MGManager.enableBlueMoveOthers();
            MGManager.switchTurnToRed();
            Reset();
        }
    }
}
