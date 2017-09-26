using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]

public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private float startTime, endTime;
    private Vector3 dragStart, dragEnd;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
	public void DragStart()
    {//Get time and position of drag start
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {//Launch the ball
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;

        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration; //Drag interacts on a 2D plane, but the vertical element translates to the 3D Z plane for purposes of controlling the ball
        Vector3 launchVelocity = new Vector3(launchSpeedX, 0f, launchSpeedZ);
        ball.Launch(launchVelocity);
    }
}
