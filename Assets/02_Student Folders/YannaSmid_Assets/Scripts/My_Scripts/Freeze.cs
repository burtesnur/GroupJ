using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace Unity.FPS.Gameplay
//{

    public class Freeze : MonoBehaviour
    {
        private float FrozenTimer;
        public float TimerLength = 3f;

        public bool isFrozen = false;
       
        //public Collider TriggerZone;

        public AudioSource freezingSFX;
        public Transform IceObstacles;
        public PlayerCharacterController s_Player;

        // Start is called before the first frame update
        void Start()
        {
            s_Player = GetComponent<PlayerCharacterController>();
            //TriggerZone = GetComponent<Collider>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isFrozen)
            {
                FrozenTimer -= Time.deltaTime;
                deFreeze();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            //Frozen = other.GetComponent<PlayerCharacterController>();
            
            //if (Frozen == null) return;

            if (!isFrozen && other.transform.parent == IceObstacles)
            {
                freezingSFX.Play();
                isFrozen = true;
                FrozenTimer = TimerLength;
                s_Player.enabled = false;
            }
        }

        void deFreeze ()
        {
            if (isFrozen && FrozenTimer <= 0f)
            {
                Debug.Log("Freeze B*tch");
                isFrozen = false;
                s_Player.enabled = true;
            }
        }

    }
//}
