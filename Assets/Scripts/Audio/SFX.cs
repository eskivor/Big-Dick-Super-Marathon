using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class SFX : MonoBehaviour 
{
	[SerializeField] AudioClip audioclip;
	[SerializeField] float lifeTime;

	AudioSource audioSource;

	public static SFX instance;

	void Awake () 
	{
		if (instance != null && instance != this)
			Destroy(this.gameObject);
		else
			instance = this;

		DontDestroyOnLoad (this.gameObject);
	}

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.PlayOneShot (audioclip);
		Destroy (gameObject, lifeTime);
	}
}
