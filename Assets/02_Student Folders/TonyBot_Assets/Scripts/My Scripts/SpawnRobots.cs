using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRobots : MonoBehaviour
{
	
	public DetectionModule detect;
	int i = 0;
	public GameObject RobotPrefab;
	public Vector3 SpawnPoint;
	List<GameObject> enemies = new List<GameObject>();
	bool PlayerDetected = false;
	bool OutRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		OutRange = !detect.isTargetInAttackRange;
		if (detect.hadKnownTarget){
			PlayerDetected = true;
		}
        if (PlayerDetected) {
			if (OutRange){
				SpawnRobot();
			}
		}
    }
	
	void SpawnRobot(){
		
		if (i < 1800) {
			i++;
			return;
			
		}
		i = 0;
		if (enemies.Count < 4)
			enemies.Add(Instantiate(RobotPrefab, SpawnPoint, Quaternion.identity));
	}
}
