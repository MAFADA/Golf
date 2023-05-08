using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Collider col;
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    bool shoot;


    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //     if (Physics.Raycast(ray, out var hitInfo) && hitInfo.collider == col)
        //     {
        //         shoot = true;
        //     }
        // }
    }

    private void FixedUpdate()
    {
        if (shoot)
        {
            shoot = false;
            Vector3 direction = Camera.main.transform.forward;
            direction.y = 0;
            rb.AddForce(direction * force, ForceMode.Impulse);
        }

        if (rb.velocity.sqrMagnitude < 0.01f && rb.velocity.sqrMagnitude > 0)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public bool IsMove()
    {
        return rb.velocity != Vector3.zero;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        
    }
}
