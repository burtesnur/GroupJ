using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
	public float speed = 1;
	Collider triggerZone;
	public Transform negZ;
	public Transform posZ;
	bool Trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger) Collapse();
    }
	
	void OnTriggerEnter (Collider other){
		CharacterController player = other.GetComponent<CharacterController>();
		if (player != null) Trigger = true;
	}
	
	void Collapse(){
		
		
		if (negZ.eulerAngles.x <= 50){
			negZ.transform.Rotate( Time.deltaTime*speed , 0 , 0);
		}
		if (posZ.transform.localRotation.eulerAngles.x >= 310 || posZ.transform.localRotation.eulerAngles.x == 0){
			posZ.transform.Rotate( -Time.deltaTime*speed , 0 , 0);
		}
	}
}
