using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicplayer : MonoBehaviour
{
    public int ID;
    public AudioClip Stepsound;
    public PlayerCharacterController playerFootsteps;

    // Start is called before the first frame update
    void Start()
    {
        if(Checkpoint.hasReached[1] || Checkpoint.hasReached[2]){
            playerFootsteps.footstepSFX = Stepsound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            playerFootsteps.footstepSFX = Stepsound;
            MusicStarter.musicID = ID;
        }
    }
}
