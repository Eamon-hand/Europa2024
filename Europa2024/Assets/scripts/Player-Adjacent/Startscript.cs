using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // StartGame dictates what happens when you start the game. this should happen when you push the start button
    public void StartGame()
    {
        Time.timeScale = 1.0f;
    }

    // QuitToMenu dictates what happens when you want to go back to the menu. this should happen when you push the "quit to menu" button
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // QuitGame closes the application. this only happens when the game is launched outside of unity. nothing happens when this runs in unity.
    // this text is way too long. I should try and condense it.
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
