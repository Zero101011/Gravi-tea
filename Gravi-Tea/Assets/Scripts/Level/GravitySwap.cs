using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour {

    public GameObject player;
    private float flipRotation;
    private Vector3 cGravity;
    private Vector3 gDirection;
    public bool flipped;
    public float rotation_deltatime_delay = 0.0f;

    Vector3[] gravityDirections = new Vector3[]
    {
        new Vector3(0.0f, -9.8f, 0.0f), // down
        new Vector3(9.8f, 0.0f, 0.0f), // right
        new Vector3(0.0f, 9.8f, 0.0f), // up
        new Vector3(-9.8f, 0.0f, 0.0f) // left
    };

    Vector3[] upDirections = new Vector3[]
    {
        Vector3.up, // gravity down
        Vector3.left, // gravity right
        Vector3.down, // gravity up
        Vector3.right // gravity left
    };

    Vector3[] rightDirections = new Vector3[]
    {
        Vector3.right, // gravity down
        Vector3.up, // gravity right
        Vector3.left, // gravity up
        Vector3.down // gravity left
    };

    //float[] playerRotations =
    //{
    //    0.0f,
    //    90.0f,
    //    180.0f,
    //    270.0f
    //};

    float[] gravityRotations =
    {
        0.0f,
        90.0f,
        180.0f,
        -90.0f
    };

    float playerRotation = 0.0f;

    int currentGravity = 0;

    private Quaternion previous;

    // Use this for initialization
    void Start () {
        flipRotation = 180.0f;
        cGravity = new Vector3(0, -9.8f, 0);
        print("gravity is " + Physics.gravity);

        //player = GameObject.Find("ThirdPersonController");
        player.GetComponent<ThirdPersonCharacter>().m_GravitySwap = this;
	}
	
	// Update is called once per frame
	void Update () {
        //Physics.gravity = cGravity;
        //playerRotateZ();
        gravityRot();
        gravityY();
        //transform.rotation = Quaternion.Lerp(previous, next, Time.time * 0.1f);
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        //Physics.gravity = cGravity;
        //gDirection = cGravity.normalized;
    }

    public Vector3 GetCurrentGravityVector()
    {
        return gravityDirections[currentGravity];
    }

    public Vector3 GetCurrentUpDirection()
    {
        return upDirections[currentGravity];
    }

    public Vector3 GetCurrentRightDirection()
    {
        return rightDirections[currentGravity];
    }

    public float GetCurrentGravityRotation()
    {
        return gravityRotations[currentGravity];
    }

    public float GetCurrentUpSpeed(Vector3 velocity)
    {
        float speed = 0.0f;
        switch(currentGravity)
        {
            case 0:
                speed = velocity.y;
                break;
            case 1:
                speed = -velocity.x;
                break;
            case 2:
                speed = -velocity.y;
                break;
            case 3:
                speed = velocity.x;
                break;
        }

        return speed;
    }

    public float GetTurnAmount(Vector3 move)
    {
        float turnAmount = 0.0f;

        switch(currentGravity)
        {
            case 0:
                turnAmount = Mathf.Atan2(move.x, move.z);
                break;


            case 1:
                turnAmount = Mathf.Atan2(move.y, move.z);
                break;

            case 2:
                turnAmount = Mathf.Atan2(-move.x, move.z);
                break;

            case 3:
                turnAmount = Mathf.Atan2(-move.y, move.z);
                break;
        }

        return turnAmount;
    }

    public void ApplyExtraTurnRotation(Transform transform, float turnAmount, float turnSpeed)
    {
        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);

        //switch (currentGravity)
        //{
        //    case 0:
        //        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
        //        break;

        //    case 1:
        //        transform.Rotate(turnAmount * turnSpeed * Time.deltaTime, 0,  0);
        //        break;

        //    case 2:
        //        transform.Rotate(0, -turnAmount * turnSpeed * Time.deltaTime, 0);
        //        break;

        //    case 3:
        //        transform.Rotate(-turnAmount * turnSpeed * Time.deltaTime, 0, 0);
        //        break;
        //}
    }

    public void PreserveVerticalVelocity(Vector3 v, Vector3 rigidBodyVelocity)
    {
        switch(currentGravity)
        {
            case 0:
            case 2:
                v.y = rigidBodyVelocity.y;
                break;

            case 1:
            case 3:
                v.x =rigidBodyVelocity.x;
                break;
        }
    }

    public Vector3 GetInputRightDirection()
    {
        Vector3 direction = new Vector3(1, 0, 0);
        switch (currentGravity)
        {
            case 0:
            case 2:
                direction = new Vector3(1, 0, 0);
                break;

            case 1:
                direction = new Vector3(0, 1, 0);
                break;
            case 3:
                direction = new Vector3(0,  -1 , 0);
                break;
        }

        return direction;
    }

    //public float GetCurrentPlayRotation()
    //{
    //    return playerRotations[currentGravity];
    //}

    void gravityRot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("yeet");

            //cGravity

        }
    }

    void playerRotateZ()
    {
        /*if(player.transform.rotation.z == 0 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            while(player.transform.rotation.z < (90 * Time.deltaTime))
            {

            }
        }*/
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            player.transform.rotation = (0,180,0,0);
        }*/
    }

    void gravityY()
    {
        if (Input.GetKeyDown("f"))
        {
            // change current gravity value
            currentGravity = (currentGravity + 1) % 4;
            float previousRotation = playerRotation;
            playerRotation = (playerRotation + 90) /*% 360*/;

            print("Gravity INV test2");
            //flipped = true;
            Physics.gravity = GetCurrentGravityVector();
            gDirection = Physics.gravity;
            gDirection.Normalize();
            //playerRotate();

            //player.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z + 180, player.transform.rotation.w );
            previous = player.transform.rotation;
            TestRot();

            //StartCoroutine("PlayerTransformRotate", previousRotation);
        }
        else
        {
            if (Input.GetKeyDown("v"))
            {
                // change current gravity value
                currentGravity = (currentGravity + 3) % 4;
                float previousRotation = playerRotation;
                playerRotation = (playerRotation + 90) /*% 360*/;

                print("Gravity INV test2");
                //flipped = true;
                Physics.gravity = GetCurrentGravityVector();
                gDirection = Physics.gravity;
                gDirection.Normalize();
                //playerRotate();

                //player.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z + 180, player.transform.rotation.w );
                previous = player.transform.rotation;
                TestRotR();

                //StartCoroutine("PlayerTransformRotate", previousRotation);
            }
        }
    }

    IEnumerator PlayerTransformRotate(float previousRotation)
    {
        Quaternion initial_rotation = player.transform.rotation;
        Quaternion desired_rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z + 180, player.transform.rotation.w);
        for (float zRotation = previousRotation; zRotation <= playerRotation; zRotation += 5.0f)
        {
            Vector3 angles = player.transform.eulerAngles;
            angles.z = zRotation;
            player.transform.eulerAngles = angles;
            Debug.Log("lerp: " + zRotation);

            //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, next, lerp);
            //Debug.Log("lerp: " + Quaternion.Slerp(player.transform.rotation, next, lerp));
            yield return new WaitForSeconds(rotation_deltatime_delay);
        }
    }

    public void TestRot()
    {
        player.transform.Rotate(0f,0f,90f,Space.World);
    }

    public void TestRotR()
    {
        player.transform.Rotate(0f, 0f, -90f, Space.World);
    }

}
