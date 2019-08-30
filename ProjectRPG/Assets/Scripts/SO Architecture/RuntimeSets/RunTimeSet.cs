using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOArchitecture.RunTimeSet
{
	/*	[EXAMPLES]
	 *	=== Derive from this class to create actual scriptable objects ===
	 *	[CreateAssetMenu] public class ThingRuntimeSet : RuntimeSet<Thing>{}
	 * 
	 *	=== Create MB with reference to a set ===
	 *	public class Thing : MonoBehaviour{
	 *		public ThingRuntimeSet RuntimeSet;
	 *
	 *		private void OnEnable(){
	 *			RuntimeSet.Add(this);
	 *		}
	 *
	 *		private void OnDisable(){
	 *			RuntimeSet.Remove(this);
	 *		}
	 *	}
	 *	
	 *	=== Modify existing sets ===
	 *	public class ThingDisabler : MonoBehaviour{
	 *		public ThingRuntimeSet Set;
	 *	
	 *		public void DisableAll()
	 *		{
	 *			for (int i = Set.Items.Count-1; i >= 0; i--){
	 *				Set.Items[i].gameObject.SetActive(false);
	 *			}
	 *		}
	 *
	 *		public void DisableRandom(){
	 *			int index = Random.Range(0, Set.Items.Count);
	 *			Set.Items[index].gameObject.SetActive(false);
	 *		}
	 *	}
	 *
	 *	=== Show existing sets ===
	 *	public class ThingMonitor : MonoBehaviour{
	 *		public ThingRuntimeSet Set;
	 *
	 *		public Text Text;
	 *
	 *		private int previousCount = -1;
	 *
	 *		private void OnEnable(){
	 *			UpdateText();
	 *		}
	 *
	 *		private void Update(){
	 *			if (previousCount != Set.Items.Count){
	 *				UpdateText();
	 *				previousCount = Set.Items.Count;
	 *			}
	 *		}
	 *
	 *		public void UpdateText(){
	 *			Text.text = "There are " + Set.Items.Count + " things.";
	 *		}
	 *	}
	 */
	
	///<summary>RunTimeSet to store items automaticly.</summary>
	public abstract class RuntimeSet<T> : ScriptableObject{
		public List<T> Items = new List<T>();

		public void Add(T thing){
			if (!Items.Contains(thing)){
				Items.Add(thing);
			}
		}

		public void Remove(T thing){
			if (Items.Contains(thing)){
				Items.Remove(thing);
			}
		}
	}
}