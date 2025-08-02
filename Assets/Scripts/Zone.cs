using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zone : MonoBehaviour
{

    private float speed = 2.3F;
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
    public MovingObstacle mo;
    public MovingObstacle mo2;
    public MovingObstacle mo3;
    public MovingObstacle mo4;
    public MovingObstacle mo5;
    public HowMuchEat hme;
    public Sprite SpriteIdle;

    public SaveGame sg;
    private string lvl;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //if (SceneManager.GetActiveScene().name == "Level3")
        //{
        //   lvl = "Level3";
        //}
        //else if (SceneManager.GetActiveScene().name == "Level1 (2)")
        //{
        //    lvl = "Level1 (2)";
        //}
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = transform.right;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is PlayerMovement)
        {

            pm.GetComponent<PlayerMovement>().enabled = false;
            pm.anim.SetBool("isRunning", false);
            pm.anim.SetBool("isJumping", false);
            pm.GetComponent<SpriteRenderer>().sprite = SpriteIdle;

            //unit.ReceiveDamage();
            pm.Restart();
            cc.Restart();
            if (mo != null)
            {
                mo.Restart();
            }
            if (mo2 != null)
            {
                mo2.Restart();
            }
            if (mo3 != null)
            {
                mo3.Restart();
            }
            if (mo4 != null)
            {
                mo4.Restart();
            }
            if (mo5 != null)
            {
                mo5.Restart();
            }
            Restart();
            r.GetComponent<SpriteRenderer>().enabled = false;
            f.GetComponent<AudioSource>().Stop();
            f.onetime = 1;
            e1.GetComponent<SpriteRenderer>().enabled = true;
            e1.GetComponent<BoxCollider2D>().enabled = true;
            e2.GetComponent<SpriteRenderer>().enabled = true;
            e2.GetComponent<BoxCollider2D>().enabled = true;
            e3.GetComponent<SpriteRenderer>().enabled = true;
            e3.GetComponent<BoxCollider2D>().enabled = true;

            //mo.GetComponent<MovingObstacle>().enabled = false;
            t.GetComponent<GameTime>().enabled = false;
            GetComponent<Zone>().enabled = false;

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
    }

    public void Restart()
    {

        transform.position = new Vector2(-15, -1);
    }

}
