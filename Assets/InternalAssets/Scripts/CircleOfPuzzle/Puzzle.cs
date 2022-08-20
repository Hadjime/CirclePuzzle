using System;
using System.Collections.Generic;
using InternalAssets.Scripts.CircleOfPuzzle.SmallCircle;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InternalAssets.Scripts.CircleOfPuzzle {
	public class Puzzle : MonoBehaviour, IDragHandler, IEndDragHandler
	{
		[SerializeField] private List<SwapCircle> swapCircles;
		[SerializeField] private PuzzleAnimation puzzleAnimation;
		[SerializeField] private float rotationSpeed;
		private Vector3 targetMouse;
		private bool isSwapPlaying;
		
		
		public event Action OnStartRotation;
		public event Action OnEndRotation;

		private void Start()
		{
			swapCircles.ForEach(circle => circle.OnSwapCircleTurnStart += OnSwapCircleTurnStart);
		}

		private void OnDestroy()
		{
			swapCircles.ForEach(circle => circle.OnSwapCircleTurnStart -= OnSwapCircleTurnStart);
		}

		private void Update()
		{
			RotatePuzzle();
		}

		private void OnSwapCircleTurnStart(SwapCircle swapCircle)
		{
			if (isSwapPlaying)
			{
				swapCircle.PlayBlockedVFX();
				return;
			}

			isSwapPlaying = true;
			swapCircle.TurnAroundCircle(onTurnComplete: () => isSwapPlaying = false);
		}
		
		public void ShowOrHidePuzzle() =>
			puzzleAnimation.ShowOrHide();

		public void OnDrag(PointerEventData eventData)
		{
			OnStartRotation?.Invoke();
			targetMouse = eventData.pointerCurrentRaycast.worldPosition;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			OnEndRotation?.Invoke();
		}

		private void RotatePuzzle()
		{
			Vector3 direction = targetMouse - transform.position;
			Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
		}
	}
}