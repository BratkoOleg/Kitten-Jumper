using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadZone : MonoBehaviour
{
    public int speed = 1;
    public TextMeshProUGUI textTimer;
    public float time = 5f;
    public GameObject Convas;
    private bool isStop;
    public PlatformsGenrator platformsGenrator;

    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            textTimer.text = time.ToString("0");
        }
        else if(isStop != true)
        {
            Convas.SetActive(false);
            transform.Translate(0, speed * Time.deltaTime, 0); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Destroy(other.gameObject);
            platformsGenrator.platformCount--;
        }

        if(other.gameObject.tag == "deadzonestop")
        {
            isStop = true;
        }
    }
}
