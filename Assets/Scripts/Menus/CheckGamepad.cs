using UnityEngine;

public class CheckGamepad : MonoBehaviour 
{
	public static CheckGamepad instance;

	public bool isThereAGamePad;
	public bool dontDestroyIsActive;

	void Awake ()
	{
		if (dontDestroyIsActive)
		{
			if (instance == null)
				DontDestroyOnLoad (gameObject);
			else if (instance != this)
				Destroy (gameObject);
		}
	}

	void Update ()
	{
		if (Input.GetJoystickNames()[0] != null)
		{
			if (Input.GetJoystickNames()[0].Length != 0)
				ThereIsAGamePad ();
			else
				ThereIsntAGamePad ();
		}
		else
			ThereIsntAGamePad ();
	}

	private void ThereIsAGamePad ()
	{
		isThereAGamePad = true;
	}

	private void ThereIsntAGamePad ()
	{
		isThereAGamePad = false;
	}
}
