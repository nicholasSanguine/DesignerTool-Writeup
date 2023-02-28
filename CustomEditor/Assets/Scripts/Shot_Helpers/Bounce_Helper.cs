using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Helper : MonoBehaviour
{
    public float someValue; //irrelevant here but we use it in our editor
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Wall")
            return;
        Vector3 objectA = this.transform.position;
        Vector3 objectB = collision.transform.position;
        objectB.y = objectA.y;
        Vector3 dir = objectB - objectA;
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        float scalar = rigidbody.velocity.magnitude;
        rigidbody.velocity += dir * scalar;//This is extremely naive collision.
    }
}
