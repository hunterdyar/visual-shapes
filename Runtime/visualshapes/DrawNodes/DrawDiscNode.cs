using System.Collections;
using System.Collections.Generic;
using Shapes;
using Unity.VisualScripting;
using UnityEngine;

[UnitTitle("Draw Disc")]
[UnitCategory("Shapes")]
public class DrawDiscNode : Unit
{
   [DoNotSerialize] // No need to serialize ports.
   public ControlInput inputTrigger; //Adding the ControlInput port variable

   [DoNotSerialize] // No need to serialize ports.
   public ControlOutput outputTrigger; //Adding the ControlOutput port variable.

   [DoNotSerialize]
   public ValueInput pos; 

   [DoNotSerialize] 
   public ValueInput radius; 

   [DoNotSerialize]
   public ValueInput color;

   
   protected override void Definition()
   {
      inputTrigger = ControlInput("inputTrigger", (flow) =>
      {
         var p = flow.GetValue<Vector3>(pos);
         var r = flow.GetValue<float>(radius);
         var c = flow.GetValue<Color>(color);
         
         using (Draw.Command(Camera.main))
         {
            Shapes.Draw.Disc(p, r, c); // This is the actual Shapes draw command
         }

         return outputTrigger;
      });
      //Making the ControlOutput port visible and setting its key.
      outputTrigger = ControlOutput("outputTrigger");

      pos = ValueInput<Vector3>("position", Vector3.zero);
      radius = ValueInput<float>("radius", 0.5f);
      color = ValueInput<Color>("color", Color.white);
   }
}

//					
