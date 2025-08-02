using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingObstacle : MonoBehaviour
{
    

    
    new private Rigidbody2D rigidbody;
    public PlayerMovement pm;
    public GameTime t;
    public CameraController cc;
    public Finish f;
    public Radyga r;
    public GameMusic gm;
    public Eda e1;
    public Eda e2;
    public Eda e3;
    public HowMuchEat hme;
    public Zone z;
    public bool MoveRight = true;
    public bool MoveRightStart;
    public Sprite SpriteIdle;
    [SerializeField]
    private float xtp;
    [SerializeField]
    private float ytp;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private bool GalkaMoveUp = false;
    public NavigationRestart jumpButton;
    public MovingObstacle mb;
    public MovingObstacle mb2;
    public MovingObstacle mb3;
    public MovingObstacle mb4;
    public MovingObstacle mb5;

    public SaveGame sg;
    private string lvl;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveRightStart = MoveRight;
        //if (SceneManager.GetActiveScene().name == "Level3")
        //{
        //    lvl = "Level3";
        //}
        //else if (SceneManager.GetActiveScene().name == "Level1 (2)")
        //{
        //    lvl = "Level1 (2)";
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionRight = transform.right;
        Vector3 directionUp = transform.up;
        if (GalkaMoveUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + directionRight, speed * Time.deltaTime);
        }
        else if (GalkaMoveUp == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + directionUp, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is PlayerMovement)
        {
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

            t.GetComponent<GameTime>().enabled = false;
            z.GetComponent<Zone>().enabled = false;
            GetComponent<MovingObstacle>().enabled = false;

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
            //if (lvl == "Level3")
            //{
            //    sg.Attemptslvl3 = PlayerPrefs.GetFloat("Attemptslvl3") + 1;
            //    PlayerPrefs.SetFloat("Attemptslvl3", sg.Attemptslvl3);
            //}
            //else if (lvl == "Level1 (2)")
            //{
            //    sg.Attemptslvl1 = PlayerPrefs.GetFloat("Attemptslvl1") + 1;
            //    PlayerPrefs.SetFloat("Attemptslvl1", sg.Attemptslvl1);
            //}
        }
        else if (collider.gameObject.tag == "MovingNavigator")
        {
            Move();
        }

        
    }

    private void Move()
    {

        if (MoveRight == false)
        {
            speed = -speed;
            MoveRight = true;
        }
        else if (MoveRight == true)
        {
            speed = -speed;
            MoveRight = false;
        }

    }

    public void Restart()
    {

        transform.position = new Vector2((float)xtp, (float)ytp);
        MoveRight = MoveRightStart;
        if (MoveRightStart == true)
        {
            speed = Mathf.Abs(speed) * -1;
        }
        else if (MoveRightStart == false)
        {
            speed = Mathf.Abs(speed);
        }
        GetComponent<MovingObstacle>().enabled = false;
    }

}
