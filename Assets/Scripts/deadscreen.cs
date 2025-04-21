using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class deadscreen : MonoBehaviour
{
    [SerializeField] private Button restartl;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Main main;
    // Start is called before the first frame update
    void Start()
    {
        restartl.onClick.AddListener(restartGame);
    }
    
    private void OnDisable()
    {
        restartl.onClick.RemoveAllListeners();
    }

    private void OnEnable()
    {
        text.text = PlayerPrefs.GetInt("currentScore").ToString();
    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
