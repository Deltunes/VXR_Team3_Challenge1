using UnityEngine;

public class play_animation : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim.Play("LightPlaneFlash");
        anim.Play("Rocket_004|BigShipArrive");
    }
}
