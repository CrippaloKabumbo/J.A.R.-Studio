using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject firstDialoguePanel;  // Assign Panel 1
    public GameObject secondDialoguePanel; // Assign Panel 2
    public PlayerControllerLayer player; // Reference to player script

    private void Start()
    {
        // Hidden at the start
        firstDialoguePanel.SetActive(false);
        secondDialoguePanel.SetActive(false);

        player = FindObjectOfType<PlayerControllerLayer>();
    }

    public void StartDialogue()
    {
        // Hide first dialogue panel and show second one
        firstDialoguePanel.SetActive(false);
        secondDialoguePanel.SetActive(true);
        if (player != null)
        {
            player.isInDialogue = true; // Set dialogue state

        }
    }

    public void EndDialogue()
    {
        // Hide second dialogue panel
        secondDialoguePanel.SetActive(false);
        if (player != null)
        {
            player.isInDialogue = false; // Reset dialogue state
            
        }

    }

}
