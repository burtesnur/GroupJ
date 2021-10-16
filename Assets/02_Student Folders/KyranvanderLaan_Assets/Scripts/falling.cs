using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    public float fallSpeed = 8.0f;
    public Collider triggerZone;
    private Rigidbody rb;
    public Health playerHealth;
    public float damageTaken = 50f;
    public AudioSource breakingIce;
    private bool AudioPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; 
        breakingIce = GetComponent<AudioSource> ();
        breakingIce.time = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rb.useGravity = true;
            if(!AudioPlayed)
            {
                breakingIce.Play ();
                AudioPlayed = true;
            }
            
        }
    }

    void OnCollisionEnter(Collision box)
    {
        if(box.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }else{
            playerHealth.TakeDamage(damageTaken, this.gameObject);

            Destroy(this.gameObject);
        }
        
    }
}
