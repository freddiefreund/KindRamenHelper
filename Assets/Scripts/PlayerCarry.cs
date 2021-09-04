using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Interaction
{
    None,
    Kettle,
    Bowl,
    Noodles,
    Table,
    Sink
}

enum CarryItem
{
    None,
    Kettle,
    Bowl,
    Noodles
}

public class PlayerCarry : MonoBehaviour
{
    [SerializeField] private InteractionButtonTweener interactionButtonTweener;
    private int interactionCount;
    private Interaction currentInteraction;
    private CarryItem currentCarryItem;
    private bool tableIsNear;

    private void Start()
    {
        interactionCount = 0;
        currentInteraction = Interaction.None;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (interactionCount == 0)
        {
            interactionButtonTweener.TweenIn();
        }
        interactionCount++;
        if (other.gameObject.CompareTag("Table"))
        {
            tableIsNear = true;
            Debug.Log("Table is near!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactionCount--;
        if (interactionCount == 0)
        {
            interactionButtonTweener.TweenOut();   
        }
        if (other.gameObject.CompareTag("Table"))
        {
            tableIsNear = false;
            Debug.Log("Table is to far away!");
        }
    }
    
    
}
