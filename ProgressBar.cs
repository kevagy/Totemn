using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    public Transform TextIndicator;

    public GameSettings.EGameModeType GameModeType;

    private float TargetAmount;
    private float CurrentAmount = 0.0f;
    private float Speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmount = 0.0f;
        TextIndicator.GetComponent<Text>().text = ((0).ToString() + " ");

        switch (GameModeType)
        {
            case GameSettings.EGameModeType.E_TOTEMNTRIVIA:
                {
                    float currentFlagsPrc = ((int)Config.GetTotemnScore() / (float)GameData.Instance.CountryFactsDataSet.Length);
                    TargetAmount = (float)currentFlagsPrc * 100.0f;
                }break;

            //case GameSettings.EGameModeType.E_TOTEMNTRIVIA:
            //{
            //float temp_var = 20;
            //float currentFlagsPrc = (temp_var / (float)GameData.Instance.CountryFactsDataSet.Length);
            //TargetAmount = (float)currentFlagsPrc * 100.0f;
            //}
            //break;

            case GameSettings.EGameModeType.E_NOT_SET:
                {
                    TargetAmount = 0.0f;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentAmount < TargetAmount)
        {
            CurrentAmount += Speed * Time.deltaTime;
            TextIndicator.GetComponent<Text>().text = (((int)CurrentAmount).ToString() + " ");
            LoadingBar.GetComponent<Image>().fillAmount = (float)CurrentAmount / 100.0f;
        }
    }
}
