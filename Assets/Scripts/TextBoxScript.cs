using TMPro;
using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro DText;
    [SerializeField] private GameObject Dbackground;

    [Header("Do not Alter")]

    public bool IsSpeaking = false; // Is The box still doing its thing?
    public bool IsWaiting = false; // Is he waiting on Player to do something?
    public bool wasInterrupted = false; // Did player walk away?
    public bool doneSpeaking = false; // Is dialogue completed?
    public string nexttext = "";

    private string currenttext = "";
    private bool boxopen = false;
    private bool txtbuilding = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpeaking && !IsWaiting)
        {
            DText.text = nexttext;
            IsWaiting = true;
        }
        if (wasInterrupted == true && !IsWaiting)
        {
            DText.text = "";
            DText.text = nexttext;
            IsWaiting = true;
        }
        else if (wasInterrupted && IsWaiting && IsSpeaking)
        {
            DText.text = nexttext;
            wasInterrupted = false;
        }
    }

}