using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOArchitecture.Event{
	[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Events", order = 0)]
	public class GameEvent : ScriptableObject
	{
		/// <summary>
		/// The list of listeners that this event will notify if it is raised.
		/// </summary>
		public readonly List<GameEventListener> eventListeners = new List<GameEventListener>();
		private int listenerCount = 0;

		public void Raise(){
			for(int i = eventListeners.Count -1; i >= 0; i--){
				eventListeners[i].OnEventRaised();
			}
		}

		public void RegisterListener(GameEventListener listener){
			if (!eventListeners.Contains(listener)){
				eventListeners.Add(listener);
				listenerCount++;
			}
		}

		public void UnregisterListener(GameEventListener listener){
			if (eventListeners.Contains(listener)){
				eventListeners.Remove(listener);
				listenerCount--;
			}
		}
	}
}