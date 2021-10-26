using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwipeLeftArm : MonoBehaviour
{
	public float speed;
	public Collider triggerZone;
	public GameObject source;
	public Transform Pivot;
	public Transform Arm;
	public Health m_health;
	public bool Trigger = false;
	bool Swipe = false;
	bool Slam = false;
	bool SwipeB = false;
	bool SlamB = false;
	bool Busy = false;
    // Start is called before the first frame update
	
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Swipe) SwipeArm();
		else if (SwipeB) SwipeArmBack();
		if (Slam) SlamArm();
		else if (SlamB) SlamArmBack();
		if (!Busy){
			int bar = Random.Range(0,1000);
			if (bar < 100) {
				Busy = true;
				if (bar > 50){
					Swipe = true;
					Trigger = true;
				} else {
					Trigger = false;
					Slam = true;
				}
			}
		}
		
    }
	
	private static float WrapAngle(float angle)
        {
            angle%=360;
            if(angle >180)
                return angle - 360;
 
            return angle;
        }
 
	
	void SwipeArm() {
		Trigger = true;
		if (WrapAngle(Arm.localRotation.eulerAngles.z) > -60){
			Arm.transform.Rotate( 0, 0, -Time.deltaTime*speed);
		} else if (Pivot.localRotation.eulerAngles.y < 120){
			Pivot.transform.Rotate( 0, Time.deltaTime*speed*5, 0);
		} else {
			Swipe = false;
			SwipeB = true;
		}
	}
	
	void SwipeArmBack() {
		
		if (Pivot.localRotation.eulerAngles.y > 1){
			Pivot.transform.Rotate(0, -Time.deltaTime*speed, 0);
			if (WrapAngle(Arm.localRotation.eulerAngles.z) < 0){
				Arm.transform.Rotate( 0 , 0 , Time.deltaTime*speed);
			}
		} else {
			Pivot.transform.localRotation = Quaternion.Euler(0 , 0 , 0);
			Arm.transform.localRotation = Quaternion.Euler(0 , 0 , 0);
			Trigger = false;
			Busy = false;
			SwipeB = false;
		}
	}
	
	void SlamArm() {
		if (Arm.localRotation.eulerAngles.y < 90) {
			Arm.transform.Rotate( 0, Time.deltaTime*speed*4, 0);	
		}
		if (WrapAngle(Arm.localRotation.eulerAngles.z) > -80) {
			Arm.transform.Rotate( 0, 0, -Time.deltaTime*speed);
			if (WrapAngle(Arm.localRotation.eulerAngles.z) < -80){
				Trigger = true;
			}
		} else if (Pivot.localRotation.eulerAngles.x < 30) {
			Arm.transform.localRotation = Quaternion.Euler(-90 , 90 , -80);
			Pivot.transform.Rotate( Time.deltaTime*speed*5, 0, 0);
		} else {
			Slam = false;
			SlamB = true;
		}
	}
	
	void SlamArmBack(){
		Pivot.transform.localRotation = Quaternion.Euler(0 , 0 , 0);
		Arm.transform.localRotation = Quaternion.Euler(0 , 0 , 0);
		Busy = false;
		Trigger = false;
		SlamB = false;
	}
	
}
