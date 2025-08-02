using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed : MonoBehaviour
{
    public PlayerMovement pm;
    UnityEngine.UI.Slider SpeedSlider;
    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        SpeedSlider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        pm.normalSpeed = SpeedSlider.value;
        speedText.text = SpeedSlider.value.ToString("F2");
    }
}
