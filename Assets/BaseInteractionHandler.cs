using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionHandler : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.Space;  // Default interaction key
    public KeyCode escapeKey = KeyCode.Escape;
    public bool interactionOver;
    public bool isPlayerInRange = false;              // Track if the player is in range to interact
    public DialogueManager dialogueManager;
    public PlayerControllerLayer player; // Reference to player script

    private void Start()
    {
        player = FindObjectOfType<PlayerControllerLayer>();
    }

    // This method will be overridden in subclasses to define specific interactions
    public abstract void Interact();

    public abstract void ExitInteraction();

    // Detect when player enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            OnPlayerEnter();
        }
    }

    // Detect when player exits the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            OnPlayerExit();
        }
    }

    // Optional methods that can be overridden in derived classes
    protected virtual void OnPlayerEnter() { }
    protected virtual void OnPlayerExit() { }

    // Update checks for interaction input
    protected virtual void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {

            Interact();  // Calls the specific interaction method in derived classes
        }

        if (Input.GetKeyDown(escapeKey))
        {

            ExitInteraction();               

        }


    }
}
