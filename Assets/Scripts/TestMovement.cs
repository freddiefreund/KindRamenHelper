using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InteractionButtonTweener interactionButtonTweener;
    private Vector3 movingDirection;
    private void Start()
    {
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
        transform.position += movingDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I can interact");
        interactionButtonTweener.TweenIn();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactionButtonTweener.TweenOut();
        Debug.Log("I cannot interact");
    }
}
