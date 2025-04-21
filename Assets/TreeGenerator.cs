using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public Transform leftpoint;
    public Transform rightpoint;

    public GameObject treeleft;
    public GameObject treeright;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "deadzonestop")
        {
            GameObject newtreeL = Instantiate(treeleft);
            GameObject newtreeR = Instantiate(treeright);

            newtreeL.transform.position = new Vector3(-8.65f, leftpoint.position.y, 0);
            newtreeR.transform.position = new Vector3(8.35f, rightpoint.position.y, 0);

            gameObject.transform.position = new Vector3(0, transform.position.y + 7.55f, 0);
        }
    }
}
