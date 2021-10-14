using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlippingPlayer : MonoBehaviour
{
    public PlayerCharacterController s_player;

    public float SlippingSpeed = 20f;
    private float defaultSpeed;
    public float resistance = 1f;
    private float defaultRes;

    public bool slippery = false;
    private bool floorswitch = true;
    public PlayerCharacterController s_Player;
    
    // Start is called before the first frame update
    void Start()
    {
        s_player = GetComponent<PlayerCharacterController>();
        defaultSpeed = s_player.maxSpeedOnGround;
        defaultRes = s_player.movementSharpnessOnGround;
    }

    // Update is called once per frame
    void Update()
    {
        if (slippery && floorswitch)
        {
            floorswitch = false;
            s_player.maxSpeedOnGround = SlippingSpeed;
            s_player.movementSharpnessOnGround = resistance;
        } 
        if (!slippery && !floorswitch)
        {
            floorswitch = true;
            s_player.maxSpeedOnGround = defaultSpeed;
            s_player.movementSharpnessOnGround = defaultRes;
        }
    }
}
