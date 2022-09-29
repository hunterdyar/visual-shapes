using Unity.VisualScripting;

namespace Shapes.UtilityNodes
{
	[UnitTitle("Into to Float")]
	public class IntToFloatNode : Unit
	{
		/// <summary>
		/// The first value.
		/// </summary>
		[DoNotSerialize]
		public ValueInput valueInt { get; private set; }

		/// <summary>
		/// The sum of A and B.
		/// </summary>
		[DoNotSerialize]
		[PortLabel("float")]
		public ValueOutput valueOutput { get; private set; }
		
		protected override void Definition()
		{
			valueInt = ValueInput<int>(nameof(valueInt));

			valueOutput = ValueOutput(nameof(valueOutput), Operation).Predictable();

			Requirement(valueInt, valueOutput);
		}

		private float Operation(Flow flow)
		{
			return (float)flow.GetValue<int>(valueInt);
		}
	}
}