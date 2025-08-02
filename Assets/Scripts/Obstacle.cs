using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Obstacle : MonoBehaviour
{
    //public PlayerMovement pm;
    GameObject PlayerMovement1; //�� ������ ���������� � ���������� ���� ������ ������
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

    public SaveGame sg;
    private string lvl;

    void Start()
    {
        //pm = PlayerMovement1.GetComponent<PlayerMovement>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is PlayerMovement && pm.start == false)
        {

            //leftButton.GameObject.SetActive(false);
            //rightButton.GameObject.SetActive(false);
            //jumpButton.GameObject.SetActive(false);
            //leftButton.GameObject.SetActive(true);
            //rightButton.GameObject.SetActive(true);
            //jumpButton.GameObject.SetActive(true);
            //rightButton.GetComponent<EventTrigger>().enabled = false;
            //rightButton.GetComponent<EventTrigger>().enabled = true;
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

    }
    void Update()
    {
        // if (Input.GetButtonDown("Horizontal"))
        // {
        //     pm.enabled = true;
            
        // }
        
    }
}
