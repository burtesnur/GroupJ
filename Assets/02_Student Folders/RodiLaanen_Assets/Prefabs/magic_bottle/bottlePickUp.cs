using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bottlePickUp : MonoBehaviour
{   
    Pickup m_Pickup;
    PlayerCharacterController pcc;
    public float timerlol = 5f;
    bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, bottlePickUp>(m_Pickup, this, gameObject);


        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }
    void Update(){

        if(check){
            Debug.Log("lol het werkt");
            timerlol -= Time.deltaTime;
        }
        if(timerlol <= 0f){
            Debug.Log("voorbij");
        }

    }
    void OnPicked(PlayerCharacterController player)
    {   
        Health playerHealth = player.GetComponent<Health>();
        
        

        if (player)
        {
            check = true;
        
            Destroy(gameObject);
        }
    }
}
