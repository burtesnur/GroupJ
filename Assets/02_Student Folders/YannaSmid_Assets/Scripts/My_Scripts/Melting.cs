using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.FPS.Game;

    public class Melting : MonoBehaviour
    {
        int number = 3;
        public float melting_speed = 1f;
        public bool melting = false;
        float melted_signal = 1f;

        public GameObject melting_object;
        Vector3 scaleChange;

        public Collider triggerZone;


        // Start is called before the first frame update
        void Start()
        {
            scaleChange = new Vector3(-0.005f, -0.005f, -0.005f) * melting_speed;
        }

        // Update is called once per frame
        void Update()
        {
            if (melting && melted_signal > 0f)
            {
                melting_object.transform.localScale += scaleChange;
                melted_signal = melting_object.transform.localScale.x;

            }
            else if (melting && melted_signal <= 0f)
            {
                Destroy(melting_object);
                melting = false;
            }
        }

    }
