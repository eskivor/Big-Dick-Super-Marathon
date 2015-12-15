using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour 
{
	bool gameHasStarted; public bool GameHasStarted {get {return gameHasStarted;} set {gameHasStarted = value;}}

	[SerializeField] DickBehaviour dickBehaviourPlayer01;
	[SerializeField] DickBehaviour dickBehaviourPlayer02;
	[SerializeField] DickBehaviour dickBehaviourPlayer03;
	[SerializeField] DickBehaviour dickBehaviourPlayer04;

	[SerializeField] AvailableScenes dickScene;
	[SerializeField] AvailableScenes menuScene;

	[SerializeField] AudioClip validation;
	[SerializeField] AudioClip annulation;

	[SerializeField] GameObject backgroundMeter;
	[SerializeField] GameObject textMeter;

	[SerializeField] GameObject victoryInterface;
	[SerializeField] Text timeText;

	[SerializeField] Text textScorePlayer01;
	[SerializeField] Text textScorePlayer02;
	[SerializeField] Text textScorePlayer03;
	[SerializeField] Text textScorePlayer04;

	[SerializeField] Text textLeaderboardPlayer01;
	[SerializeField] Text textLeaderboardPlayer02;
	[SerializeField] Text textLeaderboardPlayer03;
	[SerializeField] Text textLeaderboardPlayer04;

	[SerializeField] string goMessage;
	[SerializeField] string endMessage;
	[SerializeField] int startTime;
	[SerializeField] float gameTime;

	List<float> listScores;

	float scorePlayer01;
	float scorePlayer02;
	float scorePlayer03;
	float scorePlayer04;

	void Start ()
	{
		backgroundMeter.SetActive (false);
		textMeter.SetActive (false);
		listScores = new List<float>();
		victoryInterface.SetActive (false);
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
		backgroundMeter.SetActive (true);
		textMeter.SetActive (true);
		GameHasStarted = true;
		yield return new WaitForSeconds (gameTime);
		timeText.text = endMessage;
		GameHasStarted = false;
		SetScore ();
		victoryInterface.SetActive (true);
		backgroundMeter.SetActive (false);
		textMeter.SetActive (false);
	}

	private void SetScore ()
	{
		//dickBehaviourPlayer01
		scorePlayer01 = dickBehaviourPlayer01.score;
		scorePlayer02 = dickBehaviourPlayer02.score;
		scorePlayer03 = dickBehaviourPlayer03.score;
		scorePlayer04 = dickBehaviourPlayer04.score;

		textScorePlayer01.text = scorePlayer01.ToString ("000.00") + " cm";
		textScorePlayer02.text = scorePlayer02.ToString ("000.00") + " cm";
		textScorePlayer03.text = scorePlayer03.ToString ("000.00") + " cm";
		textScorePlayer04.text = scorePlayer04.ToString ("000.00") + " cm";

		listScores.Add (scorePlayer01);
		listScores.Add (scorePlayer02);
		listScores.Add (scorePlayer03);
		listScores.Add (scorePlayer04);

		listScores.Sort ();

		if (listScores[0] == scorePlayer01)
			textLeaderboardPlayer01.text = "4th";

		if (listScores[0] == scorePlayer02)
			textLeaderboardPlayer02.text = "4th";

		if (listScores[0] == scorePlayer03)
			textLeaderboardPlayer03.text = "4th";

		if (listScores[0] == scorePlayer04)
			textLeaderboardPlayer04.text = "4th";

		if (listScores[1] == scorePlayer01)
			textLeaderboardPlayer01.text = "3rd";

		if (listScores[1] == scorePlayer02)
			textLeaderboardPlayer02.text = "3rd";

		if (listScores[1] == scorePlayer03)
			textLeaderboardPlayer03.text = "3rd";

		if (listScores[1] == scorePlayer04)
			textLeaderboardPlayer04.text = "3rd";

		if (listScores[2] == scorePlayer01)
			textLeaderboardPlayer01.text = "2nd";

		if (listScores[2] == scorePlayer02)
			textLeaderboardPlayer02.text = "2nd";

		if (listScores[2] == scorePlayer03)
			textLeaderboardPlayer03.text = "2nd";

		if (listScores[2] == scorePlayer04)
			textLeaderboardPlayer04.text = "2nd";

		if (listScores[3] == scorePlayer01)
			textLeaderboardPlayer01.text = "1st";

		if (listScores[3] == scorePlayer02)
			textLeaderboardPlayer02.text = "1st";

		if (listScores[3] == scorePlayer03)
			textLeaderboardPlayer03.text = "1st";

		if (listScores[3] == scorePlayer04)
			textLeaderboardPlayer04.text = "1st";
	}

	public void Replay ()
	{
		Instantiate (validation);
		Application.LoadLevel ((int) dickScene);
	}

	public void Menu ()
	{
		Instantiate (annulation);
		Application.LoadLevel ((int) menuScene);
	}
}
