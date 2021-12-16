using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagManager2 : MonoBehaviour
{
    public GameObject[] FlagsObjects;
    public Text DisplayedText;
    private int NumberOfFlagsObjects = 0;

    //Flag data
    private CurrentGameData2 m_GameData;

    private bool IsFirstRun = false;

    // Start is called before the first frame update
    void Start()
    {
        NumberOfFlagsObjects = FlagsObjects.Length;
        m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData2>() as CurrentGameData2;
        IsFirstRun = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsFirstRun) FirstRun();
    }

    void FirstRun()
    {
        AssignFlags();
        StartCoroutine(LoopRotation(90f));
        UpdateDisplayedText();
        IsFirstRun = false;

    }

    public void LoadNextGame()
    {
        StartCoroutine(LoopRotation(90f));
        m_GameData.GetNewCountries();
        UpdateDisplayedText();
    }


    public void AssignFlags()
    {
        int FinalFlagPosition = (int)Random.Range(0, NumberOfFlagsObjects);

        switch (FinalFlagPosition)
        {
            case 0:
                FlagsObjects[0].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFinalFlagIndex());
                FlagsObjects[1].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFirstFlagIndex());
                FlagsObjects[2].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetSecondFlagIndex());
                FlagsObjects[3].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetThirdFlagIndex());

                FlagsObjects[0].GetComponent<Flag>().SetFlagIndex(m_GameData.GetFinalFlagIndex());
                FlagsObjects[1].GetComponent<Flag>().SetFlagIndex(m_GameData.GetFirstFlagIndex());
                FlagsObjects[2].GetComponent<Flag>().SetFlagIndex(m_GameData.GetSecondFlagIndex());
                FlagsObjects[3].GetComponent<Flag>().SetFlagIndex(m_GameData.GetThirdFlagIndex());
                break;
            case 1:
                FlagsObjects[0].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFirstFlagIndex());
                FlagsObjects[1].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFinalFlagIndex());
                FlagsObjects[2].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetSecondFlagIndex());
                FlagsObjects[3].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetThirdFlagIndex());

                FlagsObjects[0].GetComponent<Flag>().SetFlagIndex(m_GameData.GetFirstFlagIndex());
                FlagsObjects[1].GetComponent<Flag>().SetFlagIndex(m_GameData.GetFinalFlagIndex());
                FlagsObjects[2].GetComponent<Flag>().SetFlagIndex(m_GameData.GetSecondFlagIndex());
                FlagsObjects[3].GetComponent<Flag>().SetFlagIndex(m_GameData.GetThirdFlagIndex());
                break;
            case 2:
                FlagsObjects[0].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFirstFlagIndex());
                FlagsObjects[1].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetSecondFlagIndex());
                FlagsObjects[2].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFinalFlagIndex());
                FlagsObjects[3].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetThirdFlagIndex());

                FlagsObjects[0].GetComponent<Flag>().SetFlagIndex(m_GameData.GetFirstFlagIndex());
                FlagsObjects[1].GetComponent<Flag>().SetFlagIndex(m_GameData.GetSecondFlagIndex());
                FlagsObjects[2].GetComponent<Flag>().SetFlagIndex(m_GameData.GetFinalFlagIndex());
                FlagsObjects[3].GetComponent<Flag>().SetFlagIndex(m_GameData.GetThirdFlagIndex());
                break;
            case 3:
                FlagsObjects[0].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFirstFlagIndex());
                FlagsObjects[1].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetSecondFlagIndex());
                FlagsObjects[2].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetThirdFlagIndex());
                FlagsObjects[3].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFinalFlagIndex());

                FlagsObjects[0].GetComponent<Flag>().SetFlagIndex(m_GameData.GetFirstFlagIndex());
                FlagsObjects[1].GetComponent<Flag>().SetFlagIndex(m_GameData.GetSecondFlagIndex());
                FlagsObjects[2].GetComponent<Flag>().SetFlagIndex(m_GameData.GetThirdFlagIndex());
                FlagsObjects[3].GetComponent<Flag>().SetFlagIndex(m_GameData.GetFinalFlagIndex());
                break;
        }
    }

    IEnumerator LoopRotation(float angle)
    {
        float dir = 1f;
        float rotSpeed = 90.0f;
        float startAngle = angle;
        bool assigned = false;

        while (angle > 0)
        {
            float step = Time.deltaTime * rotSpeed;
            FlagsObjects[0].GetComponent<Transform>().Rotate(new Vector3(0, 2, 0) * step * dir);
            FlagsObjects[1].GetComponent<Transform>().Rotate(new Vector3(0, 2, 0) * step * dir);
            FlagsObjects[2].GetComponent<Transform>().Rotate(new Vector3(0, 2, 0) * step * dir);
            FlagsObjects[3].GetComponent<Transform>().Rotate(new Vector3(0, 2, 0) * step * dir);

            if (angle <= (startAngle / 3) && assigned == false)
            {
                AssignFlags();
                assigned = true;
            }

            angle -= 2;

            yield return null;
        }

        FlagsObjects[0].GetComponent<Transform>().rotation = Quaternion.identity;
        FlagsObjects[1].GetComponent<Transform>().rotation = Quaternion.identity;
        FlagsObjects[2].GetComponent<Transform>().rotation = Quaternion.identity;
        FlagsObjects[3].GetComponent<Transform>().rotation = Quaternion.identity;
    }

    void UpdateDisplayedText()
    {
        DisplayedText.text = m_GameData.GetFlagName(m_GameData.GetFinalFlagIndex());
    }

}
