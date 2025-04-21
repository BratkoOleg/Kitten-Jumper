using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadZoneDistantion : MonoBehaviour
{
    private TextMeshProUGUI textTimer => gameObject.GetComponent<TextMeshProUGUI>();
    [SerializeField] private GameObject deadzone;
    [SerializeField] private GameObject player;
    [SerializeField] private float distantionk;

    private void Update()
    {
        distantionk = Vector3.Distance (player.transform.position, deadzone.transform.position);
        textTimer.text = distantionk.ToString("0.0" + "m");
    }
}
