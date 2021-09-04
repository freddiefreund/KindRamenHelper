using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestMovement : MonoBehaviour
{
    [SerializeField] AudioClip[] footsteps;
    [SerializeField] private float speed;
    [SerializeField] float footstepDelay = 0.4f;
    
    private Vector3 movingDirection;
    float timeStamp;
    AudioSource source;
    
    private void Start()
    {
        timeStamp = Time.time;
        source = GetComponent<AudioSource>();
        source.clip = footsteps[0];
        movingDirection = Vector3.zero;
    }

    public void MoveRight()
    {
        movingDirection = Vector3.right;
    }

    public void MoveLeft()
    {
        movingDirection = Vector3.left;
    }

    public void MoveUp()
    {
        movingDirection = Vector3.up;
    }

    public void MoveDown()
    {
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
