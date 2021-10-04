using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace Unity.FPS.Gameplay
//{

    public class Freeze : MonoBehaviour
    {
        public float FrozenTimer = 5f;
        private float defaultFrozenTimer;

        public bool isFrozen = false;

        public Collider TriggerZone;

        private PlayerCharacterController Frozen;

        // Start is called before the first frame update
        void Start()
        {
            defaultFrozenTimer = FrozenTimer;
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
            Frozen = other.GetComponent<PlayerCharacterController>();
            
            //if (Frozen == null) return;

            if (!isFrozen && FrozenTimer > 0f)
            {
                
                isFrozen = true;
                Frozen.enabled = false;
            }
        }

        void deFreeze ()
        {
            if (isFrozen && FrozenTimer <= 0f)
            {
                Debug.Log("Freeze B*tch");
                isFrozen = false;
                Frozen.enabled = true;
                FrozenTimer = defaultFrozenTimer;
            }
        }

    }
//}
