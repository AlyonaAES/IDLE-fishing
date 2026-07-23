using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class WFM : MonoBehaviour
{
    public List<string> commonFish;
    public List<string> uncommonFish;
    public float UFchance;

    public List<string> rareFish;
    public float RFchance;

    public List<string> mythicFish;
    public float MFchance;


    public GameObject FTM;
    public GameObject FCM;

    public bool collectFish;

    public List<string> foundFish;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(collectFish == true)
        {
            CollectFish();
            collectFish = false;
        }
    }

    void CollectFish()
    {
        float min = FTM.GetComponent<FTM>().studyTime;

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
                FCM.GetComponent<FCM>().totalFish.AddRange(foundFish);
                foundFish.Clear();
        }
    }
}
