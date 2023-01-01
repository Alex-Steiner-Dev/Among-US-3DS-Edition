using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoving : MonoBehaviour {
    public void Move(Vector2 pos)
    {
        float step = .075f * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, pos, step);
    }
}
