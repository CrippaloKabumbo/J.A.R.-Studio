using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : InteractionHandler
{

    private void Start()
    {
        dialogueManager = GetComponentInChildren<DialogueManager>();
    }

    // Show the dialogue panel when player enters NPC interaction zone
    protected override void OnPlayerEnter()
    {
        if (dialogueManager != null && dialogueManager.firstDialoguePanel != null)
        {
            dialogueManager.firstDialoguePanel.SetActive(true);
        }
    }

    // Hide the dialogue panel when player exits NPC interaction zone
    protected override void OnPlayerExit()
    {
        if (dialogueManager != null && dialogueManager.firstDialoguePanel != null)
        {
            dialogueManager.firstDialoguePanel.SetActive(false);
        }
    }

    public override void Interact()
    {
        // Start dialogue if the first panel is active
        if (dialogueManager != null && dialogueManager.firstDialoguePanel.activeSelf)
        {
            dialogueManager.StartDialogue();
            
        }

    }
    public override void ExitInteraction()
    {  
        
            dialogueManager.EndDialogue();

    }
}
