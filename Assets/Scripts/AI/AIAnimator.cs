using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimator : MonoBehaviour
{
    [SerializeField] private Animator m_anim_legs;
    [SerializeField] private Animator m_anim_hat;

    [SerializeField] private Animator m_anim_player;

    string position = "idle";
    Vector2 old_pos;

    private void Start()
    {
        old_pos = transform.position;
    }

    private void Update()
    {
        AnimationHandler();
        PositionCheck();
    }

    private void AnimationHandler()
    {
        if (position != "idle") // moving
        {
            m_anim_hat.SetBool("Walk", true);

            m_anim_legs.SetBool("Walk", true);
            m_anim_legs.SetBool("Idle", false);

            m_anim_player.SetBool("Walk", true);
            m_anim_player.SetBool("Idle", false);

            if (position == "left") // facing left
            {
                m_anim_player.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                m_anim_hat.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                m_anim_legs.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            else if (position == "right") // facing right && is flipped
            {
                m_anim_player.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                m_anim_hat.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                m_anim_legs.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        else  // idle
        {
            m_anim_hat.SetBool("Walk", false);

            m_anim_legs.SetBool("Walk", false);
            m_anim_legs.SetBool("Idle", true);

            m_anim_player.SetBool("Walk", false);
            m_anim_player.SetBool("Idle", true);
        }
    }

    private void PositionCheck()
    {
        if(old_pos.x != transform.position.x) // not idle
        {
            if (Mathf.Abs(transform.position.x) < Mathf.Abs(old_pos.x)) // right
            {
                position = "right";
            }
            else// left
            {
                position = "left";
            }
        }
        else
        {
            if(old_pos.y == transform.position.y) 
                position = "idle";
        }

        old_pos = transform.position;
    }
}
