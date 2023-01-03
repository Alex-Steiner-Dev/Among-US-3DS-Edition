using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimator : MonoBehaviour
{
    [SerializeField] private Animator m_anim_legs;
    [SerializeField] private Animator m_anim_hat;

    [SerializeField] private Animator m_anim_player;

    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        AnimationHandler();
    }

    private void AnimationHandler()
    {
        if (rb.position.x != 0) // moving
        {
            m_anim_hat.SetBool("Walk", true);
            m_anim_hat.SetBool("Idle", false);

            m_anim_legs.SetBool("Walk", true);
            m_anim_legs.SetBool("Idle", false);

            m_anim_player.SetBool("Walk", true);
            m_anim_player.SetBool("Idle", false);

            if (rb.position.x < 0) // facing left
            {
                m_anim_player.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                m_anim_hat.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                m_anim_legs.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            else if (rb.position.x > 0) // facing right && is flipped
            {
                m_anim_player.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                m_anim_hat.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                m_anim_legs.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        else if(rb.position.x == 0) // idle
        {
            m_anim_hat.SetBool("Walk", false);
            m_anim_hat.SetBool("Idle", true);

            m_anim_legs.SetBool("Walk", false);
            m_anim_legs.SetBool("Idle", true);

            m_anim_player.SetBool("Walk", false);
            m_anim_player.SetBool("Idle", true);
        }
    }
}
