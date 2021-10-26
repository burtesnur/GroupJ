using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallfade3 : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    Collider triggerZone;

    bool changeWalls = false;

    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>();
        wall2.SetActive(false);
        wall3.SetActive(true);
        wall2.transform.localScale = new Vector3(1.0f, 0.10f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(changeWalls){
            wall1.SetActive(true);
            wall2.SetActive(true);
            if(wall1.transform.localScale.y >= 1.0f && wall2.transform.localScale.y >= 1.0f && wall3.transform.localScale.y <= 0.0f){
                wall3.SetActive(false);
                changeWalls = !changeWalls;
            }
            else{
                wall1.transform.localScale += new Vector3(0f, 1.05f, 0f) * Time.deltaTime;
                wall2.transform.localScale += new Vector3(0f, 0.95f, 0f) * Time.deltaTime;
                wall3.transform.localScale -= new Vector3(0f, 1.05f, 0f) * Time.deltaTime;
            }
        } 
    }

    private void OnTriggerEnter (Collider other){
        if(other.gameObject.tag == "player"){
            changeWalls = !changeWalls;
        }   

    }
}
