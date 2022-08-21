using System.Collections.Generic;
using UnityEngine;


namespace InternalAssets.Scripts.CircleOfPuzzle.Nodes
{
	public class Slot : MonoBehaviour
	{
		[SerializeField] private List<Slot> neighbors;
		[SerializeField] private Ball.Ball currentball;
		[SerializeField] private bool isEmpty = true;


		public List<Slot> Neighbors => neighbors;
		public bool IsEmpty => isEmpty;
		public Ball.Ball Currentball => currentball;


		public void SetNeighbors(List<Slot> newNeighbors)
		{
			neighbors.Clear();
			neighbors.AddRange(newNeighbors);
		}
		
		public Slot GetNearestSlot(Vector3 position){
			Slot nearestSlot = null;
			float minDistance = float.MaxValue;
			foreach(Slot slot in neighbors)
			{
				float distance = Vector3.Distance(slot.transform.position, position);
				if(distance < minDistance){
					minDistance = distance;
					nearestSlot = slot;
				}
			}
			return nearestSlot;
		}

		public void SetBall(Ball.Ball newBall){
			isEmpty = false;
			currentball = newBall;
			newBall.transform.SetParent(transform);
			newBall.transform.localPosition = Vector3.zero;
		}
		
		public void ClearSlot()
		{
			isEmpty = true;
			currentball = null;
		}

		public void UpdateNeighbor(Slot oldSlot, Slot newSlot)
		{
			neighbors.Remove(oldSlot);
			neighbors.Add(newSlot);
		}
	}
}
