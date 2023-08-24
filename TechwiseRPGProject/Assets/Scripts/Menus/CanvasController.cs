using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Canvas canvas;
    public Button button;

    private Animator animator;
    private float timer = 0f;
    private float resetTime = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        button.onClick.AddListener(EnableCanvas);
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.speed = 0;
            timer += Time.deltaTime;
            if (timer >= resetTime)
            {
                animator.speed = 1;
                animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0f);
                timer = 0f;
                DisableCanvas();
            }
        }
    }

    public void DisableCanvas()
    {
        canvas.enabled = false;
    }

    public void EnableCanvas()
    {
        canvas.enabled = true;
    }
}
