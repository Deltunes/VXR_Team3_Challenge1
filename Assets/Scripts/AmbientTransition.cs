using UnityEngine;
using System.Collections;

public class AmbientTransition : MonoBehaviour
{
    public AudioSource indoorsource;
    public AudioSource outdoorsource;
    public Transform plyr;
    public Transform transition;
    public float transitionTime = 3.0f;
    private Coroutine activefade;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (activefade != null) { StopCoroutine(activefade); }
            if (plyr.position[2] >= transition.position[2])
            {
                activefade = StartCoroutine(audiofade(0.02f, 0.9f, transitionTime));
            }
            else { activefade = StartCoroutine(audiofade(0.2f, 0.0f, transitionTime)); }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (activefade != null) { StopCoroutine(activefade); }
            activefade = StartCoroutine(audiofade(0.005f, 0.0f, transitionTime/2));
        }
    }
    private IEnumerator audiofade(float targetvolinside, float targetvoloutside, float duration)
    {
        float cTime = 0;
        float startVolumeins = indoorsource.volume;
        float startVolumeOut = outdoorsource.volume;

        targetvolinside = Mathf.Clamp01(targetvolinside);
        targetvoloutside = Mathf.Clamp01(targetvoloutside);

        while (cTime < duration)
        {
            cTime += Time.deltaTime;
            indoorsource.volume = Mathf.Lerp(startVolumeins, targetvolinside, cTime / duration);
            outdoorsource.volume = Mathf.Lerp(startVolumeOut, targetvoloutside, cTime / duration);
            yield return null;
        }
        indoorsource.volume = targetvolinside;
        outdoorsource.volume = targetvoloutside;

        activefade = null;
    }
}