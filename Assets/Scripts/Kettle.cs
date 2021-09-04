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
    [SerializeField] private GameObject interactionZone;
    [SerializeField] private AudioClip fillSound;
    [SerializeField] private AudioClip boilSound;
    
    [HideInInspector] public bool isFull = false;
    [HideInInspector] public bool isBoiled = false;

    AudioSource source;
    private SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        source = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerInteraction.onKettleFill += Fill;
        PlayerInteraction.onKettleStart += Boil;
        PlayerInteraction.onKettlePickedUp += PickUp;
        PlayerInteraction.onBowlFilledWithWater += FillBowl;
        PlayerInteraction.onPutEmptyKettleOnStation += PutKettle;
    }

    void OnDisable()
    {
        PlayerInteraction.onKettleFill -= Fill;
        PlayerInteraction.onKettleStart -= Boil;
        PlayerInteraction.onKettlePickedUp -= PickUp;
        PlayerInteraction.onBowlFilledWithWater -= FillBowl;
        PlayerInteraction.onPutEmptyKettleOnStation -= PutKettle;
    }

    private void PutKettle()
    {
        transform.position = kettleBase.position;
        spriteRenderer.enabled = true;
        interactionZone.SetActive(true);
    }

    public void Boil()
    {
        if (isFull)
        {
            Debug.Log("boil");
            transform.position = kettleBase.position;
            spriteRenderer.enabled = true;
            interactionZone.SetActive(true);
            StartCoroutine(BoilWater());
        }
    }
    
    private void FillBowl()
    {
        isFull = false;
    }

    public void Fill()
    {
        Debug.Log("fill");
        transform.position = sink.position;
        spriteRenderer.enabled = true;
        interactionZone.SetActive(true);
        StartCoroutine(FillWater());
    }
    
    private void PickUp()
    {
        spriteRenderer.enabled = false;
        interactionZone.SetActive(false);
    }

    IEnumerator FillWater()
    {
        source.clip = fillSound;
        source.loop = false;
        source.Play();
        yield return new WaitForSeconds(fillTime);
        isFull = true;
        Debug.Log("full");
    }
    
    IEnumerator BoilWater()
    {
        source.clip = boilSound;
        source.loop = true;
        source.Play();
        Debug.Log("boiling");
        
        yield return new WaitForSeconds(boilTime);
        source.Stop();
        isBoiled = true;
        Debug.Log("boiled");
    }
}
