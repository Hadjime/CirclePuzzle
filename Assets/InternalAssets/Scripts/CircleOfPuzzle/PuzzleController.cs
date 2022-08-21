using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using InternalAssets.Scripts.CircleOfPuzzle;
using InternalAssets.Scripts.CircleOfPuzzle.Ball;
using InternalAssets.Scripts.CircleOfPuzzle.Nodes;
using UnityEngine;
using Random = UnityEngine.Random;


public class PuzzleController : MonoBehaviour
{
	[SerializeField] private BackgroundHandler backgroundHandler;
	[SerializeField] private Puzzle puzzle;
	[SerializeField] private List<Slot> slots;
	[SerializeField] private BallsGenerator ballsGenerator;
	

	private void Start()
	{
		//TODO: запеч слоты в редакторе через UnityEditor по группам
		slots = new List<Slot>(GetComponentsInChildren<Slot>());
		
		FillSlots();
		RegisterEvents();
	}

	private void OnDestroy() =>
		UnregisterEvents();

	private void FillSlots()
	{
		// TODO: перенести генерацию в GameFactory
		List<Ball> generatedBalls = ballsGenerator.GenerateBalls();
		
		foreach (Slot slots in slots.TakeWhile(slots => generatedBalls.Count != 0))
		{
			int randomIndex = Random.Range(0, generatedBalls.Count);
			slots.SetBall(generatedBalls[randomIndex]);
			generatedBalls.RemoveAt(randomIndex);
		}
	}

	private void OnBallEndMovement(Ball obj)
	{
		//TODO: проверить не собралось ли где 4 в ряд одинаковых шарика
	}

	private void OnShowOrHidePuzzle(object sender, EventArgs e)
	{
		puzzle.ShowOrHidePuzzle();
	}

	private void RegisterEvents()
	{
		slots.ForEach(slot => slot.Currentball.OnEndMovement += OnBallEndMovement);
		backgroundHandler.OnBackgroundClicked += OnShowOrHidePuzzle;
	}

	private void UnregisterEvents()
	{
		backgroundHandler.OnBackgroundClicked -= OnShowOrHidePuzzle;
		slots.ForEach(slot => slot.Currentball.OnEndMovement -= OnBallEndMovement);
	}
}
