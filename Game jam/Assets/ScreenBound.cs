using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBound : MonoBehaviour {

    [SerializeField]
    bool top;
    [SerializeField]
    bool left;
    [SerializeField]
    bool right;
    [SerializeField]
    bool bottom;
    [SerializeField]
    float pushStrength = 1.5f;


    public Vector2 PushInDirection(Rigidbody2D rb)
    {
        if (top)
        {
            return new Vector2(rb.velocity.x, rb.velocity.y-pushStrength);
        }
        else if (left)
        {
            return new Vector2(rb.velocity.x+pushStrength, rb.velocity.y);
        }
        else if (right)
        {
            return new Vector2(rb.velocity.x-pushStrength, rb.velocity.y);
        }
        else
        {
            return new Vector2(rb.velocity.x, rb.velocity.y + pushStrength);
        }
    }
}
