using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingwall : MonoBehaviour
{
    public Collider trigger;
    public float timer = 1f;
    public Transform wall1;
    private bool shouldMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove && timer > 0f)
        {
            wall1.Translate(-Time.deltaTime * 5f, 0, 0);
            timer -= Time.deltaTime;
            print(timer);
        }else{
            shouldMove = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            shouldMove = true;
        }
    }
  
}
