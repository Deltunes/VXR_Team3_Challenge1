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
        if (interrupted == true && PlayerPresent == true)
        {
            ResumeDialogueTree();
        }
    }

    private void StartDialogueTree ()
    {
        //play audio to get player's attention, preferably sourced from the alien

        //Send a ping to another script to get it to start the dialogue
    }

    private void InterruptDialogueTree()
    {
        //Send a ping to another script to get it to stop the current dialogue (and save where it was) 
        //Send a ping to another script to tell it to play a short blurb at the player, then remove the box until otherwise told
    }

    private void ResumeDialogueTree()
    {
        //Send a ping to the other script that tells it to resume the dialouge from where it left off.
    }
}
