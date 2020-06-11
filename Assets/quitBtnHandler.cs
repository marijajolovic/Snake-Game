using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitBtnHandler : MonoBehaviour {

	public void WhenClicked()
	{
		SoundManager.PlaySound (SoundManager.Sound.ButtonClick);
		Application.Quit ();
	}
}
