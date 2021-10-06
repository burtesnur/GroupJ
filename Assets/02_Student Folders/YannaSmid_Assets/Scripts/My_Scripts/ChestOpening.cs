using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;

    public AudioClip OpeningSound;
    public AudioSource ChestAudioSource;
    public float volume;

    bool chestOpen = false;

    public GameObject TreasureItem;
    // Start is called before the first frame update
    void Start()
    {
        ChestAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnMouseDown()
    {
        if (chestOpen == false)
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0.1f);
            StartCoroutine(startOpening());
        }
    }

    IEnumerator startOpening()
    {
        //play the collect graphics
        chestOpen = true;
        ChestAudioSource.PlayOneShot(OpeningSound, volume);
        collectParticle.Play();
        yield return new WaitForSeconds(8.4f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        GetItem();
    }

    void GetItem()
    {
        if (chestOpen == true)
        {
            TreasureItem.SetActive(true);
        }
    }
}
