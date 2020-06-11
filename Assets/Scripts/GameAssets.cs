using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets i;

    private void Awake() 
	{
        i = this;
    }

    public Sprite snakeHeadSprite;
	public Sprite snakeBodySprite;
	public Sprite foodSprite;
	public Sprite goldFoodSprite;

	public SoundAudioClip[] soundAudioClipArray;

	[Serializable]
	public class SoundAudioClip{
		public SoundManager.Sound sound;
		public AudioClip audioClip;
	}

	public  void On()
	{
		SoundManager.PlaySound (SoundManager.Sound.ButtonOver);
	}

}
