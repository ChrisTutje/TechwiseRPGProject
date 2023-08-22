using UnityEngine;

public class FreezeAnimation : MonoBehaviour
{
    public Canvas canvas;
    private Animator animator;
    private float timer = 0f;
    private float resetTime = 3f;
    private bool isPlaying = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && isPlaying)
        {
            animator.speed = 0;
            timer += Time.deltaTime;
            if (timer >= resetTime)
            {
                animator.speed = 0;
                animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0f);
                timer = 0f;
                isPlaying = false;
                canvas.gameObject.SetActive(false);
            }
        }
    }

    public void PlayAnimation()
    {
        isPlaying = true;
        animator.speed = 1;
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0f);
        canvas.gameObject.SetActive(true);
    }
}
