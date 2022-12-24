using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {
    [SerializeField] private Animator m_anim_legs;
    [SerializeField] private Animator m_anim_hat;

    [SerializeField] private Animator m_anim_player;

    private void Update()
    {
        AnimationHandler();
    }

    private void AnimationHandler()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) // moving
        {
            m_anim_hat.SetBool("Walk", true);
            m_anim_hat.SetBool("Idle", false);

            m_anim_legs.SetBool("Walk", true);
            m_anim_legs.SetBool("Idle", false);

            m_anim_player.SetBool("Walk", true);
            m_anim_player.SetBool("Idle", false);

            if (Input.GetAxisRaw("Horizontal") < 0) // facing left
            {
                m_anim_player.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                m_anim_hat.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                m_anim_legs.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            else if (Input.GetAxisRaw("Horizontal") > 0 && m_anim_player.gameObject.GetComponent<SpriteRenderer>().flipX) // facing right && is flipped
            {
                m_anim_player.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                m_anim_hat.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                m_anim_legs.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        else // idle
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
