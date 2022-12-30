using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
	[SerializeField] public Animator m_animator;

	public bool isImpostor;

	private void Start()
	{
		m_animator = GetComponent<Animator>();
    }

    private void Update()
	{
        AnimationHandler();

		if(!isImpostor)
		{
			DoCrewmate();
		}
		else
		{
			DoImpostor();
		}
	}

	public void DoCrewmate()
	{

	}


    public void DoImpostor()
    {
        Impostor m_impostor = GetComponent<Impostor>();

        if (GameObject.Find("Manager").GetComponent<Manager>().isPlaying) // currently playing and trying to kill others
        {
            // move and chase for a kill
            // for this what we will need is the array of all the players except us 
            // then we will figure out which one is the nearest and follow him
            // we will do this process until we can finnaly kill

            ChasePlayerDown(NearestPlayer());

            // checking if we can kill and have a player near us
            if (m_impostor.canKill && m_impostor.killedPlayer)
            {
                m_impostor.Kill();
            }
        }

        else // doing meeting for example
        {

        }
    }

	private void AnimationHandler()
	{
		// takes the magnitude of the ai if grater then 0 it means that he is moving
		// by doing this then we will player the right animation flipped correctly on the x axis

		if(this.transform.position.magnitude != 0) // moving 
		{
			m_animator.SetBool("Walk", true);
			m_animator.SetBool("Idle", false);

			if(this.transform.position.magnitude > 0) // moving right
			{
				// no flip
				this.GetComponent<SpriteRenderer>().flipX = false;
            }

            else if (this.transform.position.magnitude < 0) // moving left
            {
                // flip
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
		}
		else
		{
            m_animator.SetBool("Walk", false);
            m_animator.SetBool("Idle", true);
        }
	}

	private GameObject NearestPlayer()
	{
		// calculate the nearest player
		// in order to do this we will create an array with all the players except for us
		// then calculate the smallest vector distance an return that game object

		GameObject nearestPlayer = null;

		GameObject[] players = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length - 1];

		float nearestPlayerDistance = 100;

		// add players to the array
		for(int i = 0; i < players.Length; i++)
		{
			if (players[i] != gameObject)
			{
				players[i] = GameObject.FindGameObjectsWithTag("Player")[i];
			}
		}

		for(int i = 0; i < players.Length; i++)
		{
			if (Vector3.Distance(this.transform.position, players[i].transform.position) < nearestPlayerDistance){
				// nearest player found & update
				nearestPlayer = players[i];
				nearestPlayerDistance = Vector3.Distance(this.transform.position, players[i].transform.position);
			}
		}

		return nearestPlayer;
	}

	private void ChasePlayerDown(GameObject playerToChaseDown)
	{
		// draw a line that the impostor will need to follow in order to kill
	}
}
