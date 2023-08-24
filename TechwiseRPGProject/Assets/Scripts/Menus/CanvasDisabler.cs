using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDisabler : MonoBehaviour
{
    public Animator animator;
    public Canvas canvas;

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
        {
            canvas.enabled = false;
        }
    }
}
