using System;
using SOArchitecture.Variable;

namespace SOArchitecture.Reference {
	[Serializable]
	public class BoolReference {
		public bool UseStandard = true;
		public bool StandardValue;
		public BoolVariable Reference;

		public BoolReference() { }

		public BoolReference(bool value) {
			UseStandard = true;
			StandardValue = value;
		}

		public bool Value {
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
		public static implicit operator BoolReference(bool rhs) {
			return new BoolReference(rhs);
		}
		
		public static implicit operator bool(BoolReference rhs) {
			return rhs.Value;
		}

		public static implicit operator string(BoolReference rhs) {
			return rhs.Value.ToString();
		}
		#endregion
	}
}