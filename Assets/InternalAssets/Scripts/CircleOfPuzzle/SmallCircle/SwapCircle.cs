using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using InternalAssets.Scripts.CircleOfPuzzle.Nodes;
using InternalAssets.Scripts.Utils;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InternalAssets.Scripts.CircleOfPuzzle.SmallCircle
{
	public class SwapCircle : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
	{
		private const int TURN_TO_Z = 180;
		private const float BLOCKED_DURATION = 0.7f;

		[SerializeField] private List<Slot> slots;
		[SerializeField] private float turnSpeed = 1;
		[SerializeField] private GameObject blockedVFX;
		private bool isTurnPlaying;
		private bool isBlockedPlaying;


		public event Action<SwapCircle> OnSwapCircleTurnStart;
		public event Action<SwapCircle> OnSwapCircleTurnStop;


		public void OnPointerClick(PointerEventData eventData)
		{
			OnSwapCircleTurnStart?.Invoke(this);
		}

		public void TurnAroundCircle(Action onTurnComplete)
		{
			if (isTurnPlaying)
				return;
			
			StartCoroutine(Turn(onTurnComplete));
		}

		public void PlayBlockedVFX()
		{
			if (isBlockedPlaying)
				return;

			StartCoroutine(BlockedVFX());
		}

		public void OnBeginDrag(PointerEventData eventData) {}

		public void OnDrag(PointerEventData eventData) {}

		private IEnumerator Turn(Action onTurnComplete)
		{
			isTurnPlaying = true;
			
			Vector3 currentAngle = transform.rotation.eulerAngles;
			Vector3 targetAngle = currentAngle + new Vector3(0, 0, TURN_TO_Z);
			float progress = 0;
			while (progress < 1)
			{
				progress += turnSpeed * Time.deltaTime;
				transform.rotation = Quaternion.Lerp(Quaternion.Euler(currentAngle), Quaternion.Euler(targetAngle), progress);
				yield return null;
			}

			transform.rotation = Quaternion.Euler(targetAngle);
			SwapSlots();
			isTurnPlaying = false;
			onTurnComplete?.Invoke();
			OnSwapCircleTurnStop?.Invoke(this);
		}

		private void SwapSlots()
		{
			//TODO: надо подумаь как сделать универсальнее, на случай если в круге будет больше двух слотов
			Slot slot0 = slots[0];
			Slot slot1 = slots[1];
			List<Slot> neighbors_slot0 = slot0.Neighbors.ToList();
			List<Slot> neighbors_slot1 = slot1.Neighbors.ToList();
			
			SwapSlotInCircle(neighbors_slot0, slot1, slot0);
			SwapSlotInCircle(neighbors_slot1, slot0, slot1);

			slot0.SetNeighbors(neighbors_slot1);
			slot1.SetNeighbors(neighbors_slot0);
		}

		private void SwapSlotInCircle(List<Slot> neighbors, Slot oldSlot, Slot newSlot)
		{
			for (var index = 0; index < neighbors.Count; index++)
			{
				if (neighbors[index] == oldSlot)
					neighbors[index] = newSlot;
				else
					neighbors[index].UpdateNeighbor(newSlot, oldSlot);
			}
		}

		private IEnumerator BlockedVFX()
		{
			if (blockedVFX == null)
				yield break;
			
			blockedVFX.SetActive(true);
			yield return Coroutines.GetWait(BLOCKED_DURATION);
			blockedVFX.SetActive(false);
		}
	}
}
