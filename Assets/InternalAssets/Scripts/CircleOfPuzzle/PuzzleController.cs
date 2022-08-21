using System;
using System.Collections.Generic;
using System.Linq;
using InternalAssets.Scripts.CircleOfPuzzle;
using InternalAssets.Scripts.CircleOfPuzzle.Ball;
using InternalAssets.Scripts.CircleOfPuzzle.Nodes;
using InternalAssets.Scripts.Infrastructure.GameStateMachine;
using InternalAssets.Scripts.Infrastructure.GameStateMachine.States;
using InternalAssets.Scripts.Infrastructure.Services.StaticDI;
using InternalAssets.Scripts.Utils.Log;
using UnityEngine;
using Random = UnityEngine.Random;


public class PuzzleController : MonoBehaviour
{
	[SerializeField] private BackgroundHandler backgroundHandler;
	[SerializeField] private Puzzle puzzle;
	[SerializeField] private List<Slot> slots;
	[SerializeField] private SlotTemplate slotTemplate;
	[SerializeField] private BallsGenerator ballsGenerator;
	
	
	public event Action OnPuzzleCompleted;
	

	private void Start()
	{
		//TODO: запеч слоты в редакторе через UnityEditor по группам
		slots = new List<Slot>(GetComponentsInChildren<Slot>());
		
		FillSlots();
		RegisterEvents();
	}

	private void OnDestroy() =>
		UnregisterEvents();

	private void FillSlots()
	{
		// TODO: перенести генерацию в GameFactory
		List<Ball> generatedBalls = ballsGenerator.GenerateBalls();
		
		foreach (Slot slots in slots.TakeWhile(slots => generatedBalls.Count != 0))
		{
			int randomIndex = Random.Range(0, generatedBalls.Count);
			slots.SetBall(generatedBalls[randomIndex]);
			generatedBalls.RemoveAt(randomIndex);
		}
	}

	private void OnBallEndMovement(Ball obj)
	{
		if (!slotTemplate.CheckAllTemplates())
			return;
		
		OnPuzzleCompleted?.Invoke();
		//TODO: хак для перезапуска игры после победы потом подписаться на событие выше
		ServicesLocator.Container.Single<IGameStateMachine>().Enter<BootstrapState>();
	}

	private void OnShowOrHidePuzzle(object sender, EventArgs e)
	{
		puzzle.ShowOrHidePuzzle();
	}

	private void RegisterEvents()
	{
		slots.ForEach(slot =>
		{
			if (slot.Currentball == null)
				return;
			
			slot.Currentball.OnEndMovement += OnBallEndMovement;
		});
		backgroundHandler.OnBackgroundClicked += OnShowOrHidePuzzle;
	}

	private void UnregisterEvents()
	{
		slots.ForEach(slot =>
		{
			if (slot.Currentball == null)
				return;

			slot.Currentball.OnEndMovement -= OnBallEndMovement;
		});
		backgroundHandler.OnBackgroundClicked -= OnShowOrHidePuzzle;
	}

	#region Test

	[ContextMenu("CheckAllTemplates")]
	public void CheckAllTemplates()
	{
		foreach (SlotTemplate.Template template in slotTemplate.Templates)
		{
			if (template == null)
				continue;
			
			bool isTemplateCollected = template.TemplateCollected();
			CustomDebug.Log($"{template.Name} collected = {isTemplateCollected}");
		}
	}
	
	#endregion
}