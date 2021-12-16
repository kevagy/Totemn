using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameData2 : MonoBehaviour
{
    [System.Serializable]
    public struct WorldData2
    {
        [FormerlySerializedAs("Name")]
        public Sprite CountryFlag;
        [FormerlySerializedAs("Flag3")]
        public Sprite Flag;
        public string CountryName;
        public bool Guessed; //whenever the country has been guessed
        public bool BeenQuestioned;
    }

    public WorldData2[] CountryLocationDataSet;
    public WorldData2[] CountryFlagDataSet2;


    [HideInInspector]
    public WorldData2[] CountrySetPerGame;
    [HideInInspector]
    public WorldData2[] CountryDataSet;


    public static GameData2 Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
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
        CountryDataSet = new WorldData2[CountryLocationDataSet.Length];
        CountryLocationDataSet.CopyTo(CountryDataSet, 0);

    }
}