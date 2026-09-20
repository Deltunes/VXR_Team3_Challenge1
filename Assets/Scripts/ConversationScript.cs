using System.Threading;
using UnityEngine;

public class ConversationScript : MonoBehaviour
{
    private bool PlayerPresent = false;
    private bool PlayerUnseen = true;
    private bool interrupted = false;

    private int dialoguecount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {  PlayerPresent = true; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) { PlayerPresent = false; }
    }

    private void Update()
    {
        if (PlayerPresent == false && interrupted == false && PlayerUnseen == false)
        {
            InterruptDialogueTree();
        }
        if (PlayerPresent == true && PlayerUnseen == true)
        {
            StartDialogueTree();
            PlayerUnseen = false;
        }
    }

    private void StartDialogueTree ()
    {
        //play audio to get player's attention, preferably sourced from the alien


    }

    private void InterruptDialogueTree()
    {

    }

    private void ResumeDialogueTree()
    {

    }
}
