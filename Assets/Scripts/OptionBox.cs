using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class OptionBox : MonoBehaviour
{
    [SerializeField] private Diagboxks ks;
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
        if (responsenum == -1 || responsenum == 3) { ks.shouldexplode = true ; Destroy(gameObject) ; return ""; }
        responsenum += 1;
        switch (responsenum)
        {
            case 1:
                if (IsRudeAnswer) { return "You don't get it because you're a BUM!!"; }
                else { return "...Uh, what are you holding?"; }
            case 2:
                if (IsRudeAnswer) { return "Never have. I'd like to keep my lungs, thank you."; }
                else { return "Dude, i meant like, how are they working out here?"; }
            case 3:
                if (IsRudeAnswer) { return "...No thanks, dude."; }
                else { return "Y'know what, sure man. Why not."; }
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
