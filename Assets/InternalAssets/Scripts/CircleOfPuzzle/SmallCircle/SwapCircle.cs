using System;
using System.Collections;
using System.Collections.Generic;
using InternalAssets.Scripts.Utils;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InternalAssets.Scripts.CircleOfPuzzle.SmallCircle
{
	public class SwapCircle : MonoBehaviour, IPointerDownHandler
	{
		private const int TURN_TO_Z = 180;
		private const float BLOCKED_DURATION = 0.7f;

		[SerializeField] private List<Transform> points;
		[SerializeField] private float turnSpeed = 1;
		[SerializeField] private GameObject blockedVFX;
		private bool isTurnPlaying;
		private bool isBlockedPlaying;


		public event Action<SwapCircle> OnSwapCircleTurnStart;


		public void OnPointerDown(PointerEventData eventData)
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

		private IEnumerator BlockedVFX()
		{
			if (blockedVFX == null)
				yield break;
			
			blockedVFX.SetActive(true);
			yield return Coroutines.GetWait(BLOCKED_DURATION);
			blockedVFX.SetActive(false);
		}

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
			
			isTurnPlaying = false;
			onTurnComplete?.Invoke();
		}
	}
}
