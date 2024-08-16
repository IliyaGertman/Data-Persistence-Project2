using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextManager : MonoBehaviour
{
    public MainManager mainManager;
    public Text currentPlayerName;
    public Text bestScoreAndName;
    public int currentScore;
    public string inGamePlayerName;
    public int bestScore;
    public string bestPlayerName;
    public static TextManager Instance;

    private void Awake()
    {
       
        LoadScore();
    }

    void Start()
    {
        mainManager = GameObject.FindObjectOfType<MainManager>();
        inGamePlayerName = NameHolder.Instance.GetPlayerName();
        UpdateUI();
    }

    private void Update()
    {
        if (mainManager == null) return;

        currentScore = mainManager.GetScore();

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestPlayerName = inGamePlayerName;
            SaveScore();
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        currentPlayerName.text = "Player: " + inGamePlayerName;
        bestScoreAndName.text = "Player: " + bestPlayerName + $"  High Score: {bestScore}";
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestPlayerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestPlayerName = bestPlayerName;
        string json = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/score.json";
        File.WriteAllText(filePath, json);
    }

    public void LoadScore()
    {
        string filePath = Application.persistentDataPath + "/score.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
        else
        {
            bestScore = 0;
            bestPlayerName = "Nobody";
        }
    }
}