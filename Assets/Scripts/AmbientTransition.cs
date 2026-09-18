using UnityEngine;
using UnityEngine.Audio;

public class AmbientTransition : MonoBehaviour
{
    public AudioMixerSnapshot indoorSnapshot;
    public AudioMixerSnapshot outdoorSnapshot;
    public float transitionTime = 1.5f;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stepping outside
            outdoorSnapshot.TransitionTo(transitionTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stepping inside
            indoorSnapshot.TransitionTo(transitionTime);
        }
    }
}