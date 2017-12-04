using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private new Rigidbody rigidbody;
    private AudioSource audioSource;
    private Vector3 ballStartPos;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        audioSource = GetComponent<AudioSource>();
        rigidbody.useGravity = true;
        rigidbody.velocity = velocity;
        audioSource.Play();
    }

    public void Reset()
    {
        Debug.Log("Ball reset");
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update () {
    }
}
