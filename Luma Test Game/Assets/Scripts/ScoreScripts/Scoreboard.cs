using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] int MaxEnteries = 10;
    [SerializeField] Transform entryContainer;
    [SerializeField] GameObject entryTemplate;


    [SerializeField] ScoreBoardEntryData data = new ScoreBoardEntryData();
    public int m_playerScore;
    public Text m_name;

    /// <summary>
    /// <see cref="savePath"/> store it according the the systems data path. Would work on mac as well
    /// </summary>
    string savePath => $"{Application.persistentDataPath}/highscores.json";

    private void Start()
    {
       ScoreSaveData savedScores =  GetSavedScores();

        SaveScores(savedScores);

        UpdateUI(savedScores);
    }


    [ContextMenu("Add Entry")]
    public void DoAddEntry()
    {
        data.entryName = m_name.text;
        data.entryScore = m_playerScore;
        AddEntry(data);
    }


    /// <summary>
    /// We check if the scores have been added. If they have not been added we add the entry by looping through and finding an empy entry
    /// </summary>
    /// <param name="scoreBoardEntryData"></param>
    public void AddEntry(ScoreBoardEntryData scoreBoardEntryData)
    {
        ScoreSaveData savedScores = GetSavedScores();
        bool scoreAdded = false;

        for (int i = 0; i < savedScores.highScores.Count; i++)
        {
            if(scoreBoardEntryData.entryScore > savedScores.highScores[i].entryScore)
            {
                savedScores.highScores.Insert(i, scoreBoardEntryData);
                scoreAdded = true;
                break;
            }
        }

        if(!scoreAdded && savedScores.highScores.Count < MaxEnteries)
        {
            savedScores.highScores.Add(scoreBoardEntryData);
        }

        if(savedScores.highScores.Count > MaxEnteries)
        {
            savedScores.highScores.RemoveRange(MaxEnteries, savedScores.highScores.Count - MaxEnteries);
        }

        UpdateUI(savedScores);
        SaveScores(savedScores);
    }

    /// <summary>
    /// We update the UI with the saved data. Destroy the child gameobjects to refresh and repopulate as child
    /// </summary>
    /// <param name="savedScores"></param>
    void UpdateUI(ScoreSaveData savedScores)
    {
        foreach (Transform child in entryContainer)
        {
            Destroy(child.gameObject);    
        }

        foreach (ScoreBoardEntryData  hs in savedScores.highScores)
        {
            Instantiate(entryTemplate, entryContainer).GetComponent<ScoreBoardEntryUI>().Initialise(hs);
        }
    }

    /// <summary>
    /// Checking if the file exists. if theres a blank file we wont read and instead return the save data
    /// If we have data in our file we are just reading the file and storing it into the "json" string and converts it into the json data type
    /// </summary>
    /// <returns></returns>
    private ScoreSaveData GetSavedScores()
    {
        if (!File.Exists(savePath))
        {
            File.Create(savePath).Dispose();
            return new ScoreSaveData();
        }

        using(StreamReader stream = new StreamReader(savePath))
        {
            string json = stream.ReadToEnd();
            return JsonUtility.FromJson<ScoreSaveData>(json);
        }
    }


    /// <summary>
    /// We save the data using streamwritter to the file format by parsing in the data from the ScoreSaveData script
    /// We are enabling pretty print to make it easier to read if we need to.
    /// </summary>
    /// <param name="scoreSaveData"></param> Our Data that needs to save
    void SaveScores(ScoreSaveData scoreSaveData)
    {
        using(StreamWriter stream = new StreamWriter(savePath))
        {
            string json = JsonUtility.ToJson(scoreSaveData, true);
            stream.Write(json);
        }
    }
}


/// <summary>
/// our struct containint the values needed for the scoreboard
/// </summary>
[Serializable]
public struct ScoreBoardEntryData
{
    public string entryName;
    public int entryScore;

    public void GetScore(int playerScore)
    {
        entryScore = playerScore;
    }
}

