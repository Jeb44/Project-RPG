using UnityEngine;
using UnityEditor;

namespace SOArchitecture.Random.Editors{
	[CustomEditor(typeof(Dice))]
	public class DiceEditor : Editor{
		private SerializedObject obj;
		private SerializedProperty currentRoll;
		private SerializedProperty numberOfFaces;

		public void OnEnable(){
			obj = new SerializedObject(target);
			currentRoll = serializedObject.FindProperty("currentRoll");
			numberOfFaces = serializedObject.FindProperty("numberOfFaces");
		}

		public override void OnInspectorGUI(){
			obj.Update();

			base.OnInspectorGUI();
			
			Dice e = target as Dice;

			if(GUI.changed){
				e.RecalculateNumberOfFaces();
			}
			
			GUI.enabled = false;

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.IntField(new GUIContent("Current Roll", "Call Roll() to randomize a new number between startValue and endValue (both inclusive)."), e.CurrentRoll);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.IntField(new GUIContent("Number of Faces", "Current number of faces the dice has. Dice usually have an even number of faces."), e.NumberOfFaces);
			EditorGUILayout.EndHorizontal();

			GUI.enabled = true;

			GUI.enabled = Application.isPlaying;
			if (GUILayout.Button("Roll")){
				e.Roll();
			}

			obj.ApplyModifiedProperties();    
		}
	}
}