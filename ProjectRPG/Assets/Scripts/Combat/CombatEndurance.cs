using UnityEngine;
using SOArchitecture.Reference;

namespace Game.Combat{
	[CreateAssetMenu(menuName = "Combat/Endurance Values")]
	public class CombatEndurance : SOArchitecture.Singleton.SingletonScriptableObject<CombatEndurance> {
#if UNITY_EDITOR
		[UnityEditor.MenuItem("Window/Combat/Combat Endurance Values")]
		public static void ShowCombatEnduranceValues(){
			UnityEditor.Selection.activeObject = Instance;
		}
#endif
		
		[SerializeField] private IntReference resistanceBonusValue = +1;
		public int ResistanceBonusValue{
			get{
				return resistanceBonusValue;
			}
		}

		[SerializeField] private IntReference weaknessBonusValue = -1;
		public int WeaknessBonusValue{
			get{
				return weaknessBonusValue;
			}
		}

		[SerializeField] private IntReference bonusValueModifier = 1; // resistance/weakness scaling
		public int BonusValueModifier{
			get{
				return bonusValueModifier;
			}
		}
	}
}