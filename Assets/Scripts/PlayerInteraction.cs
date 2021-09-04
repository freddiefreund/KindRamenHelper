using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Interaction
{
    None,
    Kettle,
    KettleStation,
    Bowl,
    Noodles,
    Sink
}

enum CarryItem
{
    None,
    Kettle,
    Bowl,
    Noodles
}

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InteractionButtonTweener interactionButtonTweener;
    [SerializeField] private Kettle kettle;
    [SerializeField] private Bowl bowl;
    [SerializeField] private Interaction currentInteraction;
    [SerializeField] private CarryItem currentCarryItem;
    private bool tableIsNear;
    public static Action onKettlePickedUp;
    public static Action onKettleFill;
    public static Action onKettleStart;
    public static Action onBowlPickedUp;
    public static Action onBowlFilledWithWater;
    public static Action onBowlFilledWithNoodles;
    public static Action onNoodlesPickedUp;

    private void Start()
    {
        currentInteraction = Interaction.None;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kettle"))
        {
            currentInteraction = Interaction.Kettle;
        }
        else if (other.gameObject.CompareTag("Bowl"))
        {
            if (currentCarryItem == CarryItem.Noodles)
            {
                currentInteraction = Interaction.Bowl;    
            }
            else if (currentCarryItem == CarryItem.Kettle && kettle.isBoiled)
            {
                currentInteraction = Interaction.Bowl;
            }
        }
        else if (other.gameObject.CompareTag("KettleStation"))
        {
            if (currentCarryItem == CarryItem.Kettle)
            {
                currentInteraction = Interaction.KettleStation;    
            }
        }
        else if (other.gameObject.CompareTag("Noodles"))
        {
            currentInteraction = Interaction.Noodles;
        }
        else if (other.gameObject.CompareTag("Sink"))
        {
            if (currentCarryItem == CarryItem.Kettle)
            {
                currentInteraction = Interaction.Sink;
            }
        }

        if (currentInteraction != Interaction.None)
        {
            interactionButtonTweener.TweenIn();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactionButtonTweener.TweenOut();
        currentInteraction = Interaction.None;
    }

    public void Interact()
    {
        if(currentInteraction == Interaction.None)
            return;
        if (currentCarryItem == CarryItem.None)
        {
            if (currentInteraction == Interaction.Kettle)
            {
                onKettlePickedUp?.Invoke();
                currentCarryItem = CarryItem.Kettle;
            }
            else if (currentInteraction == Interaction.Noodles)
            {
                onNoodlesPickedUp?.Invoke();
                currentCarryItem = CarryItem.Noodles;
            }
            else if (currentInteraction == Interaction.Bowl)
            {
                if (bowl.hasNoodles && bowl.hasWater)
                {
                    onBowlPickedUp?.Invoke();
                    currentCarryItem = CarryItem.Bowl;
                }
            }
        }
        else if (currentCarryItem == CarryItem.Kettle)
        {
            if (currentInteraction == Interaction.Sink)
            {
                onKettleFill?.Invoke();
                currentCarryItem = CarryItem.None;
            } 
            else if (currentInteraction == Interaction.KettleStation && kettle.isFull)
            {
                onKettleStart?.Invoke();
                currentCarryItem = CarryItem.None;
            }
            else if (currentInteraction == Interaction.Bowl && kettle.isBoiled)
            {
                onBowlFilledWithWater?.Invoke();
            }
        }
        else if (currentCarryItem == CarryItem.Noodles)
        {
            if (currentInteraction == Interaction.Bowl)
            {
                onBowlFilledWithNoodles?.Invoke();
                currentCarryItem = CarryItem.None;
            }
        }
    }
}
