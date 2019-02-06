using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreasureChest : Interactable
{

    public float radius = 3f;
    protected InteractionButton interaction;
    protected GameObject player;
    public Transform interactionTransform;

    void Start()
    {
        interaction = FindObjectOfType<InteractionButton>();
        player = GameObject.Find("Player");
        interactionTransform = this.transform;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public override void Interact()
    {
        Debug.Log("Intearacting with TreasureChest");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.transform.position, interactionTransform.position);
        if (interaction.Pressed == true && distance <= radius)
        {
            Interact();
        }
    }

}
