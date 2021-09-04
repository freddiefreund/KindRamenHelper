using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noodles : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerInteraction.onNoodlesPickedUp += PickUp;
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
}
