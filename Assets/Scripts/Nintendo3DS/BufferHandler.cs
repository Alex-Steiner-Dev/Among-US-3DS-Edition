using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferHandler : MonoBehaviour {

	[SerializeField] private SpriteRenderer[] m_objects;
	[SerializeField] private float m_distance;

    Manager manager;

    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();

        m_objects = (SpriteRenderer[])FindObjectsOfType(typeof(SpriteRenderer));

        foreach(SpriteRenderer sprite in m_objects) 
        {
            sprite.enabled = false;
        }
    }

    private void Update()
    {
        for (int i = 0; i < m_objects.Length; i++)
        {
            try
            {
                if (Vector2.Distance(manager.player.transform.position, m_objects[i].gameObject.transform.position) < m_distance)
                {
                    m_objects[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (m_objects[i].gameObject.GetComponent<SpriteRenderer>().enabled)
                {
                    m_objects[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            catch { }
        }
    }
}
