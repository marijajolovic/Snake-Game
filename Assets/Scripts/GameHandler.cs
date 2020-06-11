using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour {

	private static GameHandler instance;

	public Snake snake;
	private LevelGrid levelGrid;

	private void Awake()
	{
		instance = this;
		Score.InitializeStatic ();
		GameHandler.ResumeGame ();
	}

	private void Start () {
		
		Debug.Log("GameHandler.Startic");

		levelGrid = new LevelGrid (20, 20);
		snake.Setup(levelGrid);
		levelGrid.Setup(snake);

	}
		
	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (IsGamePaused ())
				GameHandler.ResumeGame ();
			else
				GameHandler.PauseGame ();
		}
	}
		
	public static void SnakeDied()
	{
		bool isNewHighscore = Score.TrySetNewHighscore ();
		GameOverWindow.ShowStatic (isNewHighscore);
		ScoreWindow.HideStatic ();

	}

	public static void ResumeGame()
	{
		PauseWindow.HideStatic ();
		Time.timeScale = 1f;
	}

	public static void PauseGame()
	{
		PauseWindow.ShowStatic ();
		Time.timeScale = 0f;
	}
	public static bool IsGamePaused()
	{
		return Time.timeScale == 0f;
	}
}
