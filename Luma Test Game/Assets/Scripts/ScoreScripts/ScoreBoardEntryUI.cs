using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;


public class ScoreBoardEntryUI : MonoBehaviour
{

    [SerializeField] Text entryNameText;
    [SerializeField] Text entryScoreText;

    public void Initialise(ScoreBoardEntryData scoreBoardEntryData)
    {
        entryNameText.text = scoreBoardEntryData.entryName;
        entryScoreText.text = scoreBoardEntryData.entryScore.ToString();
    }
}

[Serializable]
public class ScoreSaveData
{
    public List<ScoreBoardEntryData> highScores = new List<ScoreBoardEntryData>();
}