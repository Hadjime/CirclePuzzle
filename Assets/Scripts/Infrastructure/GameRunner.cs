using UnityEngine;

namespace Infrastructure
{
	public class GameRunner : MonoBehaviour
	{
		[SerializeField] private GameBootstrapper bootstrapperPrefab;

		private void Awake()
		{
			Application.targetFrameRate = 30;

			var bootstrapper = FindObjectOfType<GameBootstrapper>();

			if (bootstrapper == null)
				Instantiate(bootstrapperPrefab);
		}
	}
}
