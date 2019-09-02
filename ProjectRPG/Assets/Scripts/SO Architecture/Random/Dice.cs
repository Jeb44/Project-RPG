using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

public class Dice : ScriptableObject{
	public int[] numbers;
	public int currentRoll;

	public void Roll(){
		Dictionary<int, bool> dictionary = new Dictionary<int, bool>(numbers.Length);
		foreach(var number in numbers){
			bool isHit = Random.value > 0.5f;
			dictionary.Add(number, isHit);
			// thats wrong
		}
	}

	public int GetCurrentDiceRoll(){
		return currentRoll;
	}
}
