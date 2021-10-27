using UnityEngine;
using UnityEngine.Events;

public class ActivateSwitch : MonoBehaviour
{
    public GameObject button;
    void Start()
    {
        var buttonRenderer = button.GetComponent<Renderer>(); 
        buttonRenderer.material.SetColor("_Color", Color.blue);
    }

    void Update()
    {
        //OnTriggerExit(other : Collider);
    }

    void OnTriggerEnter(Collider other){
        var buttonRenderer = button.GetComponent<Renderer>();
        print("test");
        if(other.gameObject.tag == "MainCamera"){
            //gameObject.GetComponent<Renderer> ().material.color = Color.green;
            //this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            buttonRenderer.material.SetColor("_Color", Color.green);
            print("gelukt");
        }
        if(other.gameObject.tag == "Player"){
            print("player is hier");
            buttonRenderer = button.GetComponent<Renderer>();
            buttonRenderer.material.SetColor("_Color", Color.green);
        }
    }
}