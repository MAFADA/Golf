using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutsideArena : MonoBehaviour
{
    public UnityEvent OnBallEnter = new UnityEvent();
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            OnBallEnter.Invoke();
        }
    }
}
