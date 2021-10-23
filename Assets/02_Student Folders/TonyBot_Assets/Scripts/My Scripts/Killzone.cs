using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
	Collider triggerZone;
	public Health m_health;
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
		if (player != null) m_health.Kill();
	}
}
