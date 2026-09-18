using UnityEngine;

public class SmokeOnCig : MonoBehaviour
{
    [SerializeField] Transform smokePos;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = smokePos.position;
    }
}
