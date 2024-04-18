using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startPannel;
    [SerializeField] private GameObject scorePannel;
    [SerializeField] private GameObject resultPannel;
    [SerializeField] private GameObject quitGamePanel;
    [SerializeField] private Button gameButton;

    private void Start()
    {
        EggLife.Instance.GameOver += gameOver;
    }

    public void StartButton()
    {
        scorePannel.gameObject.SetActive(true);
        gameButton.gameObject.SetActive(true);
        startPannel.gameObject.SetActive(false);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    private void gameOver()
    {
        resultPannel.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        EggLife.Instance.GameOver -= gameOver;
    }
    private void Update()
    {
        BackButtonClicked();
    }
    public void BackButtonClicked()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 0;
                quitGamePanel.SetActive(true);
            }
        }
        else
        {

            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 0;
                quitGamePanel.SetActive(true);
            }
        }

    }

    public void YesButton()
    {
        Application.Quit();
    }
    public void NoButton()
    {
        Time.timeScale = 1;
        
        quitGamePanel.SetActive(false);

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void MoreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=8094495406725672456&hl=en_IN&gl=US");
    }

    public void RateUs()
    {
        Application.OpenURL("market://details?id=" + Application.productName);
    }
}
