using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class basketController : MonoBehaviour
{
    [Header("Switches")]
    [Tooltip("Doors that will open/close when this is hit")]
    public List<doorController> triggerDoors = new List<doorController>();

    [Header("Sounds")]
    [Tooltip("Sound played when hit")]
    public AudioClip activateSFX;

    AudioSource m_audioSource;

    public UnityAction onHit;
    void Start()
    {
        onHit += OnHit;
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.playOnAwake = false;
        m_audioSource.clip = activateSFX;
    }

    //When hit by egg
    private void OnTriggerEnter(Collider other)
    {
        m_audioSource.Play();
        onHit.Invoke();
    }

    private void OnHit()
    {
        foreach(var door in triggerDoors)
        {
            door.activate();
        }
    }
}
