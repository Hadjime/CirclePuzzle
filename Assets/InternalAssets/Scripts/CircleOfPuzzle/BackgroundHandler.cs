using System;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InternalAssets.Scripts.CircleOfPuzzle
{
	public class BackgroundHandler : MonoBehaviour, IPointerDownHandler
	{
		public event EventHandler OnBackgroundClicked;


		public void OnPointerDown(PointerEventData eventData) =>
			OnBackgroundClicked?.Invoke(this, EventArgs.Empty);
	}
}