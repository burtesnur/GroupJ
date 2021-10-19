using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_damage : MonoBehaviour
{
    public Health playerHealth;
    public float damageTaken = 50f;
    public Collider triggerZone;
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
        if(other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damageTaken, this.gameObject);
        }
    }
}
