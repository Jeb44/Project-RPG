using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

namespace Game.Combat {
	[CreateAssetMenu(fileName = "CE_NewDoT", menuName = "Combat/Effect: VoT", order = 3)]
	public class CEValueOverTime : ICombatEffect
	{
		[Space]
		public IntReference value;
		[Range(0,1)] public float valueChance = 1.0f;

		public override bool OnAnyRound(CombatUnitStats target){
			base.OnAnyRound(target);

			if(valueChance <= Random.value){
				target.CurrentHealth += value;
			}

			return true;
		}
	}
}