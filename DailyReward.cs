using UnityEngine;
using UnityEngine.UI;
using System;

public class DailyReward : MonoBehaviour
{
	public int secondsToWait = 10;
	public bool canGetReward = true;
	[Space]
	public Button rewardButton;
	public Text displayText;

	private ulong lastRewarded;
	private ulong difference;
	private ulong milisec;
	private float milisecToWait;
	private float secondsLeft;

	private void Start()
	{
		//Get the <LastRewarded> time.
		string lastSavedTime = PlayerPrefs.GetString("LastRewarded");
		lastRewarded = ulong.Parse(lastSavedTime.ToString());

		//Match the variables.
		if(!CanGetReward())
			canGetReward = false;

		else if(CanGetReward())
			canGetReward = true;
	}

	private void Update()
	{
		//Matching the different variables.
		canGetReward = CanGetReward();

		//Our reward is ready.
		if(canGetReward)
		{
			//Enable the button, and set the display text to <readyText>.
			displayText.text = "Claim Reward!";
			rewardButton.interactable = true;
		}

		//We cannot get reward at the moment.
		else if(!canGetReward)
		{
			//Diasble the button, and create an empty string.
			rewardButton.interactable = false;
			string timerText = "";

			//Displaying Hours.
			timerText += ((int)secondsLeft / 3600).ToString("00") + "h ";
			secondsLeft -= ((int)secondsLeft / 3600) * 3600;

			//Displaying Minutes.
			timerText += ((int)secondsLeft / 60).ToString("00") + "m ";

			//Displaying Seconds.
			timerText += (secondsLeft % 60).ToString("00") + "s";

			//Refresh the display text.
			displayText.text = timerText;
		}
	}

	public void GetReward()
	{
		//If we can get the reward...
		if(canGetReward)
		{
			//Set <LastRewarded> to the current time.
			lastRewarded = (ulong)DateTime.Now.Ticks;
			PlayerPrefs.SetString("LastRewarded", lastRewarded.ToString());

			//We just got the reward, so we can't get it again.
			canGetReward = false;

			//Reward can be given to the player here.
			Debug.Log("We got our 'Daily' Reward!");
		}
	}

	private bool CanGetReward()
	{
		//Getting the difference between the current time and the <LastRewarded> time.
		difference = ((ulong)DateTime.Now.Ticks - lastRewarded);
		milisec = difference / TimeSpan.TicksPerMillisecond;

		//Since the input wait time is in seconds, we have to multiply by 1000 to get it in miliseconds.
		milisecToWait = secondsToWait * 1000;
		secondsLeft = (float)(milisecToWait - milisec) / 1000f;

		//Check if we can get the reward.
		if(secondsLeft < 0)
			return true;

		else return false;
	}
}