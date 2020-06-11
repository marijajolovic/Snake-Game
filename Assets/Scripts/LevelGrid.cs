using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelGrid {

	private Vector2 foodGridPosition;
	private Vector2 goldFoodGridPosition;
	public int nBody = 0;
	public GameObject foodGameObject;
	public GameObject goldFoodGameObject;
	private int width;
	private int height;
	private Snake snake;
	public int nFood = 0;
	//public int sn=0;

	public LevelGrid(int width, int height)
	{
		this.width = width;
		this.height = height;
	}

	public void Setup(Snake snake)
	{
		this.snake = snake;

		SpawnFood ();
	}

	private void SpawnGoldFood()
	{
		List<float> xOsa= new List<float>();
		List<float> yOsa= new List<float>();
		List<Vector2> cela = snake.GetFullSnakeGridPositionList ();
		foreach (var z in cela) {
			xOsa.Add (z.x);
			yOsa.Add (z.y);
		}

		List<bool> haveList = new List<bool> ();
		for(int i=0;i<cela.Count;i++) haveList.Add(false);
		bool ist=true;

		do {
			goldFoodGridPosition = new Vector2 (Random.Range (1, width), Random.Range (1, height));

			for (int i = 0; i < cela.Count; i++) {
				if (Mathf.Sqrt (Mathf.Pow ((xOsa [i] - goldFoodGridPosition.x), 2) + Mathf.Pow ((yOsa [i] - goldFoodGridPosition.y), 2)) > 3)
					haveList [i] = true;
			}

			foreach (var s in haveList) {
				if (s == false)
					ist = false;
			}

		} while(snake.GetFullSnakeGridPositionList ().IndexOf (goldFoodGridPosition) != -1 && ist != false);

		goldFoodGameObject = new GameObject ("GoldFood", typeof(SpriteRenderer));
		goldFoodGameObject.GetComponent<SpriteRenderer> ().sprite = GameAssets.i.goldFoodSprite;
		goldFoodGameObject.transform.position = new Vector3 (goldFoodGridPosition.x, goldFoodGridPosition.y);

		goldFoodGameObject.transform.localScale = new Vector3 (1, 1, 0);
		nFood=0;

	}

	private void SpawnFood()
	{
		List<float> xOsa= new List<float>();
		List<float> yOsa= new List<float>();
		List<Vector2> cela = snake.GetFullSnakeGridPositionList ();
		foreach (var z in cela) {
			xOsa.Add (z.x);
			yOsa.Add (z.y);
		}

		List<bool> haveList = new List<bool> ();
		for(int i=0;i<cela.Count;i++) haveList.Add(false);
		bool ist=true;

			do {
				foodGridPosition = new Vector2 (Random.Range (1, width), Random.Range (1, height));

				for (int i = 0; i < cela.Count; i++) {
					if (Mathf.Sqrt (Mathf.Pow ((xOsa [i] - foodGridPosition.x), 2) + Mathf.Pow ((yOsa [i] - foodGridPosition.y), 2)) > 3)
						haveList [i] = true;
				}

				foreach (var s in haveList) {
					if (s == false)
						ist = false;
				}
			
			} while(snake.GetFullSnakeGridPositionList ().IndexOf (foodGridPosition) != -1 && ist != false);

			foodGameObject = new GameObject ("Food", typeof(SpriteRenderer));
			foodGameObject.GetComponent<SpriteRenderer> ().sprite = GameAssets.i.foodSprite;
			foodGameObject.transform.position = new Vector3 (foodGridPosition.x, foodGridPosition.y);

		foodGameObject.transform.localScale = new Vector3 (1, 1, 0);
		nFood++;
	}

	public bool TrySnakeEatFood(Vector2 snakeGridPosition)
	{
		if ((snakeGridPosition == foodGridPosition || (Mathf.Sqrt (Mathf.Pow ((snakeGridPosition.x - foodGridPosition.x), 2) + Mathf.Pow ((snakeGridPosition.y - foodGridPosition.y), 2)) < 1))) {
				Object.Destroy (foodGameObject);
			if (nFood == 4)
				SpawnGoldFood ();
			else
				SpawnFood ();
				Score.AddScore ();
				nBody = 1;
				return true;

			} 
		else return false;
		
	}
		
	public bool TrySnakeEatGoldFood(Vector2 snakeGridPosition)
		{
		if (snakeGridPosition == goldFoodGridPosition || (Mathf.Sqrt (Mathf.Pow ((snakeGridPosition.x - goldFoodGridPosition.x), 2) + Mathf.Pow ((snakeGridPosition.y - goldFoodGridPosition.y), 2)) < 1)) {
			Object.Destroy (goldFoodGameObject);
			SpawnFood ();
			Score.AddGoldScore ();
			snake.gridMoveTimerMax = snake.gridMoveTimerMax /1.15f;
			nBody = 1;
			return true;
		} else
			return false;
		}
		

	public Vector2 ValidateGridPosition(Vector2 gridPosition)
	{
		if (gridPosition.x < 0.5f) gridPosition.x = width - 0.5f; 	
		if (gridPosition.x > width - 0.5f) gridPosition.x = 0.5f;
		if (gridPosition.y < 0.5f) gridPosition.y = height - 0.5f;
		if (gridPosition.y > height-0.5f) gridPosition.y = 0.5f;

		return gridPosition;
	}

}
