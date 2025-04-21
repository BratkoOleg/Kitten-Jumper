using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    private Button button => gameObject.GetComponent<Button>();

    private void OnEnable()
    {
        button.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

