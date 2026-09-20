using System.Collections;
using UnityEngine;

public class SpaceshipTakeoff : MonoBehaviour
{
    public bool PlyrHasLeft = false;     // Meant to be altered by other objects/scripts
    [Header("Delay")]
    public float startDelay = 0f;          // Wait time before this specific ship starts moving

    [Header("Distance & Speed")]
    public float hoverHeight = 3f;
    public float riseSpeed = 2f;
    public float forwardSpeed = 30f;       
    public float takeoffDuration = 100f;    

    [Header("Steering & Banking")]
    public float turnAngle = 45f;          
    public float bankTilt = 35f;           

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (PlyrHasLeft == true)
        {
            StartTakeoff();
        }
    }

    public void StartTakeoff()
    {
        StartCoroutine(TakeoffRoutine());
    }

    private IEnumerator TakeoffRoutine()
    {

        
        // Wait for the specified delay before doing anything
        if (startDelay > 0f)
        {
            yield return new WaitForSeconds(startDelay);
        }

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 targetHoverPos = startPos + Vector3.up * hoverHeight;

        // Phase 1: Rise up smoothly into hover
        while (elapsed < 1f)
        {
            transform.position = Vector3.Lerp(startPos, targetHoverPos, elapsed);
            elapsed += Time.deltaTime * riseSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(0.4f); // Brief hover pause

        // Phase 2: Fly far away while turning and banking
        elapsed = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(5f, turnAngle, -bankTilt);
        
        Vector3 initialFlyDir = (transform.forward + Vector3.up * 0.4f).normalized;

        while (elapsed < takeoffDuration)
        {
            float progress = elapsed / takeoffDuration;
            Vector3 currentFlyDir = Vector3.Slerp(initialFlyDir, (targetRotation * Vector3.forward + Vector3.up * 0.1f).normalized, progress);

            transform.position += currentFlyDir * forwardSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, progress);

            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}