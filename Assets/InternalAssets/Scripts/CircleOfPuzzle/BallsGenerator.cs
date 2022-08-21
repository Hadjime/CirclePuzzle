using System;
using System.Collections;
using System.Collections.Generic;
using InternalAssets.Scripts.CircleOfPuzzle.Ball;
using Unity.VisualScripting;
using UnityEngine;

public class BallsGenerator : MonoBehaviour
{
	[SerializeField] private List<Settings> settings;

	
	public List<Ball> GenerateBalls()
	{
		List<Ball> balls = new ();
		settings.ForEach(settings =>
		{
			for (int i = 0; i < settings.amountBalls; i++)
			{
				Ball ball = Instantiate(settings.ballPrefab, transform);
				balls.Add(ball);
			}
		});

		return balls;
	}

	[Serializable]
	public class Settings
	{
		public Ball ballPrefab;
		public int amountBalls;
	}
}


