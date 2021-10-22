using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield2 : MonoBehaviour
{
    public GameObject shield;
    public GameObject shield2;
    Collider triggerZone;
    PlayerCharacterController pcc;
    private bool activeShield = false;
    private bool activeShield2 = false;
    bool checknow = false;
    public float speed = 5f;
    public float delayShield = 5f;
    public float delayFloor = 5f;
    float countdownShield;
    float countdownFloor;
    Vector3 pccPosition;
    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>();
        shield.SetActive(false);
        shield2.SetActive(true);
        pcc = GetComponent<PlayerCharacterController>();
        countdownShield = delayShield;
        countdownFloor = delayFloor;
    }

    // Update is called once per frame
    void Update()
    {   

        if(checknow){
            shield.SetActive(true);
            shield2.SetActive(false);
            countdownShield -= Time.deltaTime;
            Debug.Log("Shield countdown");
        }
        if(countdownShield <= 0f){
            Debug.Log("floor countdown");
            shield.SetActive(false);
            shield2.SetActive(true);
            checknow = false;
            countdownFloor -= Time.deltaTime;
        }

        if(countdownFloor <= 0f){
            Debug.Log("Floor should work again");
            countdownShield = delayShield;
            countdownFloor = delayFloor;
        }



    }
    
    void OnTriggerEnter (Collider other){
        if(countdownFloor == 5f){
            if(!checknow){
            checknow = true;
            }
        }   

    }
}
