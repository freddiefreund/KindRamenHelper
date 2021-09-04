using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public bool hasNoodles;
    public bool hasWater;

    private void OnEnable()
    {
        PlayerInteraction.onBowlFilledWithNoodles += FillWithNoodles;
        PlayerInteraction.onBowlFilledWithWater += FillWithWater;
    }

    private void OnDisable()
    {
        PlayerInteraction.onBowlFilledWithNoodles -= FillWithNoodles;
        PlayerInteraction.onBowlFilledWithWater -= FillWithWater;
    }

    private void FillWithWater()
    {
        hasWater = true;
        Debug.Log("Bowl is filled with water");
    }

    private void FillWithNoodles()
    {
        hasNoodles = true;
        Debug.Log("Bowl is filled with noodles");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
