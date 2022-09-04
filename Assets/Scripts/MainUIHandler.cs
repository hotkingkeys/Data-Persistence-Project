using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public SceneManager HighScoreScene;
    public Button highScoreButton;

    // Start is called before the first frame update
    void Awake()
    {
        string fullPath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);

            SaveData.BestScore obj = JsonUtility.FromJson<SaveData.BestScore>(json);
            bestScoreText.text = "Best Score:\n" + obj.Name + ": " + obj.score;
        }
        else
        {
            bestScoreText.text = "Best Score: \nName: 0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        string fullPath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);

            SaveData.BestScore obj = JsonUtility.FromJson<SaveData.BestScore>(json);
            bestScoreText.text = "Best Score:\n" + obj.Name + ": " + obj.score;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HighScore()
    {
       if(!SceneManager.sceneCount.Equals(2))
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
        } else
        {
            SceneManager.UnloadSceneAsync(2);
        }
        
    }

}
