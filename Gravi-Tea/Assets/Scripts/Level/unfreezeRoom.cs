using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unfreezeRoom : MonoBehaviour {

    public GameObject[] roomObjects = new GameObject[3];
    private Rigidbody[] objRigidBodies = new Rigidbody[3];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < roomObjects.Length; i++)
        {
            objRigidBodies[i] = roomObjects[i].GetComponent<Rigidbody>();
            objRigidBodies[i].constraints = RigidbodyConstraints.FreezeAll;

            print("array is " + objRigidBodies[i]);
        }        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < roomObjects.Length; i++)
            {
                objRigidBodies[i] = roomObjects[i].GetComponent<Rigidbody>();
            }

            objRigidBodies[0].constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            objRigidBodies[1].constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            objRigidBodies[2].constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
    }

}
