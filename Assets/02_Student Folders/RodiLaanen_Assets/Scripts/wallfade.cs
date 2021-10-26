using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallfade : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    Collider triggerZone;

    bool changeWalls = false;

    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>();
        wall1.SetActive(false);
        wall2.SetActive(true);
        wall1.transform.localScale = new Vector3(1.0f, 0.10f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(changeWalls){
            wall1.SetActive(true);
            if(wall1.transform.localScale.y >= 1.0f && wall2.transform.localScale.y <= 0.0f){
                wall2.SetActive(false);
                changeWalls = !changeWalls;  
            }
            else{
                wall1.transform.localScale += new Vector3(0f, 0.95f, 0f) * Time.deltaTime;
                wall2.transform.localScale -= new Vector3(0f, 1.05f, 0f) * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter (Collider other){
        if(other.gameObject.tag == "player"){
            changeWalls = !changeWalls;
        }   

    }
}
