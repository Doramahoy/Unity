using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawn : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Создание снаряда
    public GameObject whichIsBullet;
    public Transform PosSpawnFireball;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(whichIsBullet, PosSpawnFireball.position, Quaternion.identity);
        }

    }
}
