using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class FTM : MonoBehaviour
{
    public List<GameObject> panels;

    public List<Button> buttons;

    public Button incrST; //the button for inceasing the study timer
    public Button decrST; //the button for decreasing the study timer
    public TextMeshProUGUI curStudyTime; // text that shows the study timer time 
    public int studyTime = 10;

    public Button incrBT; //the button for inceasing the break timer
    public Button decrBT; //the button for decreasing the break timer
    public TextMeshProUGUI curBreakTime; // text that shows the study timer time     
    public int breakTime = 10;

    public Button incrI; // button for increasing the study intervals
    public Button decrI; // button for decreasing the study intervals

    public TextMeshProUGUI curIntervalNum; // the text that shows the current interval number
    public int intervals = 0;

    public Button STARTFISHING; // button for start of fishing

    public bool fishingOn = false; //status check for seeing if the player is ready to fish
    public bool fishingST = false; //ststaus check for seeing if the player should be studying 
    public bool fishingBT = false; // status check for seeing if the player is on break

    public TextMeshProUGUI countdownTimer; //text that has the countdown timer when fishing
    //public TextMeshProUGUI intervalText; // text that has the the nums of intervals left
    public float fishingTimer; // the timer that counts down when fishing
    public float fishingBreakTimer;// the timer that counts down when taking a break
    public int intervalRN; // the current interval rn 




    // Start is called before the first frame update
    void Start()
    {
        studyTime = 10;
        countdownTimer.text = "";
        //sets the incrST to call IncreaseTimes when clicked
        incrST.onClick.AddListener(() => IncreaseTimes(1));
        //sets the decrST to call decreaseTimes when clicked
        decrST.onClick.AddListener(() => decreaseTimes(1));
        //sets the incrBt button to call increaseTimers when clicked
        incrBT.onClick.AddListener(() => IncreaseTimes(2));
        //sets the decrBt button to call decreaseTimers when clicked
        decrBT.onClick.AddListener(() => decreaseTimes(2));
        incrI.onClick.AddListener(() => IncreaseStudyIntervals());
        decrI.onClick.AddListener(() => decreaseStudyIntervals());
        STARTFISHING.onClick.AddListener(() => startStudy());
    }

    // Update is called once per frame
    void Update()
    {
        //curStudyTime.text = "" + studyTimer;
        if(fishingOn == false)
        {
            curStudyTime.text = "" + studyTime;
            curBreakTime.text = "" + breakTime;   
            curIntervalNum.text = "" + intervals; 

            //no breaks if there isnt multiple study intervals
            if(intervals == 1)
            {
                incrBT.interactable = false;
                decrBT.interactable = false;
            }
            else
            {
                incrBT.interactable = true;
                decrBT.interactable = true;
            }
        }
        else if(fishingOn == true)
        {
            //timer for fishing
            if(fishingST == true)
            {
                fishingTimer -= Time.deltaTime;
                fishingTimer = MathF.Round(fishingTimer);
                //text for fishing
                //text for intervals
                countdownTimer.text = "" + fishingTimer;

                if(fishingTimer <= 0)
                {
                    intervalRN --;
                    fishingBT = true;
                    fishingST = false;
                }
            }
            //timer for break           
            if(fishingST == true && intervalRN > 0)
            {
                fishingBreakTimer -= Time.deltaTime;
                fishingBreakTimer = MathF.Round(fishingBreakTimer);
                //text for fishing
                //text for intervals
                countdownTimer.text = "" + fishingBreakTimer;

                if(fishingBreakTimer <= 0)
                {
                    fishingST = true;
                    fishingBT = false;
                }
            }
            if(intervalRN == 0)
            {
                fishingOn = false;
                buttons[0].interactable = true;
            }
        }
    }

   // used for when the fishing times button to open that panel when the button is clicked on
    public void FishingTimes()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(true);
        panels[2].SetActive(false);
        panels[3].SetActive(false);
        panels[4].SetActive(false);
        buttons[0].transform.SetAsLastSibling();
        buttons[1].transform.SetAsLastSibling();
        buttons[1].interactable = true;
        buttons[2].transform.SetAsFirstSibling();
        buttons[3].transform.SetAsFirstSibling();
        buttons[4].transform.SetAsFirstSibling();


    }

    //for increasing the time when picking between the studdy time and break time
    //timetype = 1 -> study time
    //timetypr = 2 -> break time
    public void IncreaseTimes(int timeType)
    {
        //incr study time as long as the study timer is between 10 min and 2 hours
        if(timeType == 1 && studyTime <= 115 && studyTime >= 10)
        {
            studyTime += 5;

        }

        //incr break time as long as the break timer is between 5 min and 1 hour
        if(timeType == 2 && breakTime <= 55 && breakTime >= 5)
        {
            breakTime += 5;
        }
    }

    //for decreasing the time when picking between the studdy time and break time
    //timetype = 1 -> study time
    //timetypr = 2 -> break time
    public void decreaseTimes(int timeType)
    {

        //decr study time as long as the timer is between 10 min and 2 hours
        if(timeType == 1 && studyTime <= 120 && studyTime >= 15)
        {
            studyTime -= 5;
        }

        //decr break time as long as the break timer is between 5 min and 1 hour
        if(timeType == 2 && breakTime <= 60 && breakTime >= 10)
        {
            breakTime -= 5;
        }
    }

    //increases the amt of study intervals between 1 - 10
    public void IncreaseStudyIntervals()
    {
        // the study intervals must be between 0 and 10
        if(intervals <= 9)
        {
            intervals ++;
        }
    }

    //decreases the amt of study intervals between 1 - 10
    public void decreaseStudyIntervals()
    {
        // the study intervals must be between 0 and 10
        if(intervals >= 2)
        {
            intervals --;
        }
    }
    public void startStudy()
    {
        fishingOn = true;
        fishingST = true;
        fishingTimer = studyTime*60;
        fishingBreakTimer = breakTime*60;
        intervalRN = intervals;


        panels[0].SetActive(true);
        panels[1].SetActive(false);
        panels[2].SetActive(false);
        panels[3].SetActive(false);
        panels[4].SetActive(false);
        buttons[0].transform.SetAsFirstSibling();
        buttons[0].interactable = false;
        buttons[1].transform.SetAsFirstSibling();
        buttons[1].interactable = false;
        buttons[2].transform.SetAsFirstSibling();
        buttons[3].transform.SetAsFirstSibling();
        buttons[4].transform.SetAsFirstSibling();
    }
}
