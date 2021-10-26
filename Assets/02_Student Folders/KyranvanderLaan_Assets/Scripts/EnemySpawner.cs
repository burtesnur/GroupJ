using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private GameObject spawnedEnemy;
    public Vector3 spawnpoint;
    public Transform boss;
    private float timer = 0.0f;
    private int seconds = 0;
    private bool thisframe = false;
    public Collider start;
    public bool bossfight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossfight){
            if(seconds % 5 == 0){
                if(!thisframe){
                    thisframe = true;
                    spawnedEnemy = Instantiate(enemy, spawnpoint, Quaternion.identity);
                    spawnedEnemy.transform.SetParent(boss);
                }
            }else{
                thisframe = false;
            }
            timer += Time.deltaTime;
            seconds = (int)timer % 60;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bossfight = true;
        }
    }
}
