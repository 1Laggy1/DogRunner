using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public SaveGame sg;
    public GameObject panel;
    public float tutorial1 = 0;
    // Start is called before the first frame update
    void Start()
    {
        tutorial1 = PlayerPrefs.GetFloat("tutorial1");
        if (tutorial1 == 0)
        {
            panel.SetActive(true);
            tutorial1 = tutorial1 + 1;
            PlayerPrefs.SetFloat("tutorial1", tutorial1);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
