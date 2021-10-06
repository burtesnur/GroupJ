using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public bool OnIce = false;

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

    private void OnCollisionEnter(Collision box)
    {
        if(box.gameObject.tag == "Player")
        {
            print("Onice");
            OnIce = true;
        }
        print("Onice");
       
    }
}
