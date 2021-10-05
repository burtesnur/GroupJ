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
    // Start is called before the first frame update
    void Start()
    {
        print("Hello");
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Yes");
            rb.useGravity = true;
        }
    }

    void OnCollisionEnter(Collision box)
    {
        if(box.gameObject.tag != "Player")
        {
            print("ground");
            Destroy(this.gameObject);
        }else{
            playerHealth.TakeDamage(damageTaken, this.gameObject);

            Destroy(this.gameObject);
        }
        
    }
}
