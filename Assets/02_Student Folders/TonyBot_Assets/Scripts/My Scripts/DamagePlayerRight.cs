using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerRight : MonoBehaviour
{
	Collider triggerZone;
	public SwipeRightArm arm_trigger;
	public Health m_health;
	public GameObject source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter (Collider other){
		CharacterController player = other.GetComponent<CharacterController>();
		if (player != null && arm_trigger.Trigger) DamagethePlayer();
	}
	
	void DamagethePlayer(){
		m_health.TakeDamage(20, source);
		arm_trigger.Trigger = false;
	}
}
