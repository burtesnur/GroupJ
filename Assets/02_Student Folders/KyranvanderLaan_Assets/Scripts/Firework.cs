using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public ParticleSystem Fw;
    // Start is called before the first frame update
    void Start()
    {
        Fw.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
