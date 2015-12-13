using UnityEngine;

public class ButtonLoadScene : MonoBehaviour 
{
	[SerializeField] AvailableScenes availableScenes;

	public void LoadScene ()
	{
		Application.LoadLevel ((int) availableScenes);
	}
}
