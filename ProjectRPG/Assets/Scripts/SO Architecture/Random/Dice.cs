using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

namespace SOArchitecture.Random{
	[CreateAssetMenu(fileName = "New Dice", menuName = "Dice")]
	public class Dice : ScriptableObject{
		[Tooltip("First value of the dice.")]
		public int minValue = 1;
		[Tooltip("Last value of the dice.")]
		public int maxValue = 6;

		private int currentRoll;
		public int CurrentRoll{
			get{
				return currentRoll;
			}
		}

		private int numberOfFaces = 6;
		public int NumberOfFaces{
			get{
				return numberOfFaces;
			}
		}

		public void Roll(){
			currentRoll = UnityEngine.Random.Range(minValue, maxValue);
		}

		public void RecalculateNumberOfFaces(){
			numberOfFaces = maxValue - minValue + 1;
		}
	}
}

