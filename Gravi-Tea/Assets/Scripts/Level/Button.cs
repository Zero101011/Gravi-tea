using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private bool isPressable = false;
    public GameObject hintText;
    public GameObject hideObJ;

	// Use this for initialization
	void Start () {
        hintText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(isPressable == true && Input.GetKeyDown("e"))
        {
            hideObJ.SetActive(false);
            print("yeet");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hintText.SetActive(true);
            isPressable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hintText.SetActive(false);
            isPressable = false;
        }
    }

}
