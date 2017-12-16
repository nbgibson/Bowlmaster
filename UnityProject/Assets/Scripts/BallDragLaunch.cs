using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]

public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private float startTime, endTime; //Change to Delta time or whatever to make this fps independent
    private Vector3 dragStart, dragEnd;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
	public void DragStart()
    {//Get time and position of drag start
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }    
    }

    public void DragEnd()
    {//Launch the ball
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration; //Drag interacts on a 2D plane, but the vertical element translates to the 3D Z plane for purposes of controlling the ball
            Vector3 launchVelocity = new Vector3(launchSpeedX, 0f, launchSpeedZ);
            ball.Launch(launchVelocity);
        }
    }

    public void MoveStart(float amount)
    {
        if (!ball.inPlay)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

}
