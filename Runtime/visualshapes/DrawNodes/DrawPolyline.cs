using System.Collections;
using System.Collections.Generic;
using Shapes;
using Unity.VisualScripting;
using UnityEngine;

[UnitCategory("Shapes")]
public class DrawPolyline : Unit
{
	[DoNotSerialize] // No need to serialize ports.
	public ControlInput inputTrigger; //Adding the ControlInput port variable

	[DoNotSerialize] // No need to serialize ports.
	public ControlOutput outputTrigger; //Adding the ControlOutput port variable.

	[DoNotSerialize] public ValueInput points;
	
	[DoNotSerialize] public ValueInput thickness;
	
	[DoNotSerialize] public ValueInput color;
	
	[DoNotSerialize] public ValueInput closed;

	[DoNotSerialize] public ValueInput joins;


	protected override void Definition()
	{
		inputTrigger = ControlInput("inputTrigger", (flow) =>
		{
			var ps = flow.GetValue<List<Vector3>>(points);
			var thick = flow.GetValue<float>(thickness);
			var col = flow.GetValue<Color>(color);
			var close = flow.GetValue<bool>(this.closed);
			var join = flow.GetValue<Shapes.PolylineJoins>(joins);

			using (Draw.Command(Camera.main))
			{
				using (var path = new PolylinePath())
				{
					path.AddPoints(ps);
					Shapes.Draw.Polyline(path,close,thick,join,col); // This is the actual Shapes draw command
				}//dispose path
			}
			return outputTrigger;
		});
		//Making the ControlOutput port visible and setting its key.
		outputTrigger = ControlOutput("outputTrigger");

		points = ValueInput<List<Vector3>>("points", new List<Vector3>());
		thickness = ValueInput<float>("thickness", 0.1f);
		color = ValueInput<Color>("color", Color.white);
		closed = ValueInput<bool>("closed", false);
		joins = ValueInput<PolylineJoins>("joins", PolylineJoins.Miter);
	}
}		