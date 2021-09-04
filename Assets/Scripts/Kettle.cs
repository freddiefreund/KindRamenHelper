using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kettle : MonoBehaviour
{
    [SerializeField] Transform kettleBase;
    [SerializeField] Transform sink;
    [SerializeField] float boilTime = 13f;
    [SerializeField] float fillTime = 5f;
    
    public bool isFull = false;
    public bool isBoiled = false;

    void OnEnable()
    {
        playerstuff.onKettleStart += Boil;
        playerstuff.onKettleFill += Fill;
    }
    void OnDisable()
    {
        playerstuff.onKettleStart -= Boil;
        playerstuff.onKettleFill -= Fill;
    }

    public void Boil()
    {
        if (isFull)
        {
            Debug.Log("boil");
            transform.position = kettleBase.position;
            StartCoroutine(BoilWater());
        }
    }

    public void Fill()
    {
        Debug.Log("fill");
        transform.position = sink.position;
        StartCoroutine(FillWater());
    }

    IEnumerator FillWater()
    {
        yield return new WaitForSeconds(fillTime);
        isFull = true;
        Debug.Log("full");
    }
    
    IEnumerator BoilWater()
    {
        yield return new WaitForSeconds(boilTime);
        isBoiled = true;
        Debug.Log("boiled");
    }
}
