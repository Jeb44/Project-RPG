using UnityEngine;
using UnityEngine.Events;

namespace SOArchitecture.Event{
	public class GameEventListener : MonoBehaviour
	{
		[Tooltip("Event SO to register with.")]
		public GameEvent gameEvent;

		[Tooltip("Response to invoke when Event is raised.")]
		public UnityEvent unityResponse;

		private void OnEnable(){
			gameEvent.RegisterListener(this);
		}

		private void OnDisable(){
			gameEvent.UnregisterListener(this);
		}

		public void OnEventRaised(){
			unityResponse.Invoke();
		}
	}
}

