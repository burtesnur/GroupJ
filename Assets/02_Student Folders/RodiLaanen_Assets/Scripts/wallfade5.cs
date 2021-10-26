using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallfade5 : MonoBehaviour
{
  public GameObject wall1;
    Collider triggerZone;

    bool changeWalls = false;

    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>();
        wall1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(changeWalls){
            if(wall1.transform.localScale.y <= 0.0f){
                wall1.SetActive(false);
                changeWalls = !changeWalls; 
            }
            else{
                wall1.transform.localScale -= new Vector3(0f, 1.05f, 0f) * Time.deltaTime;
            }
        } 
    }

    private void OnTriggerEnter (Collider other){
        if(other.gameObject.tag == "player"){
            changeWalls = !changeWalls;
        }   
    }
}
