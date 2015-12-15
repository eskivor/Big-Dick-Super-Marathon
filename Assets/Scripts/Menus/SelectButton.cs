using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoSelect : MonoBehaviour 
{
	/*Button button;

	void Start ()
	{
		button = GetComponent<Button>();
		button.Select ();
	}*/

	private CheckGamepad checkGamepad;
	private bool hasNotSelectedButton;

	void Start ()
	{
		checkGamepad = FindObjectOfType<CheckGamepad>();
	}

	void Update ()
	{
		if (checkGamepad.isThereAGamePad)
		{
			if (!hasNotSelectedButton)
				SelectButton ();
		}
		else
			ResetSelection ();
	}

	public void SelectButton ()
	{
		GetComponent<Button>().Select ();
		hasNotSelectedButton = true;
	}

	public void ResetSelection ()
	{
		hasNotSelectedButton = false;
	}
}
