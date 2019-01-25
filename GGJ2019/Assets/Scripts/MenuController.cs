using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Fader fader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGamePressed()
    {
        Debug.Log("Game Start Pressed");
        fader.DoFade(1.0f, 0.2f, (finish) =>
            {
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }
        );
    }

    public void OnHowToPressed()
    {
        Debug.Log("HowToPressed");

    }

    public void OnExitPressed()
    {
        Debug.Log("HowToPressed");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
