using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eda : MonoBehaviour
{

    public HowMuchEat hme;
    public Eda eatsound;
    public GameTime time;

    Text text;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Unit unit = other.GetComponent<Unit>();
        if (unit)
        {
            hme.eat = hme.eat + 1;
            eatsound.GetComponent<AudioSource>().Play();
            //time.secondF = time.secondF - (float)100;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;

        }    
    }
}
