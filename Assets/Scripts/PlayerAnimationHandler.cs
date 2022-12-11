using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {

	[SerializeField] private SpriteRenderer m_hatSprite;
	[SerializeField] private SpriteRenderer m_legsSprite;

	[SerializeField] private BodyPart m_legs;
	[SerializeField] private BodyPart m_hat;

	[SerializeField] private PlayerController m_playerController;

	bool facingRight = true;

	private void Start()
	{
		StartCoroutine(AnimationHandler());
	}

	private IEnumerator AnimationHandler()
	{
		while (true)
		{
			float horizontal = Input.GetAxisRaw("Horizontal");

			// Set facing
			if(horizontal > 0 && !facingRight) { facingRight = true; }

			else if(horizontal < 0 && facingRight) { facingRight = false;  }

            // Checking player facing and flipping the sprite to it
            if (facingRight) // right = no flip
            {
                this.GetComponent<SpriteRenderer>().flipX = false;

                m_hatSprite.flipX = false;
                m_legsSprite.flipX = false;
            }

            else // left = flip
            {
                this.GetComponent<SpriteRenderer>().flipX = true;

                m_hatSprite.flipX = true;
                m_legsSprite.flipX = true;
            }

			// Animating
			if(horizontal == 0) // idle
			{
				for(int i = 0; i < m_legs.m_idle.Length; i++) // legs idle
				{
					m_legsSprite.sprite = m_legs.m_idle[i];
                    yield return new WaitForSeconds(100 / 15 * 0.5f); // fps * frame speed
                }

                for (int i = 0; i < m_hat.m_idle.Length; i++) // hat idle
                {
                    m_hatSprite.sprite = m_hat.m_idle[i];
                    yield return new WaitForSeconds(100 / 15 * 0.5f); // fps * frame speed
                }
            }

			else // walking
			{
                for (int i = 0; i < m_legs.m_walk.Length; i++) // legs walking
                {
                    m_legsSprite.sprite = m_legs.m_walk[i];
                    yield return new WaitForSeconds(100 / 15 * 0.5f); // fps * frame speed
                }

                for (int i = 0; i < m_hat.m_walk.Length; i++) // hat walking
                {
                    m_hatSprite.sprite = m_hat.m_walk[i];
                    yield return new WaitForSeconds(100 / 15 * 0.5f); // fps * frame speed
                }
            }
		}
	}
}

[System.Serializable]
public class BodyPart
{
	[SerializeField] public Sprite[] m_idle;
	[SerializeField] public Sprite[] m_walk;
	[SerializeField] public Sprite[] m_die;
}
