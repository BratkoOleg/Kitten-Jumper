using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour
{
    [SerializeField] private GameObject cameraf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0, cameraf.transform.position.y, 0);
        gameObject.transform.localScale = new Vector3(cameraf.GetComponent<Camera>().orthographicSize * 0.3f, cameraf.GetComponent<Camera>().orthographicSize * 0.3f, 0);
    }
}
