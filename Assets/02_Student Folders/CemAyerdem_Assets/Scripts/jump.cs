using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    // Start is called before the first frame update
    public int force = 500;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter(Collision collision)
  {
      GameObject block = collision.gameObject;
      Rigidbody rb = block.GetComponent<Rigidbody>();
      rb.AddForce(Vector3.up * force);

  }
}