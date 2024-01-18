using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class FootstepSound : MonoBehaviour
{
    [SerializeField]
    AudioClip footstepClip;

    [SerializeField]
    AudioMixerSnapshot snapshot;

    [SerializeField]
    AudioMixerSnapshot defaultSnapshot;

    [SerializeField]
    [Min(0)]
    float transitionInTime;

    [SerializeField]
    [Min(0)]
    float transitionOutTime;

    [SerializeField]
    public List<GameObject> AnimalsOnTile;

    public void Start()
    {
        AnimalsOnTile = new List<GameObject>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal" && !AnimalsOnTile.Contains(other.gameObject))
        {
            AnimalsOnTile.Add(other.gameObject);
            AudioSource source = other.gameObject.GetComponent<AudioSource>();

            source.clip = footstepClip;
            source.Play();
            snapshot.TransitionTo(transitionInTime);
        }
    }

    public void OnTriggerExit(Collider other)
    {        
        if (other.gameObject.tag == "Animal" && AnimalsOnTile.Contains(other.gameObject))
        {
            AnimalsOnTile.Remove(other.gameObject);

            if (other.gameObject.GetComponent<AudioSource>().clip == footstepClip)
            {
                AudioSource source = other.gameObject.GetComponent<AudioSource>();

                source.clip = null;
                source.Stop();
                snapshot.TransitionTo(transitionOutTime);
            }
        }
    }
    /*
    private void Update()
    {
        foreach (GameObject animal in AnimalsOnTile) 
        {
            if (animal.transform.position == animal.GetComponent<NavMeshAgent>().destination)
            {
                animal.GetComponent<AudioSource>().Stop();
            } else
            {
                if (!animal.GetComponent<AudioSource>().isPlaying)
                {
                    animal.GetComponent<AudioSource>().Play();
                }
            }
        }
    }*/
}
