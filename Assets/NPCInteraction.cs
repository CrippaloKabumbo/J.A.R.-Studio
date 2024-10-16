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
            // Show first dialogue panel when player enters box
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
            // Hide first dialogue panel when player exits the box
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
            // Start dialogue when interaction key is pressed
            dialogueManager.StartDialogue();
        }

        // Check exit key press to close dialogue
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (dialogueManager.secondDialoguePanel.activeSelf)
            {
                dialogueManager.EndDialogue();
            }
        }
    }
}
