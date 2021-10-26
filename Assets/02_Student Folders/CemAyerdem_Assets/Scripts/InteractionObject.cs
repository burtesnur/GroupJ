using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public PlayerCharacterController player;
    public float jumpforce = 9f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {    
        Vector3 characterVelocity1 = new Vector3(0f, 0f, 0f);
        characterVelocity1 += Vector3.up * jumpforce;
        player.characterVelocity += characterVelocity1;
        print("Player found");    
        //player.jumpForce = 20f;
    }
}
