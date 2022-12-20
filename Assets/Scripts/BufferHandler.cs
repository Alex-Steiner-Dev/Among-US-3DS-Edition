using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferHandler : MonoBehaviour {

	[SerializeField] private Transform[] m_objects;
	[SerializeField] private float m_distance;

	private void Start (){
		for(int i = 0; i < GameObject.FindGameObjectsWithTag("Map").Length; i++){
			m_objects[i] = GameObject.FindGameObjectsWithTag("Map")[i].transform;

        }

		StartCoroutine(CheckDistance());
	}

	private IEnumerator CheckDistance(){
		while (true){

			for (int i = 0; i < m_objects.Length; i++){
				if (Vector2.Distance(transform.position, m_objects[i].position) < m_distance){
					m_objects[i].gameObject.SetActive(true);
				}
				else if (m_objects[i].gameObject.activeSelf){
					m_objects[i].gameObject.SetActive(false);
				}
			}

			yield return new WaitForSecondsRealtime(1000 / 15); // fps rate
		}
	}
}
