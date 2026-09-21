using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.Composites;

public class OptionBox : MonoBehaviour
{
    [SerializeField] private bool IsRudeAnswer; //Chosen in the editor instead so this can be used for both
    [SerializeField] private TextMeshPro bttxt;
    [SerializeField] private ConversationScript conscrip;
    [SerializeField] private OptionBox otherbox;
    [SerializeField] private TextBoxScript textbox;

    public bool plyrthinking = false;
    public int responsenum = 0;

    private void Start()
    {
        bttxt.text = "";
    }

    private void Update()
    {
        if (responsenum == -1)
        {return;}
        if (plyrthinking)
        {
            plyrthinking = false;
            bttxt.text = GetNextTXT();
        }
    }

    private string GetNextTXT()
    {
        responsenum += 1;
        switch (responsenum)
        {
            case 1:
                if (IsRudeAnswer) { return "Evil option 1"; }
                else { return "Nice option 1"; }
            case 2:
                if (IsRudeAnswer) { return "Evil Option 2"; }
                else { return "Nice option 2"; }
            case 3:
                if (IsRudeAnswer) { return "Evil Option 3"; }
                else { return "Nice option 3"; }
        }
        return "";
    }

    public void OptionSelect()
    {
        if (IsRudeAnswer) { responsenum = -1; otherbox.responsenum = -1;  conscrip.dialoguealtcount = 1; textbox.IsWaiting = false; }
        else { textbox.IsWaiting = false;}
    }
}
