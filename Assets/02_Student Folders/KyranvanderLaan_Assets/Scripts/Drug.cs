using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : MonoBehaviour
{
    public bool Drugged = false;

    public PlayerCharacterController Slow;
    public Collider pickupTrigger;
    private Rigidbody pickupRigidbody;
    public float timer = 10f;

    void Start()
    {
        pickupRigidbody = GetComponent<Rigidbody>();
        pickupTrigger = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Drugged && timer > 0f){
            Slow.maxSpeedOnGround = 20f;
            timer -= Time.deltaTime;
        }else if(Drugged){
            Drugged = false;
            Slow.maxSpeedOnGround = 10f;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Drugged = true;
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
       
    }
}
