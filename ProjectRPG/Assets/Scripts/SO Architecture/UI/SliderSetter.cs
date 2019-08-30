using UnityEngine;
using UnityEngine.UI;
using SOArchitecture.Reference;

namespace SOArchitecture.UI {
	[ExecuteInEditMode]
	public class SliderSetter : ISetter{
		public FloatReference variable;
		public Slider slider;

		public override void OnUpdate()
		{
			if (slider != null && variable != null){
				slider.value = variable;
			} else{
				Debug.LogAssertion("SliderSetter is missing some references.");
			}
		}
	}
}