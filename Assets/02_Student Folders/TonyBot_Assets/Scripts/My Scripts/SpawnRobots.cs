using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRobots : MonoBehaviour
{
	
	public DetectionModule detect;
	public float speed;
	int i = 0;
	public Transform Walls;
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
			CloseWalls();
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
	
	void CloseWalls(){
		if (Walls.position.y < 10)
			Walls.position = Walls.position + new Vector3(0, Time.deltaTime*speed, 0) ;
		if (Walls.localScale.x > 1)
			Walls.localScale = Walls.localScale + new Vector3(-Time.deltaTime*speed, 0 , -Time.deltaTime*speed);
	}
}