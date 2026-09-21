using TMPro;
using UnityEngine;

public class OptionBox : MonoBehaviour
{
    [SerializeField] private bool IsRudeAnswer; //Chosen in the editor instead so this can be used for both
    [SerializeField] private TextMeshProUGUI bttxt;
    [SerializeField] private ConversationScript conscrip;
    [SerializeField] private OptionBox otherbox;
    [SerializeField] private TextBoxScript textbox;

    public int responsenum = 0;

    private void Start()
    {
        bttxt.text = "";
        bttxt.text = GetNextTXT();
    }

    private void Update()
    {
        
    }

    private string GetNextTXT()
    {
        if (responsenum == -1) { return ""; }
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
        if (IsRudeAnswer) { responsenum = -1;  conscrip.dialoguealtcount = 1; conscrip.nextbox=true;
            bttxt.text = GetNextTXT();
        }
        else { conscrip.nextbox=true; bttxt.text = GetNextTXT(); }
    }

    public void OptionNotSelect()
    {
        if (!IsRudeAnswer)
        {
            responsenum = -1;
            bttxt.text = GetNextTXT();
        }
        else { bttxt.text = GetNextTXT(); }
    }
}
