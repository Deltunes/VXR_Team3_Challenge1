using TMPro;
using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DText;
    [SerializeField] private GameObject Dbackground;
    [SerializeField] private OptionBox Button;

    [Header("Do not Alter")]

    public bool IsSpeaking = false; // Is The box still doing its thing?
    public bool IsWaiting = false; // Is he waiting on Player to do something?
    public bool IsAnnoyed = false;
    public bool wasInterrupted = false; // Did player walk away?
    public bool doneSpeaking = false; // Is dialogue completed?
    public string nexttext = "";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DText.text = "";
        Dbackground.GetComponent<Animator>().SetBool("DiaOpened", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpeaking && !IsWaiting)
        {
            if (Dbackground.GetComponent<Animator>().GetBool("DiaOpened") == false) { Dbackground.GetComponent<Animator>().SetBool("DiaOpened", true); }
            DText.text = nexttext;
            IsWaiting = true;
            Button.plyrthinking = true;
        }
        else if (wasInterrupted == true && !IsAnnoyed)
        {
            //tell button to poof

            DText.text = nexttext;
            IsAnnoyed = true;
        }
        else if (wasInterrupted && IsWaiting && IsSpeaking)
        {
            DText.text = nexttext;
            wasInterrupted = false;
            IsAnnoyed = false;
            Button.plyrthinking = true;
        }
    }

}