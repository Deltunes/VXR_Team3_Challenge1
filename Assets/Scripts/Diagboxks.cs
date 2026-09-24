

using UnityEngine;
using System.Collections;

public class Diagboxks : MonoBehaviour
{
    [SerializeField] private GameObject Dbackground; [SerializeField] private GameObject dtxt;

    public bool shouldexplode;

    private void Update()
    {
        if (shouldexplode)
        {
            StartCoroutine(whenexploding(4.0f));
        }
    }
            

    IEnumerator whenexploding(float fuse)
    {
        yield return new WaitForSeconds(fuse);
        Dbackground.GetComponent<Animator>().SetBool("DiaOpened", false);
        Destroy(dtxt);
    }
}
