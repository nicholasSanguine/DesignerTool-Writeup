using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Helper : MonoBehaviour
{

    int someInt; //irrelevant here but we use it in our editor
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Wall")
            return;
        Destroy(this.gameObject);

    }
}
