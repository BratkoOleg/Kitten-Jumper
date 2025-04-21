using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI textTimer => gameObject.GetComponent<TextMeshProUGUI>();
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        textTimer.text = time.ToString("0.0");
    }
}
