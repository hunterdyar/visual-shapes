using Unity.VisualScripting;
using UnityEngine;

namespace Shapes.DrawNodes
{
	[UnitCategory("Shapes")]
	[UnitTitle("Draw Line")]
	public class DrawLine : Unit
	{
		[DoNotSerialize] // No need to serialize ports.
        public ControlInput inputTrigger; //Adding the ControlInput port variable
    
        [DoNotSerialize] // No need to serialize ports.
        public ControlOutput outputTrigger; //Adding the ControlOutput port variable.
    
        [DoNotSerialize] public ValueInput start;
        [DoNotSerialize] public ValueInput end;

        [DoNotSerialize] public ValueInput thickness;
        
        [DoNotSerialize] public ValueInput color;
        
        // [DoNotSerialize] public ValueInput geometry;
    
        [DoNotSerialize] public ValueInput endCaps;
        
        
        protected override void Definition()
        {
        	inputTrigger = ControlInput("inputTrigger", (flow) =>
        	{
        		var s = flow.GetValue<Vector3>(start);
                var e = flow.GetValue<Vector3>(end);
                var thick = flow.GetValue<float>(thickness);
        		var col = flow.GetValue<Color>(color);
        		var caps = flow.GetValue<Shapes.LineEndCap>(endCaps);
    
        		using (Draw.Command(Camera.main))
                {
                    // Draw.LineGeometry = geo;
                    Shapes.Draw.Line(s,e,thick,caps,col); // This is the actual Shapes draw command
                }
        		return outputTrigger;
        	});
        	//Making the ControlOutput port visible and setting its key.
        	outputTrigger = ControlOutput("outputTrigger");
    
        	start = ValueInput<Vector3>(nameof(start), new Vector3());
            end = ValueInput<Vector3>(nameof(end), Vector3.right);
            thickness = ValueInput<float>(nameof(thickness), 0.1f);
        	color = ValueInput<Color>(nameof(color), Color.white);
        	endCaps = ValueInput<LineEndCap>(nameof(endCaps),LineEndCap.None);
        }
	}
}