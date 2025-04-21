using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class CatDied : MonoBehaviour
{
    [SerializeField] private GameObject DeadScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "deadzone")
        {
            Debug.Log("died");
            gameObject.GetComponent<PlayerController>().Save();
            DeadScreen.SetActive(true);
            // YandexGame.FullscreenShow();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
