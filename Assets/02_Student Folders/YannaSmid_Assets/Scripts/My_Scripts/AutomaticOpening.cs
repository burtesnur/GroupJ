using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticOpening : MonoBehaviour
{
    int number = 3;
    public float speed = 2f;

    bool isOpen = false;
    public bool isClosed = true;
    bool opening = false;
    bool closing = false;
    public bool BossFight = false;

    float timer;
    public float timerlength = 1f;

    public Transform door1;
    public Transform door2;

    public Collider triggerZone;

    Vector3 door1DefaultPos = new Vector3(0, 0, 0.3f);
    Vector3 door2DefaultPos = new Vector3(1.9f, 0, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening && timer > 0f)
        {
            door1.Translate(Vector3.forward * Time.deltaTime * speed);
            door2.Translate(-Vector3.forward * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        } else if (opening && timer <= 0f)
        {
            opening = false;
            timer = timerlength;
            isOpen = true;
            //closing = true;
        }
        if (isOpen && timer >0f)
        {
            timer -= Time.deltaTime;
        } else if (isOpen && timer <= 0f)
        {
            isOpen = false;
            timer = timerlength;
            closing = true;
        }
        if (closing && timer > 0f)
        {
            door1.Translate(-Vector3.forward * Time.deltaTime * speed);
            door2.Translate(Vector3.forward * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        } else if (closing && timer <= 0f)
        {
            closing = false;
            timer = timerlength;
            isClosed= true;
            door1.localPosition = door1DefaultPos;
            door2.localPosition = door2DefaultPos;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (isClosed && (!BossFight))
        {
            isClosed = false;
            timer = timerlength;
            opening = true;
        }
    }
}
