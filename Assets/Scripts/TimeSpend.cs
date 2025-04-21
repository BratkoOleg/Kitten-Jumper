using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeSpend : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private TextMeshProUGUI text => gameObject.GetComponent<TextMeshProUGUI>();

    private void OnEnable()
    {
        text.text = "Твое время: " +  timerText.text;
    }
}
