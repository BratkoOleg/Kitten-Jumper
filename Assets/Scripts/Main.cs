using System;
using System.Collections;
using System.Collections.Generic;
using YG;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class Main : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestscoreUI;
    public int BestScore;
    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetData;
    }

    public async void GetData()
    {
        while(!YandexGame.SDKEnabled)
        {
            await Task.Delay(200);
        }
        Task.Delay(100);
        int BestScore = PlayerPrefs.GetInt("score");
        YandexGame.NewLeaderboardScores("Platforms", BestScore);

        bestscoreUI.text = BestScore.ToString();
        Debug.Log("loaded YA");
    }
}
