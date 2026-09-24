using UnityEngine;
using System.Collections;

public class ShipAnimOnTrigger : MonoBehaviour
{
    private AudioSource ssource;
    public AudioClip sound;
    public GameObject rocket;
    [SerializeField] Animator anim;

    public bool bigship = false;

    private void Start()
    {
        ssource = rocket.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (bigship == true)
        {
            StartCoroutine(bigshiparrive(5.0f));
        }
    }

    IEnumerator bigshiparrive(float timer)
    {
        yield return new WaitForSeconds(timer);
        anim.Play("BigShipArrive", 0); 
        if (sound != null && ssource != null)
        {
            ssource.PlayOneShot(sound);
        }
    }
}
