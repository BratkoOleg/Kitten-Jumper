using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{

    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

    }
}
