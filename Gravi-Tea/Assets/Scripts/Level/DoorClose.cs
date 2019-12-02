using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{

    public bool DoorTriggered;
    public GameObject door;

    // Use this for initialization
    void Start()
    {
        door.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (DoorTriggered == true)
        {
            door.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoorTriggered = true;
        }
    }
}
