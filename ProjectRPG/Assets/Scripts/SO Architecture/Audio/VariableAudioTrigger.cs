using UnityEngine;
using SOArchitecture.Variable;
using SOArchitecture.Reference;

namespace SOArchitecture.Audio{
	public class VariableAudioTrigger : ISetter {
		[Tooltip("Variable to send to the mixer parameter.")]
		public FloatVariable variable;

		[Tooltip("Trigger AudioSource when Threshold is hit.")]
		public FloatReference lowThreshold;

		[Tooltip("Audio Source to trigger.")]
		public AudioSource audioSource;

		public override void OnUpdate(){
			if (variable < lowThreshold){
				if (!audioSource.isPlaying){
					audioSource.Play();
				}
			} else {
				if (audioSource.isPlaying){
					audioSource.Stop();
				}
			}
		}
	}
}