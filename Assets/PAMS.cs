using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PAMS : MonoBehaviour
{
    //public TextMeshPro moneyT; //text for the money
    //public TextMeshPro timerT; //text for the timer
    //--------------------------panels-----------------------
    public GameObject frontPgP;
    public GameObject fishingTimesP;
    public GameObject upgradesP;
    public GameObject collectionLogP;
    public  GameObject settingsP;

    // Start is called before the first frame update
    void Start()
    {
        frontPgP.SetActive(true);
        fishingTimesP.SetActive(false);
        upgradesP.SetActive(false);
        collectionLogP.SetActive(false);
        settingsP.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// used for when the fishing times button to open that panel when the button is clicked on
    public void FishingTimes()
    {
        Debug.Log("fishing times is open");
        frontPgP.SetActive(false);
        fishingTimesP.SetActive(true);
        upgradesP.SetActive(false);
        collectionLogP.SetActive(false);
        settingsP.SetActive(false);
    }

    // used for when the Upgrades button to open that panel when the button is clicked on
    public void Upgrades()
    {
        Debug.Log("upgrades is open");
        frontPgP.SetActive(false);
        fishingTimesP.SetActive(false);
        upgradesP.SetActive(true);
        collectionLogP.SetActive(false);
        settingsP.SetActive(false);
    }

    // used for when the colection log button to open that panel when the button is clicked on
    public void CollectionLog()
    {
        Debug.Log("collection log is open");
        frontPgP.SetActive(false);
        fishingTimesP.SetActive(false);
        upgradesP.SetActive(false);
        collectionLogP.SetActive(true);
        settingsP.SetActive(false);
    }

    // used for when the settings button to open that panel when the button is clicked on
    public void Settings()
    {
        Debug.Log("settings is open");
        frontPgP.SetActive(false);
        fishingTimesP.SetActive(false);
        upgradesP.SetActive(false);
        collectionLogP.SetActive(false);
        settingsP.SetActive(true);
    }
}
