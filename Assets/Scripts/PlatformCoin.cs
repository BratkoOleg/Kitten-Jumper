using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCoin : MonoBehaviour
{
    [SerializeField] float[] percentrages;
    [SerializeField] GameObject[] Objects;

    void Start()
    {
        int obj = GetNumber();
        GameObject coin; 

        if(Objects[obj] != null)
        {
            coin = Instantiate(Objects[obj]);
            coin.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, 0);
            coin.transform.SetParent(gameObject.transform);
        }
    }

    public int GetNumber()
    {
        float random = Random.Range(0f,1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i < percentrages.Length; i++)
        {
            total += percentrages[i];
        }
        for (int i = 0; i < Objects.Length; i++)
        {
            if(percentrages[i] / total + numForAdding >= random)
            {
                return i;
            }
            else
            {
                numForAdding += percentrages[i] / total;
            }
        }
        return 0;
    }
}
