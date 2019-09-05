using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

// ToDo: create "standard" combo ?

namespace Game.Combat {
	[CreateAssetMenu(fileName = "CC_NewCombo", menuName = "Combat/Combo", order = 4)]
	///<summary>Saves data about a combo with their triggers and possible effects. Overwrite this class to create more specific combo's.</summary>
	public abstract class ICombatCombo : ScriptableObject {
		public StringReference title;
		public Element[] triggers = new Element[1]; //Write Custom Inspector with OnInspectorGUI() to check that the array min size is 1
		public IntReference value;
		public ICombatEffect[] effects;
		
		/// <summary>Get combo value. Overwrite to modify value before giving it to unit.</summary>
		/// <returns>Value.</returns>
		public virtual int GetValue() {
			return value;
		}

		/// <summary>Get elementan combo triggers. Overwrite to modify value before giving it to unit.</summary>
		/// <returns>Value.</returns>
		public virtual Element[] GetTriggers() {
			return triggers;
		}

		/// <summary>Get combo effects. Overwrite to modify value before giving it to unit.</summary>
		/// <returns>Value.</returns>
		public virtual ICombatEffect[] GetEffects() {
			return effects;
		}
	}
}