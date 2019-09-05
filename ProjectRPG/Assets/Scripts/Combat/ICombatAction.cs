using SOArchitecture.Reference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Random;

// ToDo: create "standard" action ? [true, false, chance]
// damage = false => value = 0
// damage = true => value < 0 || value > 0
// Effect always chance! 

// Random mechanic -> dice roll!

namespace Game.Combat {
	// [CreateAssetMenu(fileName = "CA_NewAction", menuName = "Combat/Action", order = 2)]
	///<summary>Saves data about an action and their possible effects and combo's. Overwrite this class to create more specific actions.</summary>
	public abstract class ICombatAction : ScriptableObject {
		[Tooltip("Name of the action.")]
		public StringReference title;
		
		[Tooltip("pos. Values = Healing | neg. Values = Damage")]
		public IntReference value;
		
		[Tooltip("The next active Element after the action. Exceptions: Light => Current element remains. Dark => Opposite element occurs.")]
		public Element element;

		[Space]
		[Range(0,1)] public float effectChance = 0.0f;
		public ICombatEffect[] effects;

		[Space]
		public ICombatCombo[] combos;

		/// <summary>Get action value. Overwrite to modify value before giving it to unit.</summary>
		/// <returns>Full Value.</returns>
		public virtual int GetValue(){
			return value;
		}

		/// <summary>Get action effects based on effectChance. Overwrite to modify list of effects before giving it to unit.</summary>
		///<returns>Return all effects or none.</returns>
		public virtual ICombatEffect[] GetEffects(){
			if(effectChance >= Random.value){
				return new ICombatEffect[0];
			}
			return effects;
		}

		/// <summary>Get action combos. Overwrite to modify list of combos before applying it to unit.</summary>
		///<returns>All Combos.</returns>
		public virtual ICombatCombo[] GetCombos(){
			return combos;
		}
	}
}
