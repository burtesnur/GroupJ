using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public PlayerCharacterController player;
    public Collider triggerZone;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "Player")
        {
            player.keyHold = true;
            Destroy(this.gameObject);
        }
    }
}
