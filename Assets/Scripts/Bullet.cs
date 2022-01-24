using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemySpawn enemy;
    public int bulletDamage;
    public int healthCur;
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
