using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

// 1. Init Combat
// 2. Unit Management
// 3. Start Combat:
//	- Set Active Element
//	- Create Stat Copies


namespace Game.Combat {
	public class CombatMotor : MonoBehaviour {

		public List<CombatUnitHolder> party;
		public List<CombatUnitHolder> enemies;

		void Init(){
			OnCombatInit();
		}

		void Start(){
			OnCombatStart();
		}

		void Update(){
			// Do stuff

			// if endCombat -> OnCombatEnd();

		}

		void Destroy(){
			OnCombatDestroy();
		}

		///<summary>Init Combat Scene (Refereces) </summary>
		public virtual void OnCombatInit(){

		}

		#region Unit Management

		public void AddPartyMember(CombatUnitHolder unit){
			party.Add(unit);
		}

		public void AddPartyMembers(CombatUnitHolder[] units){
			party.AddRange(units);
		}

		public void AddPartyMembers(List<CombatUnitHolder> units){
			party.AddRange(units);
		}

		public void AddEnemy(CombatUnitHolder unit){
			enemies.Add(unit);
		}

		public void AddEnemies(CombatUnitHolder[] units){
			enemies.AddRange(units);
		}

		public void AddEnemies(List<CombatUnitHolder> units){
			enemies.AddRange(units);
		}
		
		#endregion

		///<summary>Start Combat</summary>
		public virtual void OnCombatStart(){
			foreach(var unit in party){
				unit.OnCombatStart();
			}
			foreach(var unit in enemies){
				unit.OnCombatStart();
			}

			CombatElement.Instance.ActiveElement = Element.Neutral;
		}

		///<summary>End Combat</summary>
		public virtual void OnCombatEnd(){
			ApplyTemporaryStatsToWorld();
		}

		private void ApplyTemporaryStatsToWorld(){
			foreach(var unit in party){
				unit.OnCombatEnd();
			}
		}
		
		///<summary>Destroy Combat Scene</summary>
		public virtual void OnCombatDestroy(){

		}

	}
}

