using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimeShields : MonoBehaviour {

	[SerializeField] private Button[] shields;
	private int startShieldNumbers;

	private void Start()
	{
		AssignShields();
	}

	private void AssignShields()
	{
        startShieldNumbers = Random.Range(2, 6);

		for(int i = 0; i < startShieldNumbers; i++)
		{
			shields[0].gameObject.SetActive(true);
		}
    }

	public void RemoveShield(int n)
	{
		shields[n].gameObject.SetActive(false);

		startShieldNumbers--;

		if(startShieldNumbers == 0)
		{
			Debug.Log("Task Complete!");
		}
	}
}
