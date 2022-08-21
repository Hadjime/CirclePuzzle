using System;
using System.Collections;
using InternalAssets.Scripts.CircleOfPuzzle.Nodes;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InternalAssets.Scripts.CircleOfPuzzle.Ball
{
	public class Ball : MonoBehaviour, IDragHandler, IBeginDragHandler
	{
		[SerializeField] private Slot ownSlot;
		[SerializeField] private float movementSpeed = 5f;
		[SerializeField] private BallType ballType;
		private Transform _transform;
		private bool isMoving;


		public BallType BallType => ballType;
		public event Action<Ball> OnStartMovement;
		public event Action<Ball> OnEndMovement;

		private void Start()
		{
			ownSlot = GetComponentInParent<Slot>();
			_transform = transform;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (isMoving)
				return;

			Vector3 normalizedDirection = (eventData.pointerCurrentRaycast.worldPosition - eventData.pointerPressRaycast.worldPosition).normalized;
			Slot nearestSlot = ownSlot.GetNearestSlot(ownSlot.transform.position + normalizedDirection);
			if (nearestSlot.IsEmpty)
			{
				StartCoroutine(MoveBall(nearestSlot));
			}
			Debug.DrawRay(ownSlot.transform.position, normalizedDirection, Color.green, 1);
		}

		public void OnDrag(PointerEventData eventData) {}

		private IEnumerator MoveBall(Slot nearestSlot)
		{
			isMoving = true;
			OnStartMovement?.Invoke(this);
			
			float progress = 0;
			
			while (progress < 1)
			{
				progress += movementSpeed * Time.deltaTime;
				_transform.position = Vector3.Lerp(ownSlot.transform.position, nearestSlot.transform.position, progress);
				yield return null;
			}

			_transform.position = nearestSlot.transform.position;

			ownSlot.ClearSlot();
			ownSlot = nearestSlot;
			ownSlot.SetBall(this);
			isMoving = false;
			OnEndMovement?.Invoke(this);
		}
	}
}
