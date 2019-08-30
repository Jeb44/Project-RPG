using System;
using UnityEngine;
using SOArchitecture.Variable;

// audio -> parameter, volume, trigger
// animator -> paramter

// reminder: Use UnityEvent for Damage & Death in Unit's!

namespace SOArchitecture.Reference {
	[Serializable]
	public class IntReference {
		public bool UseStandard = true;
		public int StandardValue;
		public IntVariable Reference;

		public IntReference() { }

		public IntReference(int value) {
			UseStandard = true;
			StandardValue = value;
		}

		public int Value {
			get { return UseStandard ? StandardValue : Reference.value; }
			set {
				if(UseStandard){
					StandardValue = value;
				} else{
					Reference = value;
				}
			}
		}

		#region Operators
		public static implicit operator IntReference(int rhs) {
			return new IntReference(rhs);
		}
		
		public static implicit operator int(IntReference rhs) {
			return rhs.Value;
		}

		public static implicit operator string(IntReference rhs) {
			return rhs.Value.ToString();
		}
		#endregion
	}
}