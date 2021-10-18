using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float flow = 0.1f;
    Renderer lava;
    // Start is called before the first frame update
    void Start()
    {
        lava = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Time.time * flow;
        lava.material.SetTextureOffset("_MainTex", new Vector2(0, speed));
    }
}
