using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    private PlayerController playerController;
    public TextMeshProUGUI playerLivesCountText;
    public TextMeshProUGUI playerScoreText;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController.isPlayerAlive)
        {
            gameOverScreen.SetActive(true);
        }
        playerLivesCountText.text = "Lives : " + playerController.lives;
        playerScoreText.text = "Score : " + playerController.score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
