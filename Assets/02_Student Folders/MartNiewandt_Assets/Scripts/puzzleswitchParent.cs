using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleswitchParent : MonoBehaviour
{
    public GameObject presser;
    public puzzleswitchChild switch1;
    public puzzleswitchChild switch2;
    public puzzleswitchChild switch3;
    private bool shouldMove = false;
    bool ishit = false;
    private float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(switch1.childhit && switch2.childhit && switch3.childhit){
            shouldMove = true;
			print("allhit");
        }
        if(shouldMove && timer > 0f){
            Destroy(presser);
            timer -= Time.deltaTime;
			print("shouldmove");
        }else{
            shouldMove = false;
        }
    }

}
