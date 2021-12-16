using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGameData2 : MonoBehaviour
{
    [HideInInspector]
    public int FirstFlagIndex = 0;
    [HideInInspector]
    public int SecondFlagIndex;
    [HideInInspector]
    public int ThirdFlagIndex;
    [HideInInspector]
    public int FinalFlagIndex;

    private int PrevFinalFlagIndex;
    private int CountriesPerGame = 120; // How many Countries should be in One Game.
    private bool GameFinished = false;

    // Start is called before the first frame update

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        GameData2.Instance.AssignArrayOfCountry();

        if (CountriesPerGame >= GameData2.Instance.CountryDataSet.Length)
            CountriesPerGame = GameData2.Instance.CountryDataSet.Length;

        GameData2.Instance.CountrySetPerGame = new GameData2.WorldData2[CountriesPerGame];

        GameFinished = false;

        PickCountriesForGame();
        GetNewCountries();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickCountriesForGame()
    {
        int PickedCountryNumber = 0;

        for (int Index = 0; Index < GameData2.Instance.CountryDataSet.Length; Index++)
        {
            if (PickedCountryNumber >= CountriesPerGame)
                break;
            else
            {
                if (GameData2.Instance.CountryDataSet[Index].Guessed == false)
                {
                    GameData2.Instance.CountrySetPerGame[PickedCountryNumber] = GameData2.Instance.CountryDataSet[Index];
                    PickedCountryNumber++;
                }
            }
        }

        if (PickedCountryNumber < CountriesPerGame - 1)
        {
            //If we do not have enough countries, select random which were guessed.
            for (int Index = 0; Index < GameData2.Instance.CountryDataSet.Length; Index++)
            {
                if (PickedCountryNumber >= CountriesPerGame)
                    break;
                else
                {
                    if (GameData2.Instance.CountryDataSet[Index].Guessed == true)
                    {
                        GameData2.Instance.CountrySetPerGame[PickedCountryNumber] = GameData2.Instance.CountryDataSet[Index];
                        PickedCountryNumber++;
                    }
                }
            }
        }

    }


    public void GetNewCountries()
    {
        PrevFinalFlagIndex = FinalFlagIndex;

        if (GetNumberOfFlagsLeft() > 0)
        {
            do
            {
                FinalFlagIndex = (int)Random.Range(0, GameData.Instance.CountrySetPerGame.Length);
            } while (PrevFinalFlagIndex == FinalFlagIndex || GameData2.Instance.CountrySetPerGame[FinalFlagIndex].Guessed == true);

            do
            {
                FirstFlagIndex = (int)Random.Range(0, GameData2.Instance.CountrySetPerGame.Length);
            } while (FirstFlagIndex == FinalFlagIndex);

            do
            {
                SecondFlagIndex = (int)Random.Range(0, GameData2.Instance.CountrySetPerGame.Length);
            } while (SecondFlagIndex == FirstFlagIndex || SecondFlagIndex == FinalFlagIndex);

            do
            {
                ThirdFlagIndex = (int)Random.Range(0, GameData2.Instance.CountrySetPerGame.Length);
            } while (ThirdFlagIndex == FirstFlagIndex || ThirdFlagIndex == SecondFlagIndex || ThirdFlagIndex == FinalFlagIndex);

            GameData2.Instance.CountrySetPerGame[FinalFlagIndex].BeenQuestioned = true;
        }
        else
        {
            //The level has been completed;
            GameFinished = true;
        }
    }

    private int GetNumberOfFlagsLeft()
    {
        int left = 0;

        for (int Index = 0; Index < GameData2.Instance.CountrySetPerGame.Length; Index++)
        {
            if (GameData2.Instance.CountrySetPerGame[Index].Guessed == false)
                left++;
        }

        return left;
    }

    public string GetFlagName(int index)
    {
        return GameData2.Instance.CountrySetPerGame[index].CountryName;
    }

    public int GetFlagNameLength(int FlagIndex)
    {
        return GameData2.Instance.CountrySetPerGame[FlagIndex].CountryName.Length;
    }


    public int GetFirstFlagIndex()
    {
        return FirstFlagIndex;
    }

    public int GetSecondFlagIndex()
    {
        return SecondFlagIndex;
    }

    public int GetThirdFlagIndex()
    {
        return ThirdFlagIndex;
    }

    public int GetFinalFlagIndex()
    {
        return FinalFlagIndex;
    }

    public void SetGuessed()
    {
        GameData2.Instance.CountrySetPerGame[FinalFlagIndex].Guessed = true;
    }

    public Sprite GetFlagSpriteIndex(int FlagIndex)
    {
        return GameData2.Instance.CountrySetPerGame[FlagIndex].Flag;
    }
}