using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameModeButton : MonoBehaviour
{
    public string Name;

    public void onClick()
    {
        GameSettings.Instance.SetGameModeName(Name);
    }

}
