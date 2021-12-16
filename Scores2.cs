using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores2 : MonoBehaviour
{

    public Text ScoreText;
    private CurrentGameData m_GameData;
    private int m_FlagNumber;

    private int m_Scores;
    private int m_WrongScores;
    private bool Initialized = false;


    // Start is called before the first frame update
    void Start()
    {

        m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData>() as CurrentGameData;
        m_Scores = 0;
        m_WrongScores = 0;
    }

    void Update()
    {
        if(!Initialized)
        {
            if (GameSettings.Instance.GetGameMode2() == GameSettings.EGameMode2.SHORT_MODE)
                m_FlagNumber = 10;
            else
                m_FlagNumber = m_GameData.GetFlagNumber();

            DisplayScores();
            Initialized = true;
        }
    }

    public int GetCurrentScore() { return m_Scores;}
    public int GetCurrentWrongScores() { return m_WrongScores;}
    public int GetQuestionsNumber() { return m_FlagNumber; }


    public void Addscore()
    {

        if (m_Scores < m_FlagNumber)
        m_Scores += 10;
        DisplayScores();
    }



    public void RemoveScore()
    {
        m_Scores = m_Scores > 0 ? m_Scores - 10 : 0;
        ScoreText.text = m_Scores.ToString();
        DisplayScores();
    }

    public void AddWrongScore()
    {
        if (m_WrongScores < m_FlagNumber)
           m_WrongScores += 10;
    }

    void DisplayScores()
    {
        string DisplayString = " " + m_Scores ;
        ScoreText.text = DisplayString;
    }

}
