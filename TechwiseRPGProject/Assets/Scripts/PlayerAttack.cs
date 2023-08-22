using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite[] attackSprites;
    private int currentSpriteIndex = 0;
    private Sprite originalSprite;

    void Start()
    {
        originalSprite = spriteRenderer.sprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        currentSpriteIndex = (currentSpriteIndex + 1) % attackSprites.Length;
        spriteRenderer.sprite = attackSprites[currentSpriteIndex];
        StartCoroutine(RevertSprite());
    }

    IEnumerator RevertSprite()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        spriteRenderer.sprite = originalSprite;
    }
}
