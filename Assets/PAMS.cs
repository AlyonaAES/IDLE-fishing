using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PAMS : MonoBehaviour
{
    //public TextMeshPro moneyT; //text for the money
    //public TextMeshPro timerT; //text for the timer
    public List<GameObject> panels;
    public int panelIndex;

    public List<Button> buttons;
    public int buttonIndex;

    // Start is called before the first frame update
    void Start()
    {
        panels[0].SetActive(true);
        panels[1].SetActive(false);
        panels[2].SetActive(false);
        panels[3].SetActive(false);
        panels[4].SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // used for when the Upgrades button to open that panel when the button is clicked on
    public void Upgrades()
    {
        Debug.Log("upgrades is open");
        panels[0].SetActive(false);
        panels[1].SetActive(false);
        panels[2].SetActive(true);
        panels[3].SetActive(false);
        panels[4].SetActive(false);
        buttons[0].transform.SetAsFirstSibling();
        buttons[1].transform.SetAsFirstSibling();
        buttons[1].interactable = false;
        buttons[2].transform.SetAsLastSibling();
        buttons[3].transform.SetAsFirstSibling();
        buttons[4].transform.SetAsFirstSibling();


    }

    // used for when the colection log button to open that panel when the button is clicked on
    public void CollectionLog()
    {
        Debug.Log("collection log is open");
        panels[0].SetActive(false);
        panels[1].SetActive(false);
        panels[2].SetActive(false);
        panels[3].SetActive(true);
        panels[4].SetActive(false);
        buttons[0].transform.SetAsFirstSibling();
        buttons[1].transform.SetAsFirstSibling();
        buttons[1].interactable = false;
        buttons[2].transform.SetAsFirstSibling();
        buttons[3].transform.SetAsLastSibling();
        buttons[4].transform.SetAsFirstSibling();

 

    }

    // used for when the settings button to open that panel when the button is clicked on
    public void Settings()
    {
        Debug.Log("settings is open");
        panels[0].SetActive(false);
        panels[1].SetActive(false);
        panels[2].SetActive(false);
        panels[3].SetActive(false);
        panels[4].SetActive(true);
        buttons[0].transform.SetAsFirstSibling();
        buttons[1].transform.SetAsFirstSibling();
        buttons[1].interactable = false;
        buttons[2].transform.SetAsFirstSibling();
        buttons[3].transform.SetAsFirstSibling();
        buttons[4].transform.SetAsLastSibling();



    }
}
