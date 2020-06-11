using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

	public void WhenClicked()
	{
		
		SoundManager.PlaySound (SoundManager.Sound.ButtonClick);
		Loader.Load(Loader.Scene.GameScene);
	}
}
