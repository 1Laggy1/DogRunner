using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialFirstMenu : MonoBehaviour
{
    public SaveGame sg;
    public float tutorialMenu = 0;
    public GameObject tutorialLevelsPanel;
    public GameObject levels1Panel;
    public float timelvl6;
    // Start is called before the first frame update
    void Start()
    {

        tutorialMenu = PlayerPrefs.GetFloat("tutorialMenu");
        timelvl6 = PlayerPrefs.GetFloat("timelvl6");
        ////Change to lvl6
        if (timelvl6 > 0)
        {
            tutorialMenu = tutorialMenu + 1;
            PlayerPrefs.SetFloat("tutorialMenu", tutorialMenu);
            Debug.Log("Tutorial>0");
        }
        ////
    }

    public void OnClick()
    {
        tutorialMenu = PlayerPrefs.GetFloat("tutorialMenu");
        if (tutorialMenu == 0)
        {
            tutorialLevelsPanel.SetActive(true);
        }
        else if (tutorialMenu > 0)
        {
            levels1Panel.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
