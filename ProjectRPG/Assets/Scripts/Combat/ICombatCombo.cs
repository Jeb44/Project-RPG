using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

namespace Game.Combat {
	///<summary>Saves data about a combo with their triggers and possible effects. Overwrite this class to create more specific combo's.</summary>
	public abstract class ICombatCombo : ScriptableObject {
		[Tooltip("Name of the combo.")]
		public StringReference title;

		[Tooltip("Which element can trigger the combo.")]
		public Element[] triggers = new Element[1]; //Write Custom Inspector with OnInspectorGUI() to check that the array min size is 1
		
		[Tooltip("pos. Values = Healing | neg. Values = Damage")]
		public IntReference value;

		[Space]
		[Range(0,1)] public float effectChance = 0.0f;
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
			if(effectChance <= Random.value){
				return new ICombatEffect[0];
			}
			return effects;
		}
	}
}