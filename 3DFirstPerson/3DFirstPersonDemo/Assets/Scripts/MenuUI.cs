using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // On Button Press Play Game
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    // On Button Press Quit Game
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
