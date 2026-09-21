
using UnityEngine;

public class ConversationScript : MonoBehaviour
{
    //test 
    private bool PlayerUnseen = true;
    private bool interrupted = false;
    public bool nextbox = false;

    [SerializeField] private TextBoxScript tbs;
    public int dialoguecount = 0;
    public int dialoguealtcount = 0;
    private int interruptioncount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (dialoguecount == -1) { return; }
        else if (PlayerUnseen)
        {
            PlayerUnseen = false;
            StartDialogueTree();
        }
        else if (interrupted)
        {
            interrupted = false;
            ResumeDialogueTree();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interrupted = true;
        InterruptDialogueTree();
    }



    private void StartDialogueTree()
    {
        //play audio to get player's attention, preferably sourced from the alien
        tbs.nexttext = Getnexttext();
        tbs.IsSpeaking = true;
        tbs.IsWaiting = false;
        nextbox = false;
    }

    private void InterruptDialogueTree()
    {
        tbs.IsSpeaking = false;
        tbs.wasInterrupted = true;
        tbs.IsWaiting = false;
        dialoguecount -= 1;
        tbs.nexttext = interruptionblurb();
    }

    public void ResumeDialogueTree()
    {
        tbs.nexttext = Getnexttext();
        tbs.IsSpeaking = true;
        tbs.IsWaiting = false;
        nextbox = false;
    }

    private string Getnexttext()
    {
        if (dialoguecount == 0)
        {
            dialoguecount += 1;
            return "Oh, hey. You're finally on break. Don\'t know how you take shifts that long..."; //Very first message
        }

        if (dialoguealtcount == 1)
        {
            dialoguecount = -1;
            return "Lame... At least watch the ships with me. Oh, hey! There's a big one coming in right now, up there!"; //First message if you decline smoking
        }
        switch (dialoguecount)
        {
            case 1:
                dialoguecount += 1;
                return "They're uh... they're cigarrettes. \n...Have you not seen a cigarrette before...???";
            case 2:
                dialoguecount += 1;
                return "Oh, that's what you meant... dunno how you missed it, but they got stuff from MAR-16070 that \"burns\" without needing air. Kinda cool, actually. Want one?";
            case 3:
                dialoguecount = -1;
                return "Hell yeah, dude. Why don't you watch the ships with me for a bit while you're at it? I think a feel a big one coming in now... look up there!";
        }


        return "";
    }
    private string interruptionblurb()
    {
        interruptioncount += 1;
        if (interruptioncount >= 4) { interruptioncount = 1; }
        switch (interruptioncount)
        {
            case 1:
                return "Wow, man. come on, don't walk away from me like that.";
            case 2:
                return "Don't mess with me man.";
            case 3:
                return "I think i feel steam coming out of my ears.";
        }
        return "See ya, i guess..?";
    }
}
