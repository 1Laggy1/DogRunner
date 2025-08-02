using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationRestart : MonoBehaviour
{
    public bool ButtonsDown;
    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            ButtonsDown = true;
            pm.enabled = true;
           
        }
    }

    public void OnDown()
    {
        ButtonsDown = true;
        if (!pm.GetComponent<PlayerMovement>().enabled)
        {
            pm.GetComponent<PlayerMovement>().enabled = true;
        }
        
    }
    public void OnUp()
    {
        ButtonsDown = false;
    }
}
