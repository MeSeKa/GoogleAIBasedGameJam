using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChanger : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void ChangeNewState(TimeState currentState)
    {
        switch (currentState)
        {
            case TimeState.Old:
                animator.SetTrigger("TimeChangeToFirst");
                break;
            case TimeState.New:
                animator.SetTrigger("TimeChangeToSecond");
                break;
        }
    }

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

}



