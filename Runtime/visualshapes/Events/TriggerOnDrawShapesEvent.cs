using Shapes;
using Unity.VisualScripting;
using UnityEngine;

namespace VisualShapes
{
	public class TriggerOnDrawShapesEvent : ImmediateModeShapeDrawer
	{
		public override void DrawShapes(Camera cam)
		{
			EventBus.Trigger(EventNames.DrawShapesEvent,cam);
			base.DrawShapes(cam);
		}
	}
}