using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : MonoBehaviour
{
    private bool Drugged = false;
    private bool After = false;

    public PlayerCharacterController Speed;
    public PlayerWeaponsManager Weapon;
    public Collider pickupTrigger;
    public float timer = 10f;

    void Start()
    {
        pickupTrigger = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Drugged && timer > 0f){
            Speed.maxSpeedOnGround = 20f;
            Speed.maxSpeedInAir = 20f;
            Weapon.bobFrequency = 20f;
            timer -= Time.deltaTime;
        }else if(Drugged){
            Drugged = false;
            After = true;
        }
        if(After && timer > -10f){
            Speed.maxSpeedOnGround = 5f;
            Speed.maxSpeedInAir = 5f;
            Weapon.bobFrequency = 5f;
            timer -= Time.deltaTime;
        }else if(After){
            After = false;
            Speed.maxSpeedOnGround = 10f;
            Speed.maxSpeedInAir = 10f;
            Weapon.bobFrequency = 10f;
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
