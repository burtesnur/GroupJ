using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    public float fallSpeed = 8.0f;
    public Collider triggerZone;
    bool isfalling = false;
    // Start is called before the first frame update
    void Start()
    {
        getComponent<Collider>();
        print("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        if(isfalling){
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        print("Yes");
        isfalling = true;
        if(collision.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
    }
}
