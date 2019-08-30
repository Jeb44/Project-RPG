using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

// ToDo: Functions for level-ups? -> extra class for "level-upping"?

namespace Game.Combat {
	// Note: wrong menuName?
	///<summary>Handles stats of an unit from a world perspective.</summary>
	[CreateAssetMenu(fileName = "WUS_Entity", menuName = "Combat/Stats: World", order = 1)]
	public class WorldUnitStats : ScriptableObject {
		[SerializeField] private IntReference maxHealth;
		public int MaxHealth{
			get {
				return maxHealth;
			}
			set {
				maxHealth = value;
			}
		}
		
		[SerializeField] private IntReference attack;
		public int Attack{
			get {
				return attack;
			}
			set {
				attack = value;
			}
		}
		
		[SerializeField] private IntReference defense;
		public int Defense{
			get {
				return defense;
			}
			set {
				defense = value;
			}
		}
		
		public List<Element> Resistances;
		public List<Element> Weaknesses;

		[Header("Changed via CombatUnitStats!")]
		[SerializeField] private IntReference currentHealth;
		public int CurrentHealth{
			get {
				return currentHealth;
			}
			set {
				currentHealth = value;
				if(currentHealth < 0) currentHealth = 0; // Player dead! Some kind of function call?
				if(currentHealth > MaxHealth) currentHealth = MaxHealth;
			}
		}
		
		///<summary>Call this to reset currentHealth to maxHealth.</summary>
		public void ResetCurrentHealth(){
			CurrentHealth = MaxHealth;
		}

		///<summary>Apply currentHealth from combatUnit to worldUnit.</summary>
		public void TransferNewStats(CombatUnitStats newStats){
			this.CurrentHealth = newStats.CurrentHealth;
			// other stats ...
		}
	}
}


