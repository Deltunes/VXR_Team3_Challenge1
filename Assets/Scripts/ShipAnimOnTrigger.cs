using UnityEngine;

public class ShipAnimOnTrigger : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Ship play");
            anim.Play("BigShipArrive", 0);
        }
    }
}
