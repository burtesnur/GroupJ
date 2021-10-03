using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{

    public class Freeze : MonoBehaviour
    {
        public float frozen_timer = 10f;

        bool isFrozen = false;

        public Collider TriggerZone;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter(Collider other)
        {
            //PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
            
            //if (player == null) return;

            if (!isFrozen)
            {
                Debug.Log("Freeze B*tch");
                isFrozen = true;

            }

        }
    }
}
