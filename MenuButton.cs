using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject mGuiPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAndClearData(string sceneName)
    {
        CurrentGameData.AllowDestroyOnLoad = true;
        SceneManager.LoadScene(sceneName);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void ShowGameModePanel()
    {
        mGuiPanel.SetActive(true);
    }

    public void HideGameModePanel()
    {
        mGuiPanel.SetActive(false);
    }

    public void StartTimeTrail()
    {
        GameSettings.Instance.SetGameMode2(GameSettings.EGameMode2.TIME_TRAIL_MODE);
        LoadScene(GameSettings.Instance.GetGameModeSceneName());
    }

    public void StartShortGame()
    {
        GameSettings.Instance.SetGameMode2(GameSettings.EGameMode2.SHORT_MODE);
        LoadScene(GameSettings.Instance.GetGameModeSceneName());
    }

    public void ShortGameTimeTrial()
    {
        GameSettings.Instance.SetGameMode2(GameSettings.EGameMode2.SHORT_MODE);
        LoadScene(GameSettings.Instance.GetGameModeSceneName());
        GameSettings.Instance.SetGameMode2(GameSettings.EGameMode2.TIME_TRAIL_MODE);
        LoadScene(GameSettings.Instance.GetGameModeSceneName());

    }


}