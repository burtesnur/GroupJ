using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public bool OnIce = false;
    public Collider triggerZone;
    public PlayerCharacterController Slip;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(OnIce){
            Slip.movementSharpnessOnGround = 1f;
        }else{
            Slip.movementSharpnessOnGround = 15f;
        }
    }

    private void OnTriggerEnter(Collider box)
    {
        if(box.gameObject.tag == "Player")
        {
            OnIce = true;
        }
       
    }

    private void OnTriggerExit(Collider box)
    {
        if(box.gameObject.tag == "Player")
        {
            OnIce = false;
        }
       
    }
}
