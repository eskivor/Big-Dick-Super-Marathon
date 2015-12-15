using UnityEngine;

public class ButtonLoadScene : MonoBehaviour 
{
	[SerializeField] AvailableScenes availableScenes;
	[SerializeField] GameObject prefabSFX;

	public void LoadScene ()
	{
		Instantiate (prefabSFX);
		Application.LoadLevel ((int) availableScenes);
	}
}
