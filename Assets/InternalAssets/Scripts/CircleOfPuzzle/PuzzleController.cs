using System.Collections.Generic;
using UnityEngine;


public class CirclePuzzleController : MonoBehaviour
{
	
	private IEnumerator<> PlayAnimation()
	{
		if (isAnimationPlaying)
			yield break;

		isAnimationPlaying = true;
		progress = 1;
		Vector3 startScale = Vector3.zero;
		Vector3 endScale = Vector3.one;

		if (isPuzzleShown)
		{
			(startScale, endScale) = (endScale, startScale);
		}

		while (progress > 0)
		{
			progress -= Time.deltaTime;
			circlePuzzleController.transform.localScale = Vector3.Lerp(startScale, endScale, progress);
			yield return null;
		}

		isPuzzleShown = !isPuzzleShown;
		isAnimationPlaying = false;
	}
}
