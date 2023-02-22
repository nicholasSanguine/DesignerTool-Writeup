using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick_Helper : MonoBehaviour
{
    public float SomeFloat;//irrelevant here but we use it in our editor
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Wall")
            return;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
