using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AbyssAnimDelayer : MonoBehaviour
{
    public List<GameObject> shadows;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            shadows.Add(gameObject.transform.GetChild(i).gameObject);
        }
        StartCoroutine(StartSpawm());
    }

    private IEnumerator StartSpawm()
    {
        int i = 0;

        while(i < shadows.Count)
        {
            float time = SetRandomTime();
            shadows[i].gameObject.SetActive(true);
            i++;
            yield return new WaitForSeconds(time);
        }

        StopCoroutine(StartSpawm());
    }

    private float SetRandomTime()
    {
        float time = Random.Range(0.1f, 0.5f);
        return time;
    }
}
