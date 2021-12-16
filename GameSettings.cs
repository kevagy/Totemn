using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private Dictionary<EGameModeType, string> _SceneName = new Dictionary<EGameModeType, string>();

    public enum EGameMode2
    {
        NOTE_SET,
        TIME_TRAIL_MODE, //play until time expires
        //SURVIVAL_MODE,
        SHORT_MODE, //10 questions
    }

    public enum EGameModeType
    {
        E_NOT_SET = 0,
        E_TOTEMNTRIVIA,
        E_IMAGESMEDIA,
        E_EVENTS,
        E_ANCESTRY,
        E_SURVEYS,

    };

    private EGameMode2 _GameMode2;

    private EGameModeType _GameMode;
    private string _GameModeName;

    public static GameSettings Instance;

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
        SetSceneNameAndType();
        _GameMode2 = EGameMode2.NOTE_SET;
        _GameMode = EGameModeType.E_NOT_SET;
    }

    private void SetSceneNameAndType()
    {
        _SceneName.Add(EGameModeType.E_TOTEMNTRIVIA, "Game");
        _SceneName.Add(EGameModeType.E_IMAGESMEDIA, "Game");
        _SceneName.Add(EGameModeType.E_EVENTS, "Game");
        _SceneName.Add(EGameModeType.E_ANCESTRY, "Game");
        _SceneName.Add(EGameModeType.E_SURVEYS, "Game");

    }

    public string GetGameModeSceneName()
    {
        string name;

        if(_SceneName.TryGetValue(_GameMode, out name))
        {
            return name;
        }
        else
        {
            Debug.Log("ERROR: GAMEMODE SCENE NOT FOUND");
            return ("ERROR: GAMEMODE SCENE NOT FOUND");
        }
    }

    public void SetGameModeType(EGameModeType type)
    {
        _GameMode = type;
    }

    public void SetGameMode2(EGameMode2 mode2)
    {
        _GameMode2 = mode2;
    }

    public EGameMode2 GetGameMode2()
    {
        return _GameMode2;
    }

    public EGameModeType GetGameModeType()
    {
        return _GameMode;
    }

    public void SetGameModeName(string Name)
    {
        SetGameModeType(GetGameModeTypeFromString(Name));
        _GameModeName = Name;
    }

    private EGameModeType GetGameModeTypeFromString(string type)
    {
        switch(type)
        {
            case "TOTEMNTRIVIA": return EGameModeType.E_TOTEMNTRIVIA;
            case "IMAGESMEDIA": return EGameModeType.E_IMAGESMEDIA;
            case "EVENTS": return EGameModeType.E_EVENTS;
            case "ANCESTRY": return EGameModeType.E_ANCESTRY;
            case "SURVEYS": return EGameModeType.E_SURVEYS;
            default: return EGameModeType.E_NOT_SET;
        }
    }



}
