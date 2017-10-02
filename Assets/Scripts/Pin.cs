using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold;
    public Rigidbody pin;

	// Use this for initialization
	void Start () {
        pin = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        IsStanding();
	}

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            Debug.Log(name + " standing");
            return true;
        }

        Debug.Log(name + " fallen");
        return false;
    }
}
