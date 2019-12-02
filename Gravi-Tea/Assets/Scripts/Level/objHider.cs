using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objHider : MonoBehaviour {

    public bool Triggered;
    public GameObject obj;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        //Hide or unhide object based on whether the box has triggered the triggerbox
		if(Triggered == true)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            print("oof thats a trigger");
            Triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Box")
        {
            print("oof thats a trigger");
            Triggered = false;
        }
    }
}
