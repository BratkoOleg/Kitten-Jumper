using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformsGenrator : MonoBehaviour
{
    public GameObject platform;
    public int platformCount;
    private GameObject previousPlatform;
    public Transform platformContainer;

    public Transform maxXPoint;
    public Transform maxYPoint;
    public Transform minXPoint;
    public Transform minYPoint;
    private float maxX;
    private float maxY;
    private float minX;
    private float minY;

    private void Start()
    {
        previousPlatform = platform;
        SetPointPositions();
        // StartCoroutine(SpanwPlatformCounter());
    }

    private void SetPointPositions()
    {
        maxX = maxXPoint.position.x; 
        maxY = maxYPoint.position.y;
        minX = minXPoint.position.x;
        minY = minYPoint.position.y;
    }

    void Update()
    {
        while(platformCount < 100)
        {
            SpanwPlatform();
        }
    }

    // private IEnumerator SpanwPlatformCounter()
    // {
    //     while(platformCount < 100)
    //     {
    //         SpanwPlatform();
    //     }
    //     yield return new WaitForSeconds(1f);
    // }

    private void SpanwPlatform()
    {
        GameObject plat = Instantiate(platform);

        plat.transform.position = SetNewPlatformRandomPosition();

        while((plat.transform.position.x - previousPlatform.transform.position.x) > 7
                || (plat.transform.position.x - previousPlatform.transform.position.x) < -7
                // || (plat.transform.position.y - previousPlatform.transform.position.y) < 0.1
                || (plat.transform.position.y - previousPlatform.transform.position.y) > 4
                || Math.Round(plat.transform.position.x - previousPlatform.transform.position.x) == 0
                || Math.Round(plat.transform.position.x - previousPlatform.transform.position.x) == 1
                || Math.Round(plat.transform.position.x - previousPlatform.transform.position.x) == -1
                || Math.Round(plat.transform.position.x - previousPlatform.transform.position.x) == 2
                || Math.Round(plat.transform.position.x - previousPlatform.transform.position.x) == -2
             )
            {
                plat.transform.position = SetNewPlatformRandomPosition();
            }

        plat.transform.SetParent(platformContainer);
        previousPlatform = plat;
        transform.Translate(0, 2, 0); 
        SetPointPositions();
        platformCount++;
    }

    private Vector3 SetNewPlatformRandomPosition()
    {
        float x;
        float y;
        x = Random.Range(minX,maxX);
        y = Random.Range(minY, maxY);
        return new Vector3(x,y, 0);
    }
}


