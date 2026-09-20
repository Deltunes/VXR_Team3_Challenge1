using UnityEngine;

public class ShipsMoveOnExit : MonoBehaviour
{
    [SerializeField] private SpaceshipTakeoff referencescript1;    //Gets a pointer to the script referenced; one for each ship taking off.
    [SerializeField] private SpaceshipTakeoff referencescript2;
    [SerializeField] private SpaceshipTakeoff referencescript3;


    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) { referencescript1.PlyrHasLeft = true; referencescript2.PlyrHasLeft = true; referencescript3.PlyrHasLeft = true; }
    }
}
