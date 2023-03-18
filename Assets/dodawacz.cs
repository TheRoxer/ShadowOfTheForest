using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodawacz : MonoBehaviour
{
    public GameObject[] boxes;
    public logicscript logic;
        void Start()
        {
            logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addScore();
    }
}
