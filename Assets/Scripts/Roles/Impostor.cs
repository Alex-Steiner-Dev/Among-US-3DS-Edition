using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Impostor : MonoBehaviour {

	[SerializeField] public GameObject killedPlayer;
	[SerializeField] private float killRange = 1f;
    [SerializeField] private float cooldown = 10;

	[SerializeField] private AudioClip killSound;

    [SerializeField] private GameObject reportButton;

    GameObject reportedBody;

    public bool canKill;

	private void Start ()
	{
        reportButton = GameObject.Find("ReportButton");

        killSound = GameObject.Find("KillSound").GetComponent<AudioSource>().clip;
        GetComponent<AudioSource>().spatialBlend = 1;

        if(gameObject.name == "Player")
        {
            killRange = 20;
        }
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

        GameObject.Find("Manager").GetComponent<Manager>().playersAlive--;

        if(GameObject.Find("Manager").GetComponent<Manager>().playersAlive == 0) // impostor wins
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene(4);
        }

        else if(killedPlayer != GameObject.Find("Player")) // player is still alive and we are playing
        {
            killedPlayer.GetComponent<Animator>().SetBool("Walk", false);
            killedPlayer.GetComponent<Animator>().SetBool("Idle", false);

            killedPlayer.GetComponent<Animator>().SetBool("Die", true);

            killedPlayer.GetComponent<AIController>().enabled = false;
            killedPlayer.GetComponent<AIMoving>().enabled = false;
            killedPlayer.AddComponent<DeadBody>();
            killedPlayer.GetComponent<CapsuleCollider2D>().isTrigger = true;

            cooldown = 10;
            canKill = false;
        }

        else // player was killed
        {
            StartCoroutine(PlayerAnimation());
        }

        killedPlayer = null;
    }

    private void KillPlayerCheck()
	{
		// we do basically the same thing as we where doing the nearest player however we just put a range
		GameObject tempPlayer = null;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		float nearestPlayerDistance = 100;

        for (int i = 0; i < players.Length; i++)
        {
            if ((Vector3.Distance(this.transform.position, players[i].transform.position) < killRange) && (Vector3.Distance(this.transform.position, players[i].transform.position) < nearestPlayerDistance) && (Vector3.Distance(this.transform.position, players[i].transform.position) > 0.1f))
            {
                // nearest player found & update
                tempPlayer = players[i];
                nearestPlayerDistance = Vector3.Distance(this.transform.position, players[i].transform.position);
            }
        }

        if (tempPlayer)
        {
            try
            {
                GameObject.Find("KillButton").GetComponent<Button>().interactable = true;
            }
            catch
            {

            }
        }
        else
        {
            try
            {
                GameObject.Find("KillButton").GetComponent<Button>().interactable = false;
            }
            catch
            {

            }
        }

		killedPlayer = tempPlayer;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Dead")
        {
            reportButton.GetComponent<Button>().interactable = true;

            reportedBody = collision2D.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Dead")
        {
            reportButton.GetComponent<Button>().interactable = false;

            reportedBody = null;
        }
    }

    IEnumerator PlayerAnimation()
    {
        killedPlayer.GetComponent<Animator>().SetBool("Walk", false);
        killedPlayer.GetComponent<Animator>().SetBool("Idle", false);

        killedPlayer.GetComponent<Animator>().SetBool("Die", true);

        yield return new WaitForSeconds(5);

        Destroy(GameObject.Find("Player"));

        SceneManager.LoadScene(4);
    }
}
