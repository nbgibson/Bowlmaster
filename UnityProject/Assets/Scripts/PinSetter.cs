﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;
    public int lastStandingCount = -1;
    public GameObject pinSet;

    private bool ballEnteredBox = false;
    private float lastChangeTime;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();


        if (ballEnteredBox)
        {
            UpdateStandingCountAndSettle();
        }
    }   

    public void RaisePins()
    {
        Debug.Log("RAISING PINS");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        Debug.Log("LOWERING PINS");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("RENEWING PINS");
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 20, 0);
    }

    private void UpdateStandingCountAndSettle()
    {
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1; //Pins settled, ball not back in box (a new frame)
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    public int CountStanding()
    {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;

        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }
}