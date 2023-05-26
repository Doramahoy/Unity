using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawEn : MonoBehaviour
{
    public GameObject whichIsBullet;
    public Transform PosSpawnFireball;
    void Start()
    {
        
    }

    void Update()
    {
     
    }
    public void Spawn()
    {

            Instantiate(whichIsBullet, PosSpawnFireball.position, Quaternion.identity);

    }
}
