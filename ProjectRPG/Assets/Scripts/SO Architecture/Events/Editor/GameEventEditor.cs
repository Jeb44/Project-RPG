﻿using UnityEngine;
using UnityEditor;

namespace SOArchitecture.Event.Editors{
	[CustomEditor(typeof(GameEvent))]
	public class GameEventEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			GUI.enabled = Application.isPlaying;

			GameEvent e = target as GameEvent;
			if (GUILayout.Button("Raise")){
				e.Raise();
			}
		}
	}
}