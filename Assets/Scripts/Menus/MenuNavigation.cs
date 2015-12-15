using UnityEngine;

public class MenuNavigation : MonoBehaviour 
{
	[SerializeField] GameObject audioclipSFX;

	public void ButtonPointerEnter ()
	{
		Instantiate (audioclipSFX);
	}
}
