using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleswitchChild : MonoBehaviour
{
    public GameObject button;

    public bool childhit = false;
    //bool ishit = false;
    // Start is called before the first frame update
    void Start()
    {
        var buttonRenderer = button.GetComponent<Renderer>(); 
        buttonRenderer.material.SetColor("_Color", Color.green);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    { 
        childhit = true;
    }
}
