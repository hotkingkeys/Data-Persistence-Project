using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveData : MonoBehaviour
{
    [SerializeField] public BestScore melhorPont = new BestScore();

    public void SaveIntoJson()
    {
        string pont = JsonUtility.ToJson(melhorPont);
        
        File.WriteAllText(GetDir(), pont);
    }

    [System.Serializable]
    public class BestScore
    {
        public int score;
        public string Name;
    }

    private string GetDir()
    {
        string fullPath = Application.persistentDataPath + "/savefile.json";

        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
        }

        return fullPath;
    }

}