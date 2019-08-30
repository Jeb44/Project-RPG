using UnityEngine;
using UnityEngine.Audio;
using SOArchitecture.Variable;

namespace SOArchitecture.Audio{
	public class AudioVolumeSetter : ISetter{
		[Tooltip("Variable to send to the mixer parameter.")]
		public FloatVariable variable;

		[Tooltip("Mixer to set the parameter in.")]
		public AudioMixer mixer;

		[Tooltip("Name of the parameter to set in the mixer.")]
		public string parameterName = "";

		public override void OnUpdate(){
			float dB = variable > 0.0f ? 20.0f * Mathf.Log10(variable) : -80.0f;
			mixer.SetFloat(parameterName, dB);
		}
	}
}