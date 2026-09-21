
using UnityEngine;

public class Diagboxks : MonoBehaviour
{
    private bool _shouldexplode = false;

    public bool shouldexplode
    {
        get => _shouldexplode;
        set { if (_shouldexplode = value) return;
            _shouldexplode = value;
            whenexploding();
        }
    }
    private void whenexploding()
    {
        Destroy(gameObject, 8.0f);
    }
}
