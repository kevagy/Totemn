using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public float timeLeft;
    private CurrentGameData m_GameData;

    public GUIStyle ClockStyle;

    private bool StartedGameOverTimer = false;

    //GameOver
    public GUIStyle GameOverStyle;
    public GameObject GameOverPanel;
    public GameObject CorrectGuessedText;
    public GameObject WrongGuessedText;

    private Scores m_Scores;

    private bool EndGuiActivated;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartedGameOverTimer = false;
        EndGuiActivated = false;
        m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData>() as CurrentGameData;
        ////m_Scores = GameObject.Find("Main Camera").GetComponent<Scores>() as Scores;

        if (GameSettings.Instance.GetGameMode2() == GameSettings.EGameMode2.TIME_TRAIL_MODE)
            this.enabled = true;
        else
            this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; 

        if(EndGuiActivated && StartedGameOverTimer == false)
        { 
             StartedGameOverTimer = true;
             StartCoroutine(Sleep(2.0f));
            
        }
    }

    void OnGUI()
    {
        if(timeLeft > 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 20, 10, 200, 100), "" + (int)timeLeft, ClockStyle);
        }
        else

        {
            if (m_GameData.HasGameFinished() == false && EndGuiActivated == true)
            {
                m_GameData.SetGameOver();
            }

            ActivateGameOverGui();
        }
        
    }

    IEnumerator Sleep(float SleepTime)
    {
        yield return new WaitForSeconds(SleepTime);


        ActivateGameOverGui();
    }

    private void ActivateGameOverGui()
    {
        ////CorrectGuessedText.GetComponent<Text>() = m_Scores.GetCurrentScore().ToString();
        ////WrongGuessedText.GetComponent<Text>() = m_Scores.GetCurrentWrongScore().ToString();

        GameOverPanel.SetActive(true);
        EndGuiActivated = true;

    }
}
