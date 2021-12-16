using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [System.Serializable]
    public struct WorldData
    {
        public string Name;
        public Sprite Flag;
        public bool Guessed; //whenever the country has been guessed
        public bool BeenQuestioned;
    }

    public WorldData[] CountryFlagDataSet;
    public WorldData[] CountryFactsDataSet;
    public WorldData[] CityFactsDataSet;


    [HideInInspector]
    public WorldData[] CountrySetPerGame;
    [HideInInspector]
    public WorldData[] CountryDataSet;

    
    public static GameData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
            Config.CreateScoreFile();
        }
        else
            Destroy(this);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AssignArrayOfCountry()
    {
        CountryDataSet = new WorldData[CountryFactsDataSet.Length];
        CountryFactsDataSet.CopyTo(CountryDataSet, 0);

    }
}

