using UnityEngine;
using UnityEngine.UI;
using SOArchitecture.Reference;

namespace SOArchitecture.UI {
	/// <summary>
	/// Sets an Image component's fill amount to represent how far Variable is
	/// between Min and Max.
	/// </summary>
	public class ImageFillSetter : ISetter
	{
		[Tooltip("Value to use as the current ")]
		public FloatReference variable;

		[Tooltip("Min value that Variable to have no fill on Image.")]
		public FloatReference min;

		[Tooltip("Max value that Variable can be to fill Image.")]
		public FloatReference max;

		[Tooltip("Image to set the fill amount on." )]
		public Image image;

		public override void OnUpdate()
		{
			if (variable != null && min != null && max != null && image != null){
				image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(min, max, variable));
			} else{
				Debug.LogAssertion("ImageFillerSetter is missing some references.");
			}
		}
	}
}