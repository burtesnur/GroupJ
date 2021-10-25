using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public PlayerCharacterController player;
    public GameObject pc;
    public Collider triggerZone;
    
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player");
        player = (PlayerCharacterController)pc.GetComponent(typeof(PlayerCharacterController));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.keyHold = true;
            Destroy(this.gameObject);
        }
    }
}
