using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private string saveFilePath;

    private void Start()
    {
        saveFilePath = Application.persistentDataPath + "/savefile.json";
        GameManager.instance.onSaveGame += SaveGameData;
        LoadGame();

    }
    private void LoadGame()
    {
        SaveData loadData = LoadData();
        GameManager.instance.ApplySavedDataToGame(loadData);
    }
    private void SaveGameData(int level, int score, int highScore)
    {
        SaveData data = new SaveData(level, score, highScore);
        File.WriteAllText(saveFilePath, JsonUtility.ToJson(data));
    }

    private SaveData LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<SaveData>(json);
        }

        return null;
    }

}

[System.Serializable]
public class SaveData
{
    public int level;
    public int score;
    public int highScore;

    public SaveData(int level, int score, int highScore)
    {
        this.level = level;
        this.score = score;
        this.highScore = highScore;
    }
}
