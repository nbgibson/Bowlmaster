using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private GameManager gameManager;
    

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}

    public void Reset()
    {
        lastSettledCount = 10;
    }

    // Update is called once per frame
    void Update () {
        standingDisplay.text = CountStanding().ToString();


        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    private void UpdateStandingCountAndSettle()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);
        lastStandingCount = -1; //Pins settled, ball not back in box (a new frame)
        ballOutOfPlay = false;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }
}
