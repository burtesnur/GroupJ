using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public AudioSource audiosource1;
    public AudioSource audiosource2;
    public AudioSource audiosource3;
    public GameObject boss; 
    public static int musicID;

    private bool Completed = false;

    // Start is called before the first frame update
    void Start()
    {
        if(Checkpoint.hasReached[1] || Checkpoint.hasReached[2]){
            musicID = 1;
        }else{
            musicID = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!audiosource1.isPlaying && musicID == 1){
            audiosource1.Play();
        }else if(!audiosource2.isPlaying && musicID == 2){
            if(audiosource1.isPlaying){
                audiosource1.Stop();
            }
            audiosource2.Play();
        }
        if(boss == null){
            audiosource2.Stop();
            if(!audiosource3.isPlaying && !Completed){
                Completed = true;
                audiosource3.Play();
            }
        }
    }
}
