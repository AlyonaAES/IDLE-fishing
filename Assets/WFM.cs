using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class WFM : MonoBehaviour
{
    public List<string> commonFish; // the names of the different common fish 
    public List<string> uncommonFish; // the names of the different uncommon fish
    public float UFchance; // the chance to get the uncommon fish

    public List<string> rareFish; // the names of the different rare fish 
    public float RFchance; // the chance to get a rare fish

    public List<string> mythicFish; // the names of the different mythic fish
    public float MFchance; // the chance to get a mythic fish


    public GameObject FTM; // the script for the fishing time manager
    public GameObject FCM; // the script for the fish collection manager


    public bool collectFish; // status check to see if the study timer is done and to get the fish 

    public List<string> foundFish; // the fish that were found 

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the study timer is done then collect fish is true
        if(collectFish == true)
        {
            CollectFish();
            collectFish = false;
        }
    }
    
    //function that holds all the collection of fish 
    void CollectFish()
    {
        //gets the amt of time that ios being studied from the FTM script 
        float min = FTM.GetComponent<FTM>().studyTime;

        //GUARANTEED FISH
        //depending on the amt of time studying you get a free fish of a certain rarity  
        if(min >= 30 && min < 60)
        {
            int randomFish = Random.Range(0, uncommonFish.Count);
            foundFish.Add(uncommonFish[randomFish]);
            Debug.Log("uncommon fish: " + uncommonFish[randomFish]);
        }
        if(min >= 60 && min < 90)
        {
            int randomFish = Random.Range(0, rareFish.Count);
            foundFish.Add(rareFish[randomFish]);
            Debug.Log("rare fish: " + rareFish[randomFish]);
        }
        if(min >= 90 && min < 120)
        {
            int randomFish = Random.Range(0, mythicFish.Count);
            foundFish.Add(mythicFish[randomFish]);
            Debug.Log("mythic fish: " + mythicFish[randomFish]);
        }
        if(min >= 90 && min < 120)
        {
            int randomFish = Random.Range(0, mythicFish.Count);
            foundFish.Add(mythicFish[randomFish]);
            Debug.Log("mythic fish: " + mythicFish[randomFish]);
            randomFish = Random.Range(0, mythicFish.Count);
            foundFish.Add(mythicFish[randomFish]);
            Debug.Log("mythic fish: " + mythicFish[randomFish]);
        }

        //ACTUALL COLLECTION OF FISH
        //runs x amt of times where x is the amt of mins studied / 10
        //checks from mythic -> rare -> uncommon and if the number doesnt fall under any of thoes then player gets common fish
        for(float numOfFish = Mathf.Floor(min/10); numOfFish > 0; numOfFish--)
        {
            float chance = Random.Range(0,101);
            if(chance <= MFchance)
            {
                // get mytic fish
                int randomFish = Random.Range(0, mythicFish.Count);
                foundFish.Add(mythicFish[randomFish]);
                Debug.Log("mythic fish: " + mythicFish[randomFish]);
            }
            else if (chance <= RFchance)
            {
                //get rare fish
                int randomFish = Random.Range(0, rareFish.Count);
                foundFish.Add(rareFish[randomFish]);
                Debug.Log("rare fish: " + rareFish[randomFish]);

            }
            else if (chance <= UFchance)
            {
                //get uncommon fish
                int randomFish = Random.Range(0, uncommonFish.Count);
                foundFish.Add(uncommonFish[randomFish]);
                Debug.Log("uncommon fish: " + uncommonFish[randomFish]);

            }
             else
            {
                //get common fish
                int randomFish = Random.Range(0, commonFish.Count);
                foundFish.Add(commonFish[randomFish]);
                Debug.Log("common fish: " + commonFish[randomFish]);

            }

            //check if the study sesh is done and moves the list to the FCM to log the found fish
            if(FTM.GetComponent<FTM>().fishingOn == false)
            {
                    FishingIsDone();
            }

        }
    }

    void FishingIsDone()
    {
        FCM.GetComponent<FCM>().totalFish.AddRange(foundFish);
        for(int i=0; i< foundFish.Count; i++)
        {
            FCM.GetComponent<FCM>().discoveredFish[foundFish[i]] = true;
            Debug.Log(foundFish[i] + " is " + FCM.GetComponent<FCM>().discoveredFish[foundFish[i]]);
        }
        foundFish.Clear();

    }
}
