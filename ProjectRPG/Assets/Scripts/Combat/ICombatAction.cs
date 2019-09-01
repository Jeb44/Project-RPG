using SOArchitecture.Reference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ToDo: create "standard" action ?
// CA_Damage					=> Apply always damage and effect
// CA_DamageChance				=> Apply sometimes damage and effect
// CA_DamageAndEffectChance		=> Apply 

namespace Game.Combat {
	[CreateAssetMenu(fileName = "CA_NewAction", menuName = "Combat/Action", order = 2)]
	///<summary>Saves data about an action and their possible effects and combo's. Overwrite this class to create more specific actions.</summary>
	public class ICombatAction : ScriptableObject {
		public StringReference title;
		public IntReference value;
		public Element element;

		public ICombatEffect[] effects;
		public ICombatCombo[] combos;

		/// <summary>Get action value. Overwrite to modify value before giving it to unit.</summary>
		/// <returns>Value.</returns>
		public virtual int GetValue() {
			return value;
		}

		/// <summary>Get action effects. Overwrite to modify list of effects before giving it to unit.</summary>
		///<returns>Effects.</returns>
		public virtual ICombatEffect[] GetEffects() {
			return effects;
		}

		/// <summary>Get action combos. Overwrite to modify list of combos before applying it to unit.</summary>
		///<returns>Combos.</returns>
		public virtual ICombatCombo[] GetCombos() {
			return combos;
		}
	}
}
