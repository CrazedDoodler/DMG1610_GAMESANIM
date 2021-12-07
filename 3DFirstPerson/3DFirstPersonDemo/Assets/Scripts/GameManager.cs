using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreWin;
    public int curScore;
    public bool gamePaused;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        GameUI.instance.TogglePauseMenu(gamePaused);
        curScore.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore()
    {
        curScore += score;

        GameUI.instance.UpdateScoreText(curScore);

        if(curScore <= scoreWin)
            WinGame();
    }

    void WinGame()
    {
        GameUI.instance.SetEndGameScreen(true, curScore);
    }

    public void LoseGame()
    {
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}

