using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class DickBehaviour : MonoBehaviour 
{
	[SerializeField] Text inputText;

	[SerializeField] AudioClip leftSFX;
	[SerializeField] AudioClip rightSFX;

	[SerializeField] [Multiline] string inputLeft;
	[SerializeField] [Multiline] string inputRight;

	[SerializeField] float scoreFactor;
	[SerializeField] float growingSpeed;
	[SerializeField] int dickID;
	[SerializeField] int axisValueToGet;

	TimeManager timeManager;
	AudioSource audioSource;
	Animator animator;

	Transform dickHead;
	Transform dickBody;
	Transform dickBase;
	Transform dickCover;
	Transform hand;

	float dickBodyDefaultScale;
	float dickBodyDefaultPosition;
	float dickHeadDefaultPosition;
	float dickCoverDefaultScale;

	public float score;

	void Start ()
	{
		dickHead = GetComponentInChildren<DickHead>().transform;
		dickBody = GetComponentInChildren<DickBody>().transform;
		dickBase = GetComponentInChildren<DickBase>().transform;
		dickCover = GetComponentInChildren<DickCover>().transform;
		hand = GetComponentInChildren<Hand>().transform;
		animator = GetComponentInChildren<Animator>();

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

		score = (dickHead.position.x + 4f) * scoreFactor + 15f;
	}

	private void GrowDick ()
	{
		InvertAxisToGet ();
		GrowDickBody ();
		GrowDickHead ();
	}

	private void InvertAxisToGet ()
	{
		if (axisValueToGet == -1)
			GoLeft ();
		
		else if (axisValueToGet == 1)
			GoRight ();
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

	private void GoLeft ()
	{
		axisValueToGet = 1;
		audioSource.PlayOneShot (leftSFX);
		GoLeftHand ();
		GoLeftDickCover ();
		inputText.text = inputRight;
	}

	private void GoRight ()
	{
		axisValueToGet = -1;
		audioSource.PlayOneShot (rightSFX);
		GoRightHand ();
		GoRightDickCover ();
		inputText.text = inputLeft;
	}

	private void GoLeftHand ()
	{
		animator.SetTrigger ("Go To Left");
	}

	private void GoRightHand ()
	{
		animator.SetTrigger ("Go To Right");
	}

	private void GoLeftDickCover ()
	{
		//a tester
		dickCover.localScale = new Vector3 (dickBody.localScale.x, 
											dickCoverDefaultScale,
											transform.localScale.z);

		//a tester
		dickCover.position = new Vector3 (dickBody.position.x,
										  dickCover.position.y, 
										  transform.position.z);
	}

	private void GoRightDickCover ()
	{
		dickCover.localScale = new Vector3 (dickBody.localScale.x + dickHead.localScale.x, 
			dickCoverDefaultScale,
			transform.localScale.z);

		dickCover.position = new Vector3 (dickBody.position.x + (dickHead.localScale.x / 2),
			dickCover.position.y, 
			transform.position.z);
	}
}
