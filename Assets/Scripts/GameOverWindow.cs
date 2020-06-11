using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour {

	private static GameOverWindow instance;

	private void Awake()
	{
		instance = this;
		Hide ();
	}

	private void Show(bool isNewHighscore)
	{
		gameObject.SetActive (true);

		transform.Find ("highscoreText").GetComponent<Text> ().text = "HIGHSCORE " + Score.GetHighscore ().ToString ();
		transform.Find ("scoreText").GetComponent<Text> ().text =  Score.GetScore ().ToString ();
		transform.Find ("newHighscoreText").gameObject.SetActive (isNewHighscore);
	}
	private void Hide()
	{
		gameObject.SetActive (false);
	}
	public static void ShowStatic(bool isNewHighscore)
	{
		instance.Show (isNewHighscore);
	}

	public void WhenBtnClicked()
	{
		SoundManager.PlaySound (SoundManager.Sound.ButtonClick);
		Loader.Load (Loader.Scene.MainMenu);
	}

}
