using TMPro;
using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    [SerializeField] private GameObject DText;
    [SerializeField] private GameObject Dbackground;

    public bool IsSpeaking = false;
    public bool wasInterrupted = false;
    public bool doneSpeaking = false;
    public string nexttext = "";

    private bool boxopen = false;
    private bool txtbuilding = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
