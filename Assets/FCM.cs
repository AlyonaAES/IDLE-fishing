using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FCM : MonoBehaviour
{

    public List<string> totalFish; // all the fish collected

    public Dictionary<string, bool> discoveredFish = new Dictionary<string, bool>();// dictonary that holds all fish and if it has been found

    public GameObject WFM; //while fishing manager script 

    
    // Start is called before the first frame update
    void Start()
    {
        //adds the values to the dictonary
        List<string> fishes = WFM.GetComponent<WFM>().commonFish;
        fishes.AddRange(WFM.GetComponent<WFM>().uncommonFish);
        fishes.AddRange(WFM.GetComponent<WFM>().rareFish);
        fishes.AddRange(WFM.GetComponent<WFM>().mythicFish);

        for(int i = 0; i < fishes.Count; i++)
        {
            discoveredFish.Add(fishes[i], false);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
