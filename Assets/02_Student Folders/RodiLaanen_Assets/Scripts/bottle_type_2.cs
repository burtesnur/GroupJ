using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle_type_2 : MonoBehaviour
{
  public PlayerCharacterController pcc;
    public Collider pickBottle;
    public AudioSource floatingMusic;
    public GameObject newBottle;
    public ParticleSystem pc;
    public bool particleChildren, fly, zeroGrav, jumpPower;
    private float flyTime, jumpTime, jumpTimer, flyTimer, playerCurrenty;

    void Start()
    {
        pickBottle = GetComponent<Collider>();
        floatingMusic.Stop();
        particleChildren = true;
        fly = false;
        zeroGrav = false;
        jumpPower = false;
        flyTime = 1.0f;
        jumpTime = 8.0f;
        jumpTimer = 0.0f;
        flyTimer = 0.0f; 
    }

    // Update is called once per frame
    void Update()
    {
        if(jumpPower){
            pcc.jumpForce = 12;
            if(zeroGrav){
                pcc.gravityDownForce = 0.0f;
                flyTimer += Time.deltaTime;
                pcc.characterVelocity = new Vector3(pcc.characterVelocity.x, 0.0f, pcc.characterVelocity.z);
            }
            else{
                pcc.gravityDownForce = 15;
                
            }
            if(Input.GetKeyDown("space")){
                if(!fly){
                    playerCurrenty = pcc.transform.localPosition.y;
                    flyTimer = 0.0f;
                }  
            }
            if(pcc.transform.localPosition.y >= playerCurrenty + 4.60f && flyTime >= 0){
                fly = true;
                zeroGrav = true;
                pcc.transform.position = new Vector3(pcc.transform.localPosition.x, playerCurrenty + 4.60f, pcc.transform.localPosition.z);
            }
            if(flyTimer >= flyTime){
                pcc.gravityDownForce = 15f;
                fly = false;
                zeroGrav = false;
            }
            jumpTimer += Time.deltaTime;
            if(jumpTimer >= jumpTime){
                pcc.jumpForce = 9f;
                pcc.gravityDownForce = 25f;
                jumpPower = !jumpPower;
                floatingMusic.Stop();
                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                Instantiate(newBottle, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    public void OnTriggerEnter (Collider other){
        if(other.gameObject.tag == "player"){
            jumpPower = !jumpPower;
            floatingMusic.Play();
            this.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
            pc.Stop(particleChildren, ParticleSystemStopBehavior.StopEmittingAndClear);
        }   

    }
}