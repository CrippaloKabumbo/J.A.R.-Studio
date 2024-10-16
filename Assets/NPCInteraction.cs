using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    // setting the interact key
    public KeyCode interactionKey = KeyCode.Space;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Check interaction key press
        if (Input.GetKeyDown(interactionKey))
        {
            // check player interaction
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                Interact();
            }
        }

    }
    void Interact()
    {
        // Logic for interacting with the NPC
        Debug.Log("Interacted with NPC: " + gameObject.name);
    }
}
