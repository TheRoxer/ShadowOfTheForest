using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject slime;
    public float SpawnRate = 2;
    private float timer = 0;
    public float heightOffset = 5;
    public float widthOffset = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnSlime();
            timer = 0;
        }
    }
    void spawnSlime()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highest = transform.position.y + heightOffset;
        float leftpoint = transform.position.x - widthOffset;
        float rightpoint = transform.position.x + widthOffset;

        Instantiate(slime, new Vector3(Random.Range(leftpoint, rightpoint), Random.Range(lowestPoint,highest),0), transform.rotation);
    }
}
