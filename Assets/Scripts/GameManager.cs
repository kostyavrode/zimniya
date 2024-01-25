using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float spawnDelay;
    public PlayerController controllerPlayer;
    public Transform startTransform;
    public static GameManager instance;
    public bool isGameStarted;
    private int score;
    private int money;
    public GameObject[] levelParts;
    public List<GameObject> spawnedParts = new List<GameObject>();
    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        if (!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("money", 0);
            PlayerPrefs.Save();
        }
        CreateLevelPart();
    }

    private void Start()
    {
            UIManager.instance.ShowMoney(PlayerPrefs.GetInt("money").ToString());
        }
    public void StartGame()
    {
        isGameStarted = true;
        PlayerController newPlayer = Instantiate(controllerPlayer);
        newPlayer.transform.position = startTransform.position;
        newPlayer.transform.position = startTransform.position;
        CameraController.instance.SetTarget(newPlayer.transform);
        CameraController.instance.ChangeCamPos();
        StartCoroutine(LevelSpawner());

    }
    private void FixedUpdate()
    {
        if (isGameStarted)
        {
            Debug.Log(isGameStarted);
            score++;
            UIManager.instance.ShowScore(score.ToString());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 100);
            PlayerPrefs.Save();
        }
    }
    public bool GetIsGameStarted()
    {
        return isGameStarted;
    }
    public void AddMoney()
    {
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 1);
        PlayerPrefs.Save();
    }
    public void EndGame()
    {
        isGameStarted = false;
        UIManager.instance.ShowLosePanel();
        CheckBestScore();
    }
    private void CheckBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (score>PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
        UIManager.instance.ShowBestScore((PlayerPrefs.GetInt("BestScore").ToString()));
    }
    private void CreateLevelPart()
    {
        GameObject newPart = Instantiate(levelParts[Random.Range(0, levelParts.Length)]);
        newPart.transform.position = GetSpawnPoint();
        spawnedParts.Add(newPart);
        Debug.Log(spawnedParts.Count);
        if (GameManager.instance.isGameStarted)
        {
            StartCoroutine(LevelSpawner());
        }
        else
        {
            Debug.Log("huita");
        }
    }
    private Vector3 GetSpawnPoint()
    {
        return new Vector3(spawnedParts[spawnedParts.Count-1].transform.position.x, spawnedParts[spawnedParts.Count-1 ].transform.position.y-10.51f, spawnedParts[spawnedParts.Count-1 ].transform.position.z+101.7f);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGameStarted = false;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        isGameStarted = true;
    }
    private IEnumerator LevelSpawner()
    {
        yield return new WaitForSeconds(spawnDelay);
        CreateLevelPart();
    }
}
