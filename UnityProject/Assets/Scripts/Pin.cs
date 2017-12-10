using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold;
    public float distanceToRaise = 40f;

    private Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        IsStanding();
	}

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            
            return true;
        }

        
        return false;
    }

    //Used in conjunction with setting gravity to -98.1 from -981 to get the pins to sit still already.
    private void Awake()
    {
        this.GetComponent<Rigidbody>().solverVelocityIterations = 10;
    }

    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }

    public void Lower()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
            rigidBody.useGravity = true;
        }
    }
}
