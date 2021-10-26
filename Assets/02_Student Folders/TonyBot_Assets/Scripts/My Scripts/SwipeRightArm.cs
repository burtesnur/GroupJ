using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwipeRightArm : MonoBehaviour
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
					Slam = true;
					Trigger = false;
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
		if (Arm.localRotation.eulerAngles.z < 60){
			Arm.transform.Rotate( 0, 0, Time.deltaTime*speed);
		} else if (WrapAngle(Pivot.localRotation.eulerAngles.y) > -120){
			Pivot.transform.Rotate( 0, -Time.deltaTime*speed*5, 0);
		} else {
			Swipe = false;
			SwipeB = true;
		}
	}
	
	void SwipeArmBack() {
		
		if (WrapAngle(Pivot.localRotation.eulerAngles.y) < 0){
			Pivot.transform.Rotate(0, Time.deltaTime*speed, 0);
			if (Arm.localRotation.eulerAngles.z > 1){
				Arm.transform.Rotate( 0 , 0 , -Time.deltaTime*speed);
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
		if (WrapAngle(Arm.localRotation.eulerAngles.y) > -89) {
			Arm.transform.Rotate( 0, -Time.deltaTime*speed*4, 0);
		}
		if (Arm.localRotation.eulerAngles.z < 80) {
			Arm.transform.Rotate( 0, 0, Time.deltaTime*speed);
			if (Arm.localRotation.eulerAngles.z > 80){
				Trigger = true;
			}
		} else if (Pivot.localRotation.eulerAngles.x < 30) {
			Arm.transform.localRotation = Quaternion.Euler(-90 , -90 , 70);
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
