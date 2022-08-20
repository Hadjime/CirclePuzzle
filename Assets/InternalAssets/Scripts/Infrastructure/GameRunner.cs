using UnityEngine;


namespace InternalAssets.Scripts.Infrastructure
{
	public class GameRunner : MonoBehaviour
	{
		[SerializeField] private GameBootstrapper bootstrapperPrefab;

		private void Awake()
		{
			Application.targetFrameRate = 30;

			var bootstrapper = FindObjectOfType<GameBootstrapper>();

			if (bootstrapper == null)
			{
				GameBootstrapper gameBootstrapper = Instantiate(bootstrapperPrefab);
				gameBootstrapper.name = bootstrapperPrefab.name;
			}
		}
	}
}
