using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct DifficultySettings
{
    public bool isEasy;
    public bool isNormal;
    public bool isHard;
}

public class Difficulty : MonoBehaviour
{
    Difficulty currentDiff;

    [SerializeField]
    DifficultySettings diffSet;

    public bool _isEasy
    {
        get { return diffSet.isEasy; }
    }

    public bool _isNormal
    {
        get { return diffSet.isNormal; }
    }

    public bool _isHard
    {
        get { return diffSet.isHard; }
    }

    private void Awake()
    {
        diffSet.isEasy = false;
        diffSet.isNormal = false;
        diffSet.isHard = false;
        currentDiff = GetComponent<Difficulty>();

        if (SceneManager.GetActiveScene().name != "Menu")
            LoadDifficulty();
    }

    public void SetDifficulty()
    {
        if (gameObject.name == "EasyButton")
        {
            diffSet.isEasy = true;
            diffSet.isNormal = false;
            diffSet.isHard = false;
        }
        else if (gameObject.name == "NormalButton")
        {
            diffSet.isEasy = false;
            diffSet.isNormal = true;
            diffSet.isHard = false;
        }
        else if (gameObject.name == "HardButton")
        {
            diffSet.isEasy = false;
            diffSet.isNormal = false;
            diffSet.isHard = true;
        }

        try
        {
            SaveDifficulty(diffSet);
            SceneManager.LoadScene("_Complete-Game");
        }
        catch(System.Exception e)
        {
            Debug.LogError("Failed to save difficulty settings!");
        }
    }

    private void SaveDifficulty(DifficultySettings difficulty)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/difficulty.txt");
        bf.Serialize(file, difficulty);
        file.Close();
    }

    private void LoadDifficulty()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/difficulty.txt", FileMode.Open);
            DifficultySettings newDifficulty = (DifficultySettings)bf.Deserialize(file);
            file.Close();

            diffSet.isEasy = newDifficulty.isEasy;
            diffSet.isNormal = newDifficulty.isNormal;
            diffSet.isHard = newDifficulty.isHard;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed To Load Selected Difficulty Setting" + e.Message);
            diffSet.isNormal = true;
        }
    }
}
