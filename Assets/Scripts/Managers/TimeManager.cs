using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
	bool gameHasStarted; public bool GameHasStarted {get {return gameHasStarted;} set {gameHasStarted = value;}}

	[SerializeField] Text timeText;

	[SerializeField] string goMessage;
	[SerializeField] string endMessage;
	[SerializeField] int startTime;
	[SerializeField] float gameTime;

	void Start ()
	{
		timeText.text = startTime.ToString ();
		StartCoroutine (TimerStart ());
	}

	IEnumerator TimerStart ()
	{
		for (int i = startTime; i > 0; i --)
		{
			yield return new WaitForSeconds (1);
			startTime --;
			timeText.text = startTime.ToString ();

			if (startTime == 0)
				timeText.text = goMessage;
		}

		yield return new WaitForSeconds (1);
		timeText.text = null;
		StartCoroutine (TimerGame ());
	}

	IEnumerator TimerGame ()
	{
		GameHasStarted = true;
		yield return new WaitForSeconds (gameTime);
		timeText.text = endMessage;
		GameHasStarted = false;
	}
}
