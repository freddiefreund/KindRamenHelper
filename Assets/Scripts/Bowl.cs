using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public bool hasNoodles;
    public bool hasWater;

    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    
    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerInteraction.onBowlFilledWithNoodles += FillWithNoodles;
        PlayerInteraction.onBowlFilledWithWater += FillWithWater;
        PlayerInteraction.onBowlPickedUp += PickUp;
    }

    private void OnDisable()
    {
        PlayerInteraction.onBowlFilledWithNoodles -= FillWithNoodles;
        PlayerInteraction.onBowlFilledWithWater -= FillWithWater;
        PlayerInteraction.onBowlPickedUp -= PickUp;
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }

    private void FillWithWater()
    {
        hasWater = true;
        Debug.Log("Bowl is filled with water");
        spriteRenderer.sprite = sprites[2];
    }

    private void FillWithNoodles()
    {
        hasNoodles = true;
        Debug.Log("Bowl is filled with noodles");
        spriteRenderer.sprite = sprites[1];
        //StartCoroutine(Smoke());
    }

    IEnumerator Smoke()
    {
        yield return new WaitForSeconds(2f);
        spriteRenderer.sprite = sprites[2];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            FillWithNoodles();
    }
}
