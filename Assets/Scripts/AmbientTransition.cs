using UnityEngine;
using UnityEngine.Audio;

public class AmbientTransition : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float transitionTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stepping inside
            snapshot.TransitionTo(transitionTime);
        }
    }
}