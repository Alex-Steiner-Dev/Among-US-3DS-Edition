using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imposter : MonoBehaviour {

	[SerializeField] private GameObject killedPlayer;
	[SerializeField] private float killRange = 6.5f;
    [SerializeField] private int cooldown = 10;

	public bool canKill;

	private void Start()
	{
		GetComponent<CircleCollider2D>().radius = killRange;
    }

	IEnumerator CoolDown()
	{
		while(true)
		{
			if(!canKill)
			{
				for(cooldown = cooldown; cooldown > 0; cooldown--)
				{
					yield return new WaitForSeconds(2);
				}

				canKill = true;
			}
		}
	}

	public void Kill()
	{
		cooldown = 10;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			// collision with player therefore we save him in our local player variable so that we can keep track of it later on
			killedPlayer = collider.gameObject;
		}
	}

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            // collision with the player exited therefore we can't kill anyone and don't want to have a variable where a player is saved
			// 1st for the memory, i remember you that we are on old nintendo 3ds, 2nd because the login behind this script is that
			// when you click the kill button or the ai decides to kill somebody it takes as reference this variable
			// therefore we just set the variable as an null :)

            killedPlayer = null;
        }
    }
}
