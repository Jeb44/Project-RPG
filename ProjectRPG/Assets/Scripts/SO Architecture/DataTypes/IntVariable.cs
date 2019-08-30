using UnityEngine;

namespace SOArchitecture.Variable {
	[CreateAssetMenu(fileName = "New Int Variable", menuName = "Variables/Int", order = 0)]
	public class IntVariable : ScriptableObject {
#if UNITY_EDITOR
		[Multiline] public string DeveloperDescription = "";
#endif

		public int value;

		public void SetValue(int value) {
			this.value = value;
		}

		public void SetValue(IntVariable value) {
			this.value = value.value;
		}

		public void AddValue(int amount) {
			this.value += amount;
		}

		public void AddValue(IntVariable amount) {
			this.value += amount.value;
		}


		public static IntVariable operator + (IntVariable b, IntVariable c) {
			IntVariable a = new IntVariable();
			a.value = b.value + c.value;
			return a;
		}

		public static IntVariable operator - (IntVariable b, IntVariable c) {
			IntVariable a = new IntVariable();
			a.value = b.value - c.value;
			return a;
		}

		public static IntVariable operator * (IntVariable b, IntVariable c) {
			IntVariable a = new IntVariable();
			a.value = b.value * c.value;
			return a;
		}

		public static IntVariable operator / (IntVariable b, IntVariable c) {
			IntVariable a = new IntVariable();
			a.value = b.value / c.value;
			return a;
		}

		public static bool operator == (IntVariable lhs, IntVariable rhs) {
			return lhs.value == rhs.value;
		}

		public static bool operator != (IntVariable lhs, IntVariable rhs) {
			return lhs.value != rhs.value;
		}

		public static bool operator > (IntVariable lhs, IntVariable rhs) {
			return lhs.value > rhs.value;
		}

		public static bool operator < (IntVariable lhs, IntVariable rhs) {
			return lhs.value < rhs.value;
		}

		public static bool operator >= (IntVariable lhs, IntVariable rhs) {
			return lhs.value >= rhs.value;
		}

		public static bool operator <= (IntVariable lhs, IntVariable rhs) {
			return lhs.value <= rhs.value;
		}

		public override int GetHashCode() => base.GetHashCode();

		public override bool Equals(object other) => base.Equals(other);

		public override string ToString() => value.ToString();

		public static implicit operator int(IntVariable rhs) {
			return rhs.value;
		}
		public static implicit operator IntVariable(int rhs) {
			IntVariable v = new IntVariable();
			v.value = rhs;
			return v;
		}
	}
}