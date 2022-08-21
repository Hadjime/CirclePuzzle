using System;
using System.Collections.Generic;
using UnityEngine;


namespace InternalAssets.Scripts.CircleOfPuzzle
{
	public class BallsGenerator : MonoBehaviour
	{
		[SerializeField] private List<Settings> settings;

	
		public List<Ball.Ball> GenerateBalls()
		{
			List<Ball.Ball> balls = new ();
			settings.ForEach(settings =>
			{
				for (int i = 0; i < settings.amountBalls; i++)
				{
					Ball.Ball ball = Instantiate(settings.ballPrefab, transform);
					balls.Add(ball);
				}
			});

			return balls;
		}

		[Serializable]
		public class Settings
		{
			public Ball.Ball ballPrefab;
			public int amountBalls;
		}
	}
}


