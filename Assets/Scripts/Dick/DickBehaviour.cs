using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class DickBehaviour : MonoBehaviour 
{
	[SerializeField] float growingSpeed;
	[SerializeField] int dickID;
	[SerializeField] int axisValueToGet;

	TimeManager timeManager;

	AudioSource audioSource;
	AudioClip leftSFX;
	AudioClip rightSFX;

	Transform dickHead;
	Transform dickBody;
	Transform dickBase;
	Transform dickCover;

	float dickBodyDefaultScale;
	float dickBodyDefaultPosition;
	float dickHeadDefaultPosition;
	float dickCoverDefaultScale;

	void Start ()
	{
		dickHead = GetComponentInChildren<DickHead>().transform;
		dickBody = GetComponentInChildren<DickBody>().transform;
		dickBase = GetComponentInChildren<DickBase>().transform;
		dickCover = GetComponentInChildren<DickCover>().transform;

		dickBodyDefaultScale = dickBody.localScale.x;
		dickBodyDefaultPosition = dickBody.position.x;
		dickHeadDefaultPosition = dickBody.position.x;

		dickCoverDefaultScale = dickCover.localScale.y;

		timeManager = FindObjectOfType<TimeManager>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		if (timeManager.GameHasStarted && Input.GetAxisRaw ("Horizontal 0" + dickID) == axisValueToGet)
				GrowDick ();
	}

	private void GrowDick ()
	{
		InvertAxisToGet ();
		GrowDickBody ();
		GrowDickHead ();
		GrowDickCover ();
	}

	private void InvertAxisToGet ()
	{
		if (axisValueToGet == -1)
		{
			axisValueToGet = 1;
			audioSource.PlayOneShot (leftSFX);
		}
		else if (axisValueToGet == 1)
		{
			axisValueToGet = -1;
			audioSource.PlayOneShot (rightSFX);
		}
	}
		
	private void GrowDickBody ()
	{
		dickBody.localScale = new Vector3 ((dickBody.localScale.x / dickBodyDefaultScale) * growingSpeed, 
											transform.localScale.y, 
											transform.localScale.z);

		dickBody.position = new Vector3 (dickBodyDefaultPosition + ((dickBody.localScale.x - dickBodyDefaultScale) / 2),
										 transform.position.y, 
										 transform.position.z);
	}

	private void GrowDickHead ()
	{
		dickHead.position = new Vector3 (dickHeadDefaultPosition + dickBody.localScale.x, 
										 transform.position.y, 
										 transform.position.z);	
	}

	private void GrowDickCover ()
	{
		dickCover.localScale = new Vector3 (dickBody.localScale.x + dickHead.localScale.x, 
											dickCoverDefaultScale,
											transform.localScale.z);

		dickCover.position = new Vector3 (dickBody.position.x + (dickHead.localScale.x / 2),
										  dickCover.position.y, 
										  transform.position.z);
	}
}
