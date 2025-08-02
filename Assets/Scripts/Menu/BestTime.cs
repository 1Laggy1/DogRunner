using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTime : MonoBehaviour
{
    public SaveGame sg;
    public GameObject btlvl1;
    public GameObject btlvl2;
    public GameObject btlvl3;
    public GameObject btlvl1Tutorial;
    public GameObject btlvl2Tutorial;
    public GameObject btlvl3Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        btlvl1.GetComponent<Text>().text = PlayerPrefs.GetFloat("timelvl1").ToString();
        btlvl3.GetComponent<Text>().text = PlayerPrefs.GetFloat("timelvl3").ToString();
        btlvl2.GetComponent<Text>().text = PlayerPrefs.GetFloat("timelvl2").ToString();
        btlvl1Tutorial.GetComponent<Text>().text = PlayerPrefs.GetFloat("timelvl4").ToString();
        btlvl2Tutorial.GetComponent<Text>().text = PlayerPrefs.GetFloat("timelvl5").ToString();
        btlvl3Tutorial.GetComponent<Text>().text = PlayerPrefs.GetFloat("timelvl6").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
