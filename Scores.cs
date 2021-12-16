using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text scoreText;
    private int _currentScore;
    ////public Text ScoreText;
    ////private CurrentGameData m_GameData;
    ////private int m_FlagNumber;

    ////private int m_Scores;
    ////private int m_WrongScores;
    ////private bool Initialized = false;


    // Start is called before the first frame update
    void Start()
    {
        _currentScore = 0;
        scoreText.text = _currentScore.ToString();
        ////m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData>() as CurrentGameData;
        ////m_Scores = 0;
        ////m_WrongScores = 0;
    }

    ////void Update()
    ////{
        ////if(!Initialized)
        ////{
            ////if (GameSettings.Instance.GetGameMode2() == GameSettings.EGameMode2.SHORT_MODE)
                ////m_FlagNumber = 10;
            ////else
                ////m_FlagNumber = m_GameData.GetFlagNumber();

            ////DisplayScores();
            ////Initialized = true;
        ////}
    ////}

    ////public int GetCurrentScore() { return m_Scores;}
    ////public int GetCurrentWrongScores() { return m_WrongScores;}
    ////public int GetQuestionsNumber() { return m_FlagNumber; }


    public void Addscore()
    {
        _currentScore += 10;
        scoreText.text = _currentScore.ToString();
        ////if (m_Scores < m_FlagNumber)
            ////m_Scores += 1;
        ////DisplayScores();
    }

    public void Deductscore()
    {
        _currentScore = _currentScore > 0 ? _currentScore - 10 : 0;
        scoreText.text = _currentScore.ToString();
    }

    ////public void RemoveScore()
    ////{
        ////if (m_Scores > 0)
            ////m_Scores -= 1;
        ////DisplayScores();
    ////}
    
    ////public void AddWrongScore()
    ////{
        ////if (m_WrongScores < m_FlagNumber)
            ////m_WrongScores += 1;
    ////}

    ////void DisplayScores()
    ////{
        ////string DisplayString = "Scores: " + m_Scores + "/" + m_FlagNumber;
        ////ScoreText.text = DisplayString;
    ////}

}
