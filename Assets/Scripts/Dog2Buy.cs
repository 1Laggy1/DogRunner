using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog2Buy : MonoBehaviour
{
    public SaveGame sg;
    public float WasBuy1 = 1;
    public float WasBuy2 = 0;
    public float WasBuy3 = 0;
    private float hmEatAll;
    public float Cost2;
    public float Cost3;
    [SerializeField]
    private float Dog;
    public GameObject Dog1;
    public GameObject Dog2;
    public GameObject Dog3;
    public float DogSkin = 1;

    // Start is called before the first frame update
    void Start()
    {
        hmEatAll = sg.HmEatAll;
        WasBuy1 = 1;
        WasBuy2 = PlayerPrefs.GetFloat("WasBuy2");
        WasBuy3 = PlayerPrefs.GetFloat("WasBuy3");
        DogSkin = PlayerPrefs.GetFloat("DogSkin");
    }

    // Update is called once per frame
    void Update()
    {
        vWasBuy1();
        vWasBuy2();
        vWasBuy3();
    }

    public void OnClick1()
    {
        if (WasBuy1 == 1 && DogSkin != 1)
        {
            DogSkin = 1;
            PlayerPrefs.SetFloat("DogSkin", DogSkin);
        }
    }
    public void OnClick2()
    {
        if (WasBuy2 == 0)
        {
            if (sg.HmEatAll >= Cost2)
            {
                sg.HmEatAll = sg.HmEatAll - Cost2;
                PlayerPrefs.SetFloat("HmEatAll", sg.HmEatAll);
                WasBuy2 = 1;
                PlayerPrefs.SetFloat("WasBuy2", WasBuy2);
                Dog2.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
            }
        }
        else if (WasBuy2 == 1 && DogSkin != 2)
        {
            DogSkin = 2;
            PlayerPrefs.SetFloat("DogSkin", DogSkin);
            Dog2.GetComponentInChildren<UnityEngine.UI.Text>().text = "Selected";
            Dog1.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
            Dog3.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
        }
    }
    public void OnClick3()
    {
           if (WasBuy3 == 0)
           {
               if (sg.HmEatAll >= Cost3)
               {
                    sg.HmEatAll = sg.HmEatAll - Cost3;
                    PlayerPrefs.SetFloat("HmEatAll", sg.HmEatAll);
                    WasBuy3 = 1;
                    PlayerPrefs.SetFloat("WasBuy3", WasBuy3);
                    Dog3.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
               }
               
           }
           else if (WasBuy3 == 1 && DogSkin != 3)
           {
                DogSkin = 3;
                PlayerPrefs.SetFloat("DogSkin", DogSkin);
                Dog3.GetComponentInChildren<UnityEngine.UI.Text>().text = "Selected";
                Dog2.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
                Dog1.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
           }
    }

    public void vWasBuy1()
    {
        if (WasBuy1 == 1 && DogSkin != 1)
        {
            Dog1.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
        }
        else if (WasBuy1 == 1 && DogSkin == 1)
        {
            Dog1.GetComponentInChildren<UnityEngine.UI.Text>().text = "Selected";
        }
        else if (WasBuy1 == 0)
        {
            Dog1.GetComponentInChildren<UnityEngine.UI.Text>().text = "Buy";
        }
    }
    public void vWasBuy2()
    {
        if (WasBuy2 == 1 && DogSkin != 2)
        {
            Dog2.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
        }
        else if (WasBuy2 == 1 && DogSkin == 2)
        {
            Dog2.GetComponentInChildren<UnityEngine.UI.Text>().text = "Selected";
        }
        else if (WasBuy2 == 0)
        {
            Dog2.GetComponentInChildren<UnityEngine.UI.Text>().text = "Buy";
        }
    }

    public void vWasBuy3()
    {
        if (WasBuy3 == 1 && DogSkin != 3)
        {
            Dog3.GetComponentInChildren<UnityEngine.UI.Text>().text = "Choose";
        }
        else if (WasBuy3 == 1 && DogSkin == 3)
        {
            Dog3.GetComponentInChildren<UnityEngine.UI.Text>().text = "Selected";
        }
        else if (WasBuy3 == 0)
        {
            Dog3.GetComponentInChildren<UnityEngine.UI.Text>().text = "Buy";
        }
    }
}
