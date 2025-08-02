using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    public GameTime gametime;
    public Text timerText;
    public HowMuchEat hme;
    public Radyga radyga;
    public GameMusic gamemusic;
    public PlayerMovement pm;
    public float onetime = 1;
    //public float Music = 137;
    //public float MusicRestartCurrentTime;
    public float Music2;
    //public float MusicRestartCurrentTimeRound;
    public SaveGame sg;
    public float MusicStop = 0;
    private float stringTimerText;
    private float stringTimerTextSave;
    public GameObject TimeOnPanel;
    public float tutorialMenu;
    public Zone ZoneOnlyFor21Level;
    public GameObject StenaOnlyFor21Level;
    public GameObject KeyOnlyFor21Level;
    //string sceneNow = SceneManager.GetActiveScene().name;

    // Start is called before the first frame update
    void Start()
    {
        //m_MyAudioSource = GetComponent<AudioSource>();
        //savetime = gametime.GetComponent<Text>().text
    }

    // Update is called once per frame
    void Update()
    {
        
            //MusicRestartCurrentTime += Time.deltaTime;
        
        //MusicRestartCurrentTimeRound = Mathf.Round(MusicRestartCurrentTime);
        //MusicRestart();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if((onetime == 1) && (other.gameObject.tag == "Player"))
        {
            stringTimerText = System.Convert.ToSingle(timerText.text);
            if ((hme.eat == 1))
            {
                timerText.text = (stringTimerText - (float)1).ToString();
            }
            else if (hme.eat == 2)
            {
                timerText.text = (stringTimerText - (float)2).ToString();
            }
            else if (hme.eat == 3)
            {
                timerText.text = (stringTimerText - (float)3).ToString();
            }
            TimeOnPanel.transform.parent.gameObject.SetActive(true);
            stringTimerTextSave = System.Convert.ToSingle(timerText.text);
            TimeOnPanel.GetComponent<UnityEngine.UI.Text>().text = "Your time: " + stringTimerTextSave.ToString("F2");
            
            GameObject varGameObject = GameObject.Find("Timer");
            varGameObject.GetComponentInChildren<GameTime>().enabled = false;
            //gametime.GetComponent("Game Time").enabled = false;
            GetComponent<AudioSource>().Play();
            radyga.GetComponent<SpriteRenderer>().enabled = true;
            gamemusic.GetComponent<AudioSource>().Pause();
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                if ((PlayerPrefs.GetFloat("timelvl3") > stringTimerTextSave) || (PlayerPrefs.GetFloat("timelvl3") == 0))
                {
                    sg.timelvl3 = stringTimerTextSave;
                    PlayerPrefs.SetFloat("timelvl3", sg.timelvl3);
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level1 (2)")
            {
                if ((PlayerPrefs.GetFloat("timelvl1") > stringTimerTextSave) || (PlayerPrefs.GetFloat("timelvl1") == 0))
                {
                    sg.timelvl1 = stringTimerTextSave;
                    PlayerPrefs.SetFloat("timelvl1", sg.timelvl1);
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                sg.timelvl2 = stringTimerTextSave;
                PlayerPrefs.SetFloat("timelvl2", sg.timelvl2);
            }
            else if (SceneManager.GetActiveScene().name == "Level1(1)")
            {
                sg.timelvl4 = stringTimerTextSave;
                PlayerPrefs.SetFloat("timelvl4", sg.timelvl4);
            }
            else if (SceneManager.GetActiveScene().name == "Level2(1)")
            {
                sg.timelvl5 = stringTimerTextSave;
                PlayerPrefs.SetFloat("timelvl5", sg.timelvl5);
                tutorialMenu = PlayerPrefs.GetFloat("tutorialMenu");
            }
            else if (SceneManager.GetActiveScene().name == "Level3(1)")
            {
                sg.timelvl6 = stringTimerTextSave;
                PlayerPrefs.SetFloat("timelvl6", sg.timelvl6);
                tutorialMenu = PlayerPrefs.GetFloat("tutorialMenu");
                if (tutorialMenu == 0)
                {
                    tutorialMenu = tutorialMenu + 1;
                    PlayerPrefs.SetFloat("tutorialMenu", tutorialMenu);
                }
            }
            sg.HmEatAll = PlayerPrefs.GetFloat("HmEatAll") + hme.eat;
            PlayerPrefs.SetFloat("HmEatAll", sg.HmEatAll);
            MusicStop = 1;
            onetime = onetime - 1;
            //pm.GetComponent<Rigidbody2D>().isKinematic = true;
            if(ZoneOnlyFor21Level != null)
            {
                KeyOnlyFor21Level.SetActive(true);
                ZoneOnlyFor21Level.enabled = false;
                StenaOnlyFor21Level.SetActive(true);
                
            }
            
        }
    }
    //void MusicRestart()
    //{
    //    if ((MusicRestartCurrentTimeRound == Music))
     //   {
     //       
     //       gamemusic.GetComponent<AudioSource>().enabled = true;
     //       Music = Music + 137;
     //       //Music2 = Music + 1;
     //       Debug.Log("Music restarting");
     //   }
    //}
}
