using System;
using System.Collections.Generic;
using InternalAssets.Scripts.Utils.Log;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InternalAssets.Scripts.CircleOfPuzzle {
	public class PuzzleMovementHandler : MonoBehaviour, IDragHandler, IEndDragHandler
	{
		[SerializeField] private PuzzleAnimation puzzleAnimation;
		[SerializeField] private float rotationSpeed;
		private Vector3 targetMouse;

		public PuzzleAnimation PuzzleAnimation => puzzleAnimation;
		
		public event EventHandler OnStartRotation;
		public event EventHandler OnEndRotation;

		private void Update()
		{
			RotatePuzzle();
		}

		private void RotatePuzzle()
		{
			Vector3 direction = targetMouse - transform.position;
			Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
		}

		public void OnDrag(PointerEventData eventData)
		{
			OnStartRotation?.Invoke(this, EventArgs.Empty);
			targetMouse = eventData.pointerCurrentRaycast.worldPosition;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			OnEndRotation?.Invoke(this, EventArgs.Empty);
		}
	}
}