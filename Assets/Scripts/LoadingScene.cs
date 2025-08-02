using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public int numberScene;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        numberScene = (int)PlayerPrefs.GetFloat("Loading");
        //SceneManager.LoadScene(numberScene);

        StartCoroutine(LoadAsync());
    }
    
    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(numberScene);
//        yield return new WaitForSecondsRealtime(20);
        while (!asyncLoad.isDone)
        {
            slider.value = asyncLoad.progress;
            yield return null;
        }
        

    }
}
