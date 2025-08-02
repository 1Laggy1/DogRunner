using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialCollider : MonoBehaviour
{
    private bool Stay;
    [SerializeField] private GameObject Current;
    [SerializeField] private GameObject SoarText;
    [SerializeField] private GameObject Stena;
    [SerializeField] private GameObject StenaSecret;
    [SerializeField] private GameObject GameMusic;
    [SerializeField] private GameObject Unravel;
    [SerializeField] private GameObject UnravelText;
    [SerializeField] private GameObject StenaSecret2;
    [SerializeField] private GameObject finish;
    [SerializeField] private GameObject StenaSecretAudio;

    [SerializeField] private string ctag;
    // Start is called before the first frame update
    void Start()
    {
        ctag = Current.tag;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Stay = true;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Stay && ctag == "SoarT")
        {
            SoarText.SetActive(true);
            Destroy(Current);
        }
        
        if (Stay && ctag == "SoarTExit")
        {
            SoarText.SetActive(false);
            Destroy(Current);
        }

        if (Stay && ctag == "StenaT")
        {
            finish.GetComponent<AudioSource>().Play();
            Stena.SetActive(false);
            Stay = false;
            Current.SetActive(false);

        }

        if (Stay && ctag == "StenaSecretT")
        {
            StenaSecret2.SetActive(true);
            Destroy(Current);
        }

        if (Stay && ctag == "StenaSecretT2")
        {
            StenaSecret.SetActive(false);
            StenaSecretAudio.GetComponent<AudioSource>().Play();
            Destroy(Current);
        }

        if (Stay && ctag == "MusicOffT")
        {
            GameMusic.SetActive(false);
            Unravel.SetActive(true);
            UnravelText.SetActive(true);
            Destroy(Current);
        }

    }
}
