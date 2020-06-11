using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour {

	private enum Sub
	{
		Main,
		HowToPlay,
	}
	private void Awake()
	{
		transform.Find ("MainSub").GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;
		//transform.Find ("HowToPLaySub").GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;

		ShowSub (Sub.Main);
	}
	public void WhenHTPBtnClicked()
	{
		SoundManager.PlaySound (SoundManager.Sound.ButtonClick);
		ShowSub (Sub.HowToPlay);
	}
	public void WhenOKBtnClicked()
	{
		SoundManager.PlaySound (SoundManager.Sound.ButtonClick);
		ShowSub (Sub.Main);
	}

	private void ShowSub(Sub sub)
	{
		transform.Find ("MainSub").gameObject.SetActive (false);
		transform.Find ("HowToPLaySub").gameObject.SetActive (false);

		switch (sub) {
		case Sub.Main:
			transform.Find ("MainSub").gameObject.SetActive (true);
			break;
		case Sub.HowToPlay:
			transform.Find ("HowToPLaySub").gameObject.SetActive (true);
			break;
		}
	}
}
