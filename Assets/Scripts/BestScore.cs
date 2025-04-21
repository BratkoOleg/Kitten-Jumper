using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScore : MonoBehaviour
{
    [SerializeField] private Main main;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = PlayerPrefs.GetInt("score").ToString();
        Debug.Log("loaded prefs " + PlayerPrefs.GetInt("score").ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
