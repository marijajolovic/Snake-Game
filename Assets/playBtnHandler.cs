using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playBtnHandler : MonoBehaviour {

	public void WhenClicked()
	{
		SoundManager.PlaySound (SoundManager.Sound.ButtonClick);
		Loader.Load (Loader.Scene.GameScene);
	}
	

}
