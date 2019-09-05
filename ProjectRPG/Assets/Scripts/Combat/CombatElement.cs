using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat{
	[CreateAssetMenu(menuName = "Combat/ActiveElement")]
	public class CombatElement: SOArchitecture.Singleton.SingletonScriptableObject<CombatElement> {
#if UNITY_EDITOR
		[UnityEditor.MenuItem("Window/Combat/Active Element")]
		public static void ShowActiveElement(){
			UnityEditor.Selection.activeObject = Instance;
		}
#endif
		
		public CombatElement(){
			activeElement = Element.Neutral;
		}

		[SerializeField] private Element activeElement;
		public Element ActiveElement{
			get{
				return activeElement;
			}
			set{
				if(value == Element.Light) {
					return;
				}

				if(value == Element.Dark){
					activeElement = activeElement.GetOppositeElement();
					return;
				}
				
				activeElement = value;
			}
		}
	}
}