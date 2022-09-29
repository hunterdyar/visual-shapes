using Unity.VisualScripting;
using UnityEngine;

namespace VisualShapes
{
	//Custom node to send the Event
	[UnitTitle("Send On Camera Pre Render")]
	[UnitCategory("Events\\MyEvents")]
	public class DrawShapesSender : Unit
	{
		[DoNotSerialize] // Mandatory attribute, to make sure we don’t serialize data that should never be serialized.
		[PortLabelHidden] // Hide the port label, as we normally hide the label for default Input and Output triggers.
		public ControlInput inputTrigger { get; private set; }

		[DoNotSerialize] public ValueInput camera;

		[DoNotSerialize]
		[PortLabelHidden] // Hide the port label, as we normally hide the label for default Input and Output triggers.
		public ControlOutput outputTrigger { get; private set; }

		protected override void Definition()
		{
			inputTrigger = ControlInput(nameof(inputTrigger), Trigger);
			camera = ValueInput<Camera>(nameof(camera), Camera.main);
			outputTrigger = ControlOutput(nameof(outputTrigger));
			Succession(inputTrigger, outputTrigger);
		}

		//Send the Event MyCustomEvent with the integer value from the ValueInput port myValueA.
		private ControlOutput Trigger(Flow flow)
		{
			EventBus.Trigger(EventNames.DrawShapesEvent, flow.GetValue<Camera>(camera));
			return outputTrigger;
		}
	}
}