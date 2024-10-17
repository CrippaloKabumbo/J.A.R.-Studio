using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject firstDialoguePanel;  // Assign Panel 1
    public GameObject secondDialoguePanel; // Assign Panel 2
    private player player; // Reference to player script

    private void Start()
    {
        // Hidden at the start
        firstDialoguePanel.SetActive(false);
        secondDialoguePanel.SetActive(false);

        
        player = FindObjectOfType<player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Show first dialogue panel when player enters area
            firstDialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide first dialogue panel when player exits
            firstDialoguePanel.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        // Hide first dialogue panel and show second one
        if (firstDialoguePanel != null && secondDialoguePanel != null) 
        {
            firstDialoguePanel.SetActive(false);
            secondDialoguePanel.SetActive(true);
            if (player != null)
            {
                player.isInDialogue = true; // Set dialogue state
            }
        }
    }

    public void EndDialogue()
    {
        // Hide second dialogue panel
        if (secondDialoguePanel != null) 
        {
            secondDialoguePanel.SetActive(false);
            if (player != null)
            {
                player.isInDialogue = false; // Reset dialogue state
            }
        }
    }
}
