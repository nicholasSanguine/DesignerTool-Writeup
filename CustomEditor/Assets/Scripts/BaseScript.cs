using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseScript : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform spawnPosition;
    public int shots;//Amount needed before needing to reload
    public float someSpeed;//Speed of shots
    public float someRate;//Rate we fire the shots

    void SpawnShot()
    {
        Vector3 dir = this.transform.forward;
        GameObject obj = Instantiate(spawnObject, spawnPosition.position, Quaternion.identity);
        obj.GetComponent<ShotBehavior>().SetData(ref someSpeed,ref dir);//ref is used for just more efficient memory. Don't need it here but it is a helpful practice
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SpawnShot();
        }
    }
}
