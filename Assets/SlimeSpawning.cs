using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawning : MonoBehaviour
{
    public GameObject slime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
