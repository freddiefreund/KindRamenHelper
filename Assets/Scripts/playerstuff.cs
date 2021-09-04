using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class playerstuff : MonoBehaviour
{
    [SerializeField] KeyCode interactButton;
    public static Action onKettlePickedUp;
    public static Action onKettleFill;
    public static Action onKettleStart;

    [SerializeField] GameObject kettle;
    
    float collisionDistance = 0.7f;
    bool holdingKettle = true;
    void Update()
    {
        if (Input.GetKeyDown(interactButton))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, collisionDistance);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.name == "Kettle")
                {
                    holdingKettle = true;
                    onKettlePickedUp?.Invoke();
                } 
                else if (hit.collider.name == "KettleStation")
                {
                    if (holdingKettle)
                    {
                        holdingKettle = false;
                        onKettleStart?.Invoke();
                    }
                }
                else if (hit.collider.name == "Sink")
                {
                    if (holdingKettle)
                    {
                        holdingKettle = false;
                        onKettleFill?.Invoke();
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down * collisionDistance);
    }
}
