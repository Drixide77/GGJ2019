using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Fader fader;
    public GameObject howToCanvas;

    public Button play;
    public Button howTo;
    public Button exit;


    // Start is called before the first frame update
    void Start()
    {
        GameObject FTPno = GameObject.Find("Play");
        if (FTPno)
        {
            EventSystem.current.SetSelectedGameObject(FTPno);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (howToCanvas.activeInHierarchy)
        {
            if (Input.GetButtonDown("Fire2_1") || Input.GetButtonDown("Fire2_2") || Input.GetButtonDown("Fire2_3") || Input.GetButtonDown("Fire2_4"))
            {
                play.interactable = true;
                howTo.interactable = true;
                exit.interactable = true;
                GameObject FTPno = GameObject.Find("Play");
                if (FTPno)
                {
                    EventSystem.current.SetSelectedGameObject(FTPno);
                }
                howToCanvas.SetActive(false);
            }
        }
        
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
        howToCanvas.SetActive(true);
        play.interactable = false;
        howTo.interactable = false;
        exit.interactable = false;
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
