using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbottle : MonoBehaviour
{
    public PlayerCharacterController pcc;
    public GameObject test;
    public Collider pickBottle;
    public AudioSource floating;
    public ParticleSystem pc;
    public bool includeChildren = true;
    public bool jumpHigh = false;
    public float inAirTimer = 0.1f;
    private float flyTime = 1.6f;
    private float jumpTime = 5.0f;
    public float counter = 0.0f;
    public float flyCounter = 0.0f;
    public bool fly = false;
    public bool zeroGrav = false;
    public float playerCurrenty;

    void Start()
    {
        pickBottle = GetComponent<Collider>();
        floating.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(jumpHigh){

            if(zeroGrav){
                pcc.gravityDownForce = 0.00000f;
                flyCounter += Time.deltaTime;
                pcc.characterVelocity = new Vector3(pcc.characterVelocity.x, 0.0f, pcc.characterVelocity.z);
                Debug.Log(flyCounter);
            }
            else{
                pcc.gravityDownForce = 15;
                
            }
            pcc.jumpForce = 12;

            if(Input.GetKeyDown("space")){
                if(!fly){
                    playerCurrenty = pcc.transform.localPosition.y;
                    flyCounter = 0.0f;
                    Debug.Log(playerCurrenty);
                }  
            }

            if(pcc.transform.localPosition.y >= playerCurrenty + 4.60f && flyTime >= 0){
                fly = true;
                zeroGrav = true;
                pcc.transform.position = new Vector3(pcc.transform.localPosition.x, playerCurrenty + 4.60f, pcc.transform.localPosition.z);
                
                

            }
            if(flyCounter >= flyTime){
                pcc.gravityDownForce = 15f;
                fly = false;
                zeroGrav = false;
            }
            
            counter += Time.deltaTime;
            
            if(counter >= jumpTime){
                Debug.Log("Jump time is over");
                pcc.jumpForce = 9f;
                pcc.gravityDownForce = 25f;
                jumpHigh = !jumpHigh;
                floating.Stop();
                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                GameObject duplicate = Instantiate(test);
                duplicate.transform.position = gameObject.transform.position;
                this.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                

            }
        }
    }

    public void OnTriggerEnter (Collider other){
        if(other.gameObject.tag == "player"){
            Debug.Log("weet dat het een player is");
            jumpHigh = !jumpHigh;
            floating.Play();
            this.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
            pc.Stop(includeChildren, ParticleSystemStopBehavior.StopEmittingAndClear);
        }   

    }
}
