using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;
    
    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeadText;
    public TextMeshProUGUI endGameScoreText;

    //instance / singleton

    public static GameUI instance;
    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateHealthBar(int curHP, int maxHP)
    {
        healthBarFill.fillAmount = (float)curHP / (float)maxHP;
    }

    public void UpdateScoreText (int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateAmmoText(int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    public void TogglePauseMenu (bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    public void SetEndGameScreen (bool won, int score)
    {
        endGameScreen.SetActive(true);
        endGameHeaderText.text = won == true ? "You Win" : "You Lose";
        endGameHeaderText.color = won == true ? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score;
    }

    public void OnResumeButton()
    {

    }

    public void OnRestartButton()
    {
        SceneManagement.LoadScene("Game");
    }

    public void OnMenuButton()
    {
        SceneManagement.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
