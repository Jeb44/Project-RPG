using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

namespace Game.Combat {
	[CreateAssetMenu(fileName = "CUS_Entity", menuName = "Combat/Stats: Combat", order = 1)]
	///<summary>Handles stats of an unit from an in combat perspective.</summary>
	public class CombatUnitStats : ScriptableObject {
		[SerializeField] private IntReference maxHealth;
		public int MaxHealth{
			get {
				return maxHealth;
			}
			set {
				maxHealth = value;
			}
		}
		
		[SerializeField] private IntReference temporaryBonusHealth = 0;
		public int TemporaryBonusHealth{
			get {
				return temporaryBonusHealth;
			}
			set {
				temporaryBonusHealth = value;
			}
		}
		
		[SerializeField] private IntReference currentHealth;
		public int CurrentHealth{
			get{
				return currentHealth;
			}
			set{
				currentHealth = value;
				if(currentHealth < 0) currentHealth = 0;
				if(currentHealth > MaxHealth + TemporaryBonusHealth) currentHealth = MaxHealth + TemporaryBonusHealth;
			}
		}

		[SerializeField] private IntReference currentAttack;
		public int CurrentAttack{
			get {
				return currentAttack;
			}
			set {
				currentAttack = value;
			}
		}
		
		[SerializeField] private IntReference currentDefense;
		public int CurrentDefense{
			get {
				return currentDefense;
			}
			set {
				currentDefense = value;
			}
		}

		[SerializeField] private List<Element> currentResistances;
		public List<Element> CurrentResistances{
			get{
				return currentResistances;
			}
			set{
				currentResistances = value;
			}
		}

		[SerializeField] private List<Element> currentWeaknesses;
		public List<Element> CurrentWeaknesses{
			get{
				return currentWeaknesses;
			}
			set{
				currentWeaknesses = value;
			}
		}

		[SerializeField] private List<ICombatEffect> activeEffects;
		public List<ICombatEffect> ActiveEffects{
			get{
				return activeEffects;
			}
		}

		///<summary>Before combat, set up the class correctly.</summary>
		public void OnCombatBegin(WorldUnitStats blueprint){
			MaxHealth = blueprint.MaxHealth;
			TemporaryBonusHealth = 0;
			CurrentHealth = blueprint.CurrentHealth;
			CurrentAttack = blueprint.Attack;
			CurrentDefense = blueprint.Defense;

			if(CurrentResistances == null){
				CurrentResistances = new List<Element>();
			}
			CurrentResistances.AddRange(blueprint.Resistances);

			if(CurrentWeaknesses == null){
				CurrentWeaknesses = new List<Element>();
			}
			CurrentWeaknesses.AddRange(blueprint.Weaknesses);

			if(activeEffects == null){
				activeEffects = new List<ICombatEffect>();
			}
		}

		///<summary>After combat, clean up class.</summary>
		public void OnCombatEnd(){
			activeEffects.Clear();
			currentResistances.Clear();
			currentWeaknesses.Clear();
		}

		/// <summary>Add value to the unit according to damage formula. Healing = pos. Values, Damage = neg. Values.</summary>
		/// <param name="value">Value to add.</param>
		/// <param name="element">Value's element.</param>
		/// <returns>Does the unit survive?</returns>
		public bool CalculateResultingValue(int value, Element element){
			if(value == 0){ return true; } // for pure (de)buff spells 

			int enduranceValue = CalculateEndurance(element);

			int resultingValue = value + enduranceValue;
			CurrentHealth += resultingValue + ((resultingValue >= 0)? 0 : CurrentDefense); // dont add defense bonuses on healing spells!

			if(currentHealth <= 0){
				return false;
			}
			return true;
		}

		private int CalculateEndurance(Element element){
			int enduranceValue = (currentResistances.Contains(element))?
				CombatEndurance.Instance.ResistanceBonusValue : 0;	// +1
			enduranceValue += (currentWeaknesses.Contains(element))?
				CombatEndurance.Instance.WeaknessBonusValue : 0;	// -1
			enduranceValue *= CombatEndurance.Instance.BonusValueModifier;
			return enduranceValue;
		}
	
			#region Active Effects Methods

		/// <summary>Add a new effect to the list of active effects.</summary>
		/// <param name="effect">Effect to add.</param>
		public void AddEffect(ICombatEffect effect) {
			if(activeEffects == null) return;
			if(!activeEffects.Contains(effect)) {
				activeEffects.Add(Instantiate(effect));
			} else {
				// perhaps bug here: Maybe "Instantiate"d object != SO object
				int index = activeEffects.IndexOf(effect);
				activeEffects[index].Refresh();
			}
		}

		/// <summary>Add new effects to the list of active effects.</summary>
		/// <param name="effect">Array of effects to add.</param>
		public void AddEffects(ICombatEffect[] effects) {
			if(activeEffects == null) return;
			foreach(ICombatEffect effect in effects) {
				AddEffect(effect);
			}			
		}

		/// <summary>Add new effects to the list of active effects.</summary>
		/// <param name="effect">List of effects to add.</param>
		public void AddEffects(List<ICombatEffect> effects) {
			if(activeEffects == null) return;
			foreach(ICombatEffect effect in effects) {
				AddEffect(effect);
			}			
		}

		/// <summary>Remove an effect of the list of active effects.</summary>
		/// <param name="effect">Effect to remove.</param>
		public void RemoveEffect(ICombatEffect effect) {
			if(activeEffects == null) return;
			// perhaps bug here: Maybe "Instantiate"d object != SO object
			if(activeEffects.Contains(effect)) {
				activeEffects.Remove(effect);
			}
		}

		/// <summary>Remove effects of the list of active effects.</summary>
		/// <param name="effect">Array of effects to remove.</param>
		public void RemoveEffects(ICombatEffect[] effects) {
			if(activeEffects == null) return;
			foreach(ICombatEffect effect in effects) {
				RemoveEffect(effect);
			}
		}

		/// <summary>Remove effects of the list of active effects.</summary>
		/// <param name="effect">List of effects to remove.</param>
		public void RemoveEffects(List<ICombatEffect> effects) {
			if(activeEffects == null) return;
			foreach(ICombatEffect effect in effects) {
				RemoveEffect(effect);
			}
		}

		#endregion
	}

}