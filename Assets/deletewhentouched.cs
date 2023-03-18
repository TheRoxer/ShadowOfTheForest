using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletewhentouched : MonoBehaviour
{
    public GameObject p3;

    void OnCollisionEnter(Collision col)
    {
        {
            if(col.gameObject.name == "Square")
            {
                Debug.Log("Collision detected");
                p3.GetComponent<Renderer>().enabled = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
