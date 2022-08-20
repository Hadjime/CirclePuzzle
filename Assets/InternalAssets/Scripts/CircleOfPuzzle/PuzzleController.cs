using System;
using System.Collections;
using System.Collections.Generic;
using InternalAssets.Scripts.CircleOfPuzzle;
using UnityEngine;


public class PuzzleController : MonoBehaviour
{
	[SerializeField] private BackgroundHandler backgroundHandler;
	[SerializeField] private Puzzle puzzle;
	

	private void Start()
	{
		backgroundHandler.OnBackgroundClicked += OnShowOrHidePuzzle;
	}

	private void OnDestroy()
	{
		backgroundHandler.OnBackgroundClicked -= OnShowOrHidePuzzle;
	}

	private void OnShowOrHidePuzzle(object sender, EventArgs e)
	{
		puzzle.ShowOrHidePuzzle();
	}

	
}
