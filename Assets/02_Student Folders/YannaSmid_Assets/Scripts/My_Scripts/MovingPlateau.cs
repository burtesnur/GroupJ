using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateau : MonoBehaviour
{
    public int direction = 1;
    public float speed = 1f;

    public bool movingforward = true;
    public bool movingbackward = false;

    public float timerlength = 5f;
    private float timer;

    public Transform plateau;

    public Vector3 startingPos = new Vector3(-25f, -1f, -4f);
    public Vector3 endPos = new Vector3(-25f, -1f, 11.5f);
    // Start is called before the first frame update
    void Start()
    {
        timer = timerlength;
    }

    // Update is called once per frame
    void Update()
    {
        if (plateau.position.z >= endPos.z)
        {
            movingforward = false;
        }

        if (movingforward)
        {
            plateau.Translate(Vector3.forward * Time.deltaTime * speed * direction);
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
        if (plateau.position.z <= startingPos.z)
        {
            movingbackward = false;
        }
        if (movingbackward)
        {
            plateau.Translate(Vector3.forward * Time.deltaTime * speed * -direction);
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
