using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnHouse : MonoBehaviour
{
    public Transform posHouse;
    public Transform Player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.transform.position = posHouse.transform.position;
        }
    }
}
