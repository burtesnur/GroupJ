using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDown : MonoBehaviour
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
            if(timer < 1.5f)
            {
                wall1.Translate(0, -Time.deltaTime * 5f, 0);
            }
            timer -= Time.deltaTime;
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
