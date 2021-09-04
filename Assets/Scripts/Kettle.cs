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
    
    [HideInInspector] public bool isFull = false;
    [HideInInspector] public bool isBoiled = false;

    AudioSource source;

    void OnEnable()
    {
        source = GetComponent<AudioSource>();
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
        source.Play();
        Debug.Log("boiling");
        
        yield return new WaitForSeconds(boilTime);
        source.Stop();
        isBoiled = true;
        Debug.Log("boiled");
    }
}
