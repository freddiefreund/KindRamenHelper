using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestMovement : MonoBehaviour
{
    [SerializeField] AudioClip[] footsteps;
    [SerializeField] Sprite[] sprites;
    [SerializeField] private float speed;
    [SerializeField] float footstepDelay = 0.4f;
    
    private Vector3 movingDirection;
    float timeStamp;
    AudioSource source;
    SpriteRenderer spriterenderer;
    
    private void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        timeStamp = Time.time;
        source = GetComponent<AudioSource>();
        source.clip = footsteps[0];
        movingDirection = Vector3.zero;
    }

    public void MoveRight()
    {
        spriterenderer.sprite = sprites[2];
        movingDirection = Vector3.right;
    }

    public void MoveLeft()
    {
        spriterenderer.sprite = sprites[3];
        movingDirection = Vector3.left;
    }

    public void MoveUp()
    {
        spriterenderer.sprite = sprites[0];
        movingDirection = Vector3.up;
    }

    public void MoveDown()
    {
        spriterenderer.sprite = sprites[1];
        movingDirection = Vector3.down;
    }

    public void StopMoving()
    {
        movingDirection = Vector3.zero;
    }

    private void Update()
    {
        if (movingDirection != Vector3.zero && (Time.time > timeStamp + footstepDelay))
        {
            timeStamp = Time.time;
            if (Random.Range(0,3) != 0)
            {
                int index = Random.Range(0, 5);
                source.clip = footsteps[index];
            }
            source.Play();
            Debug.Log("footstep");
        }
        transform.position += movingDirection * speed * Time.deltaTime;
    }
}
