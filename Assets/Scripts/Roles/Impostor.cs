using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impostor : MonoBehaviour {

	[SerializeField] public GameObject killedPlayer;
	[SerializeField] private float killRange = 5f;
    [SerializeField] private float cooldown = 10;

	[SerializeField] private AudioClip killSound;

	public bool canKill;

	private void Start ()
	{
		killSound = GameObject.Find("KillSound").GetComponent<AudioSource>().clip;
        GetComponent<AudioSource>().spatialBlend = 1;
    }

	private void Update()
	{
		CoolDown();

		if(canKill)
		{
            KillPlayerCheck();
        }
	}

	void CoolDown()
	{
        if (!canKill)
        {
			if(cooldown > 0)
			{
				cooldown -= Time.deltaTime;
			}
			else
			{
				canKill= true;
			}
        }
    }

	public void Kill()
	{
        Debug.Log(gameObject.name + " killed " + killedPlayer.name);

        GetComponent<AudioSource>().clip = killSound;
        GetComponent<AudioSource>().Play();

        if(killedPlayer != GameObject.Find("Player")) // player is still alive and we are playing
        {
            killedPlayer.GetComponent<Animator>().SetBool("Walk", false);
            killedPlayer.GetComponent<Animator>().SetBool("Idle", false);

            killedPlayer.GetComponent<Animator>().SetBool("Die", true);

            killedPlayer.GetComponent<AIController>().enabled = false;
            killedPlayer.AddComponent<DeadBody>();

            cooldown = 10;
            canKill = false;
        }

        else
        {
            // game over
        }
    }

    private void KillPlayerCheck()
	{
		// we do basically the samething as we where doing the nearest player however we just put a range
		GameObject tempPlayer = null;
        GameObject[] players = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length - 1];
		float nearestPlayerDistance = 100;

		// add players to the array
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != gameObject)
            {
                players[i] = GameObject.FindGameObjectsWithTag("Player")[i];
            }
        }

        for (int i = 0; i < players.Length; i++)
        {
            if ((Vector3.Distance(this.transform.position, players[i].transform.position) < killRange) && (Vector3.Distance(this.transform.position, players[i].transform.position) < nearestPlayerDistance) && (Vector3.Distance(this.transform.position, players[i].transform.position) > 0.1f))
            {
                // nearest player found & update
                tempPlayer = players[i];
                nearestPlayerDistance = Vector3.Distance(this.transform.position, players[i].transform.position);
            }
        }

		killedPlayer = tempPlayer;
    }
}
