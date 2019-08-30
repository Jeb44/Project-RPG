using UnityEngine;
using SOArchitecture.Variable;
using SOArchitecture.UI;
using UnityEngine.Animations;

namespace SOArchitecture.Animation{
	/// <summary>
	/// Takes a FloatVariable and sends its value to an Animator parameter 
	/// every frame on Update.
	/// </summary>
	public class AnimatorParameterSetter : ISetter{
		[Tooltip("Variable to read from and send to the Animator as the specified parameter.")]
		public FloatVariable variable;

		[Tooltip("Animator to set parameters on.")]
		public Animator animator;

		[Tooltip("Name of the parameter to set with the value of Variable.")]
		public string parameterName;

		/// <summary>Animator Hash of ParameterName, automatically generated.</summary>
		[SerializeField] private int parameterHash;

		private void OnValidate(){
			parameterHash = Animator.StringToHash(parameterName);
		}

		public override void OnUpdate(){
			animator.SetFloat(parameterHash, variable);
		}
	}
}