using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItemIcons : MonoBehaviour
{
    [SerializeField] private GameObject bowlImage;
    [SerializeField] private GameObject noodleImage;
    [SerializeField] private GameObject kettleImage;

    private void OnEnable()
    {
        PlayerInteraction.onBowlPickedUp += OnBowlPickedUp;
        PlayerInteraction.onKettlePickedUp += OnKettlePickedUp;
        PlayerInteraction.onNoodlesPickedUp += OnNoodlesPickUp;
        PlayerInteraction.onBowlFilledWithNoodles += OnNoodlesDrop;
        
        bowlImage.SetActive(false);
        noodleImage.SetActive(false);
        kettleImage.SetActive(false);
    }

    private void OnDisable()
    {
        PlayerInteraction.onBowlPickedUp -= OnBowlPickedUp;
        PlayerInteraction.onKettlePickedUp -= OnKettlePickedUp;
        PlayerInteraction.onNoodlesPickedUp -= OnNoodlesPickUp;
    }

    private void OnNoodlesPickUp()
    {
        noodleImage.SetActive(true);
    }
    
    private void OnNoodlesDrop()
    {
        noodleImage.SetActive(false);
    }

    private void OnKettlePickedUp()
    {
        kettleImage.SetActive(true);
    }

    private void OnBowlPickedUp()
    {
        bowlImage.SetActive(true);
    }
}
