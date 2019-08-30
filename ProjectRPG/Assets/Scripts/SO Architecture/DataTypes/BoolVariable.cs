using UnityEngine;

namespace SOArchitecture.Variable {
	[CreateAssetMenu(fileName = "New Bool Variable", menuName = "Variables/Bool", order = 2)]
	public class BoolVariable : ScriptableObject {
#if UNITY_EDITOR
		[Multiline] public string DeveloperDescription = "";
#endif

		public bool value;

		public void SetValue(bool value) {
			this.value = value;
		}

		public void SetValue(BoolVariable value) {
			this.value = value.value;
		}

		public static bool operator == (BoolVariable lhs, BoolVariable rhs) {
			return lhs.value == rhs.value;
		}

		public static bool operator != (BoolVariable lhs, BoolVariable rhs) {
			return lhs.value != rhs.value;
		}

		public override int GetHashCode() => base.GetHashCode();

		public override bool Equals(object other) => base.Equals(other);

		public override string ToString() => value.ToString();

		public static implicit operator bool(BoolVariable rhs) {
			return rhs.value;
		}
		public static implicit operator BoolVariable(bool rhs) {
			BoolVariable v = new BoolVariable();
			v.value = rhs;
			return v;
		}
	}
}