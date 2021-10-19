using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;
    public Transform presser;
    public Collider trigger;
    public Light lt;

    private bool shouldMove = false;
    private float timer = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        var buttonRenderer = button.GetComponent<Renderer>(); 
        buttonRenderer.material.SetColor("_Color", Color.green);
        lt.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove && timer > 0f){
            presser.Translate(0, 0, -Time.deltaTime * 2f);
            timer -= Time.deltaTime;
        }else{
            shouldMove = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var buttonRenderer = button.GetComponent<Renderer>(); 
        if(other.gameObject.tag == "Player"){
            shouldMove = true;
            lt.color = Color.red;
            buttonRenderer.material.SetColor("_Color", Color.red); 
        }
    }
}
