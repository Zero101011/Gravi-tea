using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayWithMover : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "platform")
        {
            player.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "platform")
        {
            player.transform.parent = null;
        }
    }

}
