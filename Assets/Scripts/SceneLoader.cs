using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameObject image;

    private void Awake()
    {
        Debug.Log("start");
        image = GameObject.Find("Help");
        image.SetActive(false);
    }

    private void Update()
    {
        if (image.activeSelf && Input.anyKey)
        {
            image.SetActive(false);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Falling");
    }

    public void HideHelp()
    {
        if (Input.anyKey)
        {
            image.SetActive(false);
        }
    }

    public void ShowHelp()
    {
        image.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    
}
