using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIController : MonoBehaviour
{
    public static UIController instance;
    public TMP_Text scoreBar;
    public TMP_Text moneyBar;
    public TMP_Text bestScoreBar;
    public GameObject losePanel;
    public GameObject inGameUI;
    private UniWebView uniWebView;
    private void Awake()
    {
        instance = this;
    }
    public void ShowMoney(string money)
    {
        moneyBar.text = money;
    }
    public void ShowScore(string score)
    {
        scoreBar.text = score;
    }
    public void ShowBestScore(string bestScore)
    {
        bestScoreBar.text = bestScore;
    }
    public void StartGame()
    {
        GameManager.instance.StartGame();
    }
    public void ShowLosePanel()
    {
        inGameUI.SetActive(false);
        losePanel.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void OpenWebview(string url)
    {
        var webviewObject = new GameObject("UniWebview");
        uniWebView = webviewObject.AddComponent<UniWebView>();
        uniWebView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        uniWebView.SetShowToolbar(true, false, true, true);
        uniWebView.Load(url);
        uniWebView.Show();
    }
}
