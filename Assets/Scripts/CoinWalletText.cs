using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinWalletText : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    private TextMeshProUGUI cointext => gameObject.GetComponent<TextMeshProUGUI>();

    void Start()
    {
        _player.onTakeCoin += AddCoin;
    }

    private void OnDisable()
    {
        _player.onTakeCoin -= AddCoin;
    }

    private void AddCoin(int coins)
    {
        cointext.text = coins.ToString();
    }
}
