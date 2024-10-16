using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.Space; // Set your interact key here
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the first dialogue panel when the player enters the trigger
            if (dialogueManager != null && dialogueManager.firstDialoguePanel != null)
            {
                dialogueManager.firstDialoguePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the first dialogue panel when the player exits the trigger
            if (dialogueManager != null && dialogueManager.firstDialoguePanel != null)
            {
                dialogueManager.firstDialoguePanel.SetActive(false);
            }
        }
    }

    void Update()
    {
        // Check interaction key press
        if (Input.GetKeyDown(interactionKey) && dialogueManager.firstDialoguePanel.activeSelf)
        {
            // Start the dialogue when the interaction key is pressed
            dialogueManager.StartDialogue();
        }

        // Check for exit key press to close dialogue
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (dialogueManager.secondDialoguePanel.activeSelf)
            {
                dialogueManager.EndDialogue();
            }
        }
    }
}
