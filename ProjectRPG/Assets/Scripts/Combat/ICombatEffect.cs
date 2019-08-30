using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;
using System;

// ToDo: create "standard" effect ?

namespace Game.Combat {
	[CreateAssetMenu(fileName = "CE_NewEffect", menuName = "Combat/Effect", order = 3)]
	///<summary>Saves data about an effect with duration and turnCount. Overwrite this class to create more specific effects's.</summary>
	public class ICombatEffect : ScriptableObject {
		public StringReference title;
		public StringReference description;
		public IntReference duration;

		private IntReference turnCount;

		/// <summary>Do something when the effect first hits.</summary>
		/// <param name="target">Unit that is affected.</param>
		public virtual void OnHit(CombatUnitStats target) {
		}

		/// <summary>Do something on any round of the effect duration. Use "turnCount" to apply effects at specific rounds. Please call "Base Function" when overwriting this method.</summary>
		/// <param name="target">Unit that is affected.</param>
		/// <returns>Target is allowed to procede with it's turn?</returns>
		public virtual bool OnAnyRound(CombatUnitStats target) {
			turnCount++;
			return true;
		}

		/// <summary>Do something when the unit is about to use any attack.</summary>
		/// <param name="target">Unit that is affected.</param>
		/// <returns>Target is allowed to procede with it's attack?</returns>
		public virtual bool OnAttack(CombatUnitStats target) {
			return true;
		}

		/// <summary>Do something when the unit is about to use any defense.</summary>
		/// <param name="target">Unit that is affected.</param>
		/// <returns>Target is allowed to procede with it's defensive ability?</returns>
		public virtual bool OnDefend(CombatUnitStats target) {
			return true;
		}

		/// <summary>Effect is applied anew / is refreshed.</summary>
		/// <returns>Effect can be refreshed?</returns>
		public virtual bool Refresh() {
			return true;
		}
	}
}