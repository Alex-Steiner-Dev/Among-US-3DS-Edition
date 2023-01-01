using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferHandler : MonoBehaviour {

	[SerializeField] private SpriteRenderer[] m_objects;
	[SerializeField] private float m_distance;

    private void Update()
    {
        for (int i = 0; i < m_objects.Length; i++)
        {
            if (Vector2.Distance(transform.position, m_objects[i].gameObject.transform.position) < m_distance)
            {
                m_objects[i].gameObject.SetActive(true);
            }
            else if (m_objects[i].gameObject.activeSelf)
            {
                m_objects[i].gameObject.SetActive(false);
            }
        }
    }

    public void LoadBufferHandler()
    {
        m_objects = (SpriteRenderer[]) FindObjectsOfType(typeof(SpriteRenderer));
    }
}
