using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletewhentouched : MonoBehaviour
{
    public GameObject p3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
