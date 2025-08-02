using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{

    GameObject PlayerMovement1; //не забудь перетащить в инспекторе сюда нужный обьект
    public PlayerMovement pm;
    public GameTime t;
    public Zone z;
    public CameraController cc;
    public Finish f;
    public Radyga r;
    public GameMusic gm;
    public Eda e1;
    public Eda e2;
    public Eda e3;
    public MovingObstacle mb;
    public MovingObstacle mb2;
    public MovingObstacle mb3;
    public MovingObstacle mb4;
    public MovingObstacle mb5;
    public HowMuchEat hme;
    public GameObject leftButton;
    public GameObject rightButton;
    public NavigationRestart jumpButton;
    public Sprite SpriteIdle;
    public GameObject Tutorial;

    public SaveGame sg;
    private string lvl;

    public void OnClick()
    {
        if (Tutorial != null)
        {
            Tutorial.SetActive(false);
        }
        jumpButton.ButtonsDown = false;
        pm.GetComponent<PlayerMovement>().enabled = false;
        pm.anim.SetBool("isRunning", false);
        pm.anim.SetBool("isJumping", false);
        pm.GetComponent<SpriteRenderer>().sprite = SpriteIdle;

        //unit.ReceiveDamage();
        pm.Restart();
        cc.Restart();
        z.Restart();
        if (mb != null)
        {
            mb.Restart();
        }
        if (mb2 != null)
        {
            mb2.Restart();
        }
        if (mb3 != null)
        {
            mb3.Restart();
        }
        if (mb4 != null)
        {
            mb4.Restart();
        }
        if (mb5 != null)
        {
            mb5.Restart();
        }
        r.GetComponent<SpriteRenderer>().enabled = false;
        f.GetComponent<AudioSource>().Stop();
        f.onetime = 1;
        e1.GetComponent<SpriteRenderer>().enabled = true;
        e1.GetComponent<BoxCollider2D>().enabled = true;
        e2.GetComponent<SpriteRenderer>().enabled = true;
        e2.GetComponent<BoxCollider2D>().enabled = true;
        e3.GetComponent<SpriteRenderer>().enabled = true;
        e3.GetComponent<BoxCollider2D>().enabled = true;

        //mb.GetComponent<MovingObstacle>().enabled = false;
        t.GetComponent<GameTime>().enabled = false;
        z.GetComponent<Zone>().enabled = false;

        //GameObject varGameObject = GameObject.Find("Timer");
        //varGameObject.GetComponentInChildren<GameTime>().enabled = false;
        //varGameObject.GetComponentInChildren<GameTime>().enabled = true;
        t.timeStop = t.timeStart;
        hme.eat = 0;


        if (f.MusicStop == 1)
        {
            gm.GetComponent<AudioSource>().Play();
            f.MusicStop = 0;
        }
        pm.start = true;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
