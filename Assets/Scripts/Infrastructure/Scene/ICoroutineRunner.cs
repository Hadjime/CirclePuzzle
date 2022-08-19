using System.Collections;
using UnityEngine;

namespace Infrastructure.Scene
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator coroutine);
	}
}
