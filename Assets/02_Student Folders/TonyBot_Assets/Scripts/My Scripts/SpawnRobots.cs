using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRobots : MonoBehaviour
{
	
	public DetectionModule detect;
	bool OutRange = true;
	int i = 0;
	public GameObject RobotPrefab;
	public Vector3 SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (detect.isTargetInAttackRange != null){
			OutRange = !detect.isTargetInAttackRange;
		}
        if (detect.knownDetectedTarget != null) {
			if (OutRange){
				SpawnRobot();
			}
		}
    }
	
	void SpawnRobot(){
		if (i < 300) {
			i++;
			return;
		}
		i = 0;
		Instantiate(RobotPrefab, SpawnPoint, Quaternion.identity);
	}
}
