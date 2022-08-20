using System;
using System.Collections;
using UnityEngine;


namespace InternalAssets.Scripts.CircleOfPuzzle
{
	public class PuzzleAnimation : MonoBehaviour
	{
		[SerializeField] Puzzle puzzle;
		[SerializeField] private float animationSpeed;
		[SerializeField] private AnimationCurve animationCurve;
		private bool isPuzzleShown;
		private bool isAnimationPlaying;
		private float progress;
		

		private void OnValidate()
		{
			puzzle = GetComponent<Puzzle>();
		}

		private void Start()
		{
			isPuzzleShown = puzzle.gameObject.activeSelf;
		}

		public void ShowOrHide()
		{
			StartCoroutine(PlayAnimation(!isPuzzleShown));
		}
	
		private IEnumerator PlayAnimation(bool isShow)
		{
			if (isAnimationPlaying)
				yield break;

			isAnimationPlaying = true;
			progress = 0;

			Vector3 startScale = Vector3.zero;
			Vector3 endScale = Vector3.one;
			if (isShow)
				(startScale, endScale) = (endScale, startScale);

			while (progress <= 1)
			{
				progress += Time.deltaTime * animationSpeed;
				puzzle.transform.localScale = Vector3.Lerp(startScale, endScale * animationCurve.Evaluate(progress), progress);
				yield return null;
			}

			isPuzzleShown = isShow;
			isAnimationPlaying = false;
		}
	}
}
