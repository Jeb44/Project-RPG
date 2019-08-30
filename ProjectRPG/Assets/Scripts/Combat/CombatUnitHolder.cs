using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat {
	[CreateAssetMenu(fileName = "CUH_Entity", menuName = "Combat/Unit", order = 0)]
	///<summary>Saves unit stat containers and avaiable actions.</summary>
	public class CombatUnitHolder : ScriptableObject {
		public WorldUnitStats worldStats;
		public CombatUnitStats combatStats;

		public ICombatAction[] actions;

		///<summary>Before combat, set up the class correctly.</summary>
		public void OnCombatStart(){
			combatStats.OnCombatBegin(worldStats);
		}


		///<summary>After combat, clean up class.</summary>
		public void OnCombatEnd(){
			worldStats.TransferNewStats(combatStats);
			combatStats.OnCombatEnd();
			combatStats = null;
		}

		/// <summary>Calculate receiving damage from action.</summary>
		/// <param name="action">Action that hits the unit.</param>
		/// <param name="unitAttackValue">Attack value of the attacking unit (required for damage formula).</param>
		/// <returns>Does the unit survive?</returns>
		public bool ExecuteActionOnUnit(ICombatAction action, int unitAttackValue) {
			// Note: Put this in CUS?
			int totalValue = action.GetValue() + unitAttackValue;
			
			List<ICombatEffect> newEffects;
			GetNewEffects(ref action, out newEffects);

			List<ICombatCombo> applicableCombos;
			GetApplicableCombos(ref action, out applicableCombos);

			ExtrudeValueAndEffectsFromCombo(ref applicableCombos, ref totalValue, ref newEffects);
			combatStats.AddEffects(newEffects);

			combatStats.CalculateResultingValue(totalValue, action.element);
			ApplyEffectsOnHit(ref newEffects);

			CombatElement.Instance.ActiveElement = action.element;
			
			return true;
		}

		#region ExecuteActionOnUnit Refactoring
		private List<ICombatEffect> GetNewEffects(ref ICombatAction action, out List<ICombatEffect> newEffects){
			newEffects = new List<ICombatEffect>();
			foreach(var effect in action.GetEffects()){
				newEffects.Add(effect);
			}
			return newEffects;
		}

		private void GetApplicableCombos(ref ICombatAction action, out List<ICombatCombo> combos){
			combos = new List<ICombatCombo>();
			foreach(var combo in action.GetCombos()) {
				foreach(var trigger in combo.GetTriggers()){
					if(trigger == CombatElement.Instance.ActiveElement) {
						combos.Add(combo);
						break;
					}
				}
			}
		}

		private void ExtrudeValueAndEffectsFromCombo(ref List<ICombatCombo> applicableCombos, ref int totalValue, ref List<ICombatEffect> newEffects){
			foreach(var combo in applicableCombos){
				totalValue += combo.GetValue();
				foreach(var effect in combo.GetEffects()){
					newEffects.Add(effect);
				}
			}
		}

		private void ApplyEffectsOnHit(ref List<ICombatEffect> effects){
			foreach(var effect in effects){
				effect.OnHit(combatStats);
			}
		}
		#endregion 
	}
}