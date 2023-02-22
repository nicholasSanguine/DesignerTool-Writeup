using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShotBehavior : MonoBehaviour
{
    public enum SomeType
    {
        Bounce, Stick, Destroy

    }
    public SomeType sometype;
    public void SetData(ref float speed,ref Vector3 dir)
    {
        this.GetComponent<Rigidbody>().velocity = dir* speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
