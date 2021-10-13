using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public float SlippingSpeed = 20f;
    private float defaultSpeed;
    public float resistance = 1f;
    private float defaultRes;
    public Collider TriggerZone;
    public PlayerCharacterController s_player;
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = s_player.maxSpeedOnGround;
        defaultRes = s_player.movementSharpnessOnGround;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        s_player = other.GetComponent<PlayerCharacterController>();

        if (s_player == null) return;
        
        s_player.maxSpeedOnGround = SlippingSpeed;
        s_player.movementSharpnessOnGround = resistance;

    }

    void OnTriggerExit (Collider other)
    {
        s_player.maxSpeedOnGround = defaultSpeed;
        s_player.movementSharpnessOnGround = defaultRes;
    }
}
