using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossWall : MonoBehaviour
{
    public Transform wall1;
    public PlayerCharacterController Player;
    public float timer = 1f;

    private bool shouldMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.keyHold)
        {
            shouldMove = true;
        }
        if(shouldMove && timer > 0f)
        {
            wall1.Translate(0, -Time.deltaTime * 5f, 0);
            timer -= Time.deltaTime;
        }else{
            shouldMove = false;
        }
    }
}
