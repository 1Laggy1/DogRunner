using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchEat : MonoBehaviour
{
    public int eat;
    Text text;
    //public Podc4etEat eat;
    //public HowMuchEat textEat;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "= " + eat.ToString();
    }
}
