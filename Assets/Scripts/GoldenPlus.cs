using UnityEngine;

public class GoldenPlus : MonoBehaviour
{
    [SerializeField] private GameObject _wonPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You won");
            _wonPanel.SetActive(true);
        }
    }
}
