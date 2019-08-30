using System;
using SOArchitecture.Variable;

namespace SOArchitecture.Reference {
	[Serializable]
	public class FloatReference {
		public bool UseStandard = true;
		public float StandardValue;
		public FloatVariable Reference;

		public FloatReference() { }

		public FloatReference(float value) {
			UseStandard = true;
			StandardValue = value;
		}

		public float Value {
			get { return UseStandard ? StandardValue : Reference.value; }
		}

		#region Operators
		public static implicit operator FloatReference(float rhs) {
			return new FloatReference(rhs);
		}
		
		public static implicit operator float(FloatReference reference) {
			return reference.Value;
		}

		public static implicit operator string(FloatReference reference) {
			return reference.Value.ToString();
		}
		#endregion
		
	}
}

