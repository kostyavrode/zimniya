using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text scoreBar;
    public TMP_Text moneyBar;
    public TMP_Text bestScoreBar;
    public GameObject losePanel;
    public GameObject inGameUI;
    private UniWebView uniWebView;
    [SerializeField] public GameObject[] elements;
    [SerializeField] private GameObject blackWindow;
    [SerializeField] private AudioSource source;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CloseUI();
        }
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
    public void CloseUI()
    {
        foreach (GameObject obj in elements)
        {
            obj.SetActive(false);
        }
        blackWindow.SetActive(true);

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
