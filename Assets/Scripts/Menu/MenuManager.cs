using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button creditButton;
    public Button exitButton;

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject creditMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditMenu.SetActive(false);
    }
    
    public void SwapMenu(string menu)
    {
        DisableAllMenu();
        switch (menu)
        {
            case "Main" :
                mainMenu.SetActive(true);
                AudioManager.Instance.Play("Back");
                break;
            case "Settings" : 
                settingsMenu.SetActive(true);
                AudioManager.Instance.Play("Settings");
                break;
            case "Credits" :
                creditMenu.SetActive(true);
                AudioManager.Instance.Play("Credits");
                break;
            default:
                Debug.Log("Wrong Argument");
                break;
        }
        
    }

    public void LauchGame()
    {
        AudioManager.Instance.Play("Play");
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitGame()
    {
        AudioManager.Instance.Play("Goodbye");
        Application.Quit();
    }
    
    private void DisableAllMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
