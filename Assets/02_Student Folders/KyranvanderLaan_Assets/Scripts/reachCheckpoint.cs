using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachCheckpoint : MonoBehaviour
{
    public GameObject flag;
    public Transform flagMover;
    public Collider trigger;
    public int ID;
    public float timer = 1.0f;

    private bool shouldMove = false;
    // Start is called before the first frame update
    void Start()
    {
        var flagRenderer = flag.GetComponent<Renderer>(); 
        flagRenderer.material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove && timer > 0f){
            flagMover.Translate(0, 0, Time.deltaTime * 2f);
            timer -= Time.deltaTime;
        }else{
            shouldMove = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var flagRenderer = flag.GetComponent<Renderer>(); 
        if(other.gameObject.tag == "Player"){
            shouldMove = true;
            Checkpoint.hasReached[ID] = true;
            flagRenderer.material.SetColor("_Color", Color.green);
        }
    }

}
