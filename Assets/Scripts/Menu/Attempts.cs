using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour
{
    public SaveGame sg;
    public GameObject atlvl1;
    public GameObject atlvl2;
    public GameObject atlvl3;
    public GameObject atlvl4;
    public GameObject atlvl5;
    public GameObject atlvl6;
    // Start is called before the first frame update
    void Start()
    {
        atlvl1.GetComponent<Text>().text = PlayerPrefs.GetFloat("Attemptslvl1").ToString();
        atlvl3.GetComponent<Text>().text = PlayerPrefs.GetFloat("Attemptslvl3").ToString();
        atlvl2.GetComponent<Text>().text = PlayerPrefs.GetFloat("Attemptslvl2").ToString();
        atlvl4.GetComponent<Text>().text = PlayerPrefs.GetFloat("Attemptslvl4").ToString();
        atlvl5.GetComponent<Text>().text = PlayerPrefs.GetFloat("Attemptslvl5").ToString();
        atlvl6.GetComponent<Text>().text = PlayerPrefs.GetFloat("Attemptslvl6").ToString();
        Debug.Log(PlayerPrefs.GetFloat("Attemptslvl2"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
