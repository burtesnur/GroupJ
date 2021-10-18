using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformX : MonoBehaviour
{
    public int direction = 1;
    public float speed = 1f;

    public bool movingforward = true;
    public bool movingbackward = false;

    public float timerlength = 5f;
    private float timer;

    public Transform plateau;


    public Vector3 startingPos = new Vector3(-49.7f, -1f, 3.75f);
    public Vector3 endPos = new Vector3(-42f, -1f, 3.75f);
    // Start is called before the first frame update
    void Start()
    {
        timer = timerlength;
    }

    // Update is called once per frame
    void Update()
    {
        if (plateau.position.x >= endPos.x)
        {
            movingforward = false;
        }

        if (movingforward)
        {
            plateau.position += new Vector3(1f * Time.deltaTime * speed * direction,0,0);
        }
        //if the plateau is waiting to go back
        else if (!movingforward && timer > 0f && !movingbackward)
        {
            timer -= Time.deltaTime;
        }
        //time to go back
        else if (!movingforward && timer <0f)
        {
            movingbackward = true;
            timer = timerlength;
        }
        //same goes for moving backwards
        if (plateau.position.x <= startingPos.x)
        {
            movingbackward = false;
        }
        if (movingbackward)
        {
            plateau.position += new Vector3(1f * Time.deltaTime * speed * -direction,0,0);
        }
        else if (!movingbackward && timer > 0f && !movingforward)
        {
            timer -= Time.deltaTime;
        }
        else if (!movingbackward && timer < 0f)
        {
            movingforward = true;
            timer = timerlength;
        }

    }

}
