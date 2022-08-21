using System;
using System.Collections.Generic;
using System.Linq;
using InternalAssets.Scripts.CircleOfPuzzle.Nodes;
using InternalAssets.Scripts.Utils.Log;
using UnityEngine;


namespace InternalAssets.Scripts.CircleOfPuzzle
{
	[Serializable]
	public class SlotTemplate
	{
		[SerializeField] private List<Template> templates;

		public List<Template> Templates => templates;

		public bool CheckAllTemplates()
		{
			bool isTemplateCollected = false;
			foreach (Template template in templates.Where(template => template != null))
			{
				isTemplateCollected = template.TemplateCollected();
				if (isTemplateCollected == false)
					break;
			}

			return isTemplateCollected;
		}
		
		
		[Serializable]
		public class Template
		{
			[SerializeField] private string name;
			[SerializeField] private List<Slot> slots;

			public string Name => name;
		
		
			public bool TemplateCollected()
			{
				if (slots == null)
					return false;
			
				Ball.Ball firstBall = slots.FirstOrDefault()?.Currentball;
				if (firstBall == null)
					return false;


				bool isTemplateCollected = !slots.Any(slot => slot.Currentball?.BallType != firstBall.BallType);
				return isTemplateCollected;
			}
		}
	}
}
