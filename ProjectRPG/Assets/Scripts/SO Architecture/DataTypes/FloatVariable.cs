using UnityEngine;

namespace SOArchitecture.Variable {
	[CreateAssetMenu(fileName = "New Float Variable", menuName = "Variables/Float", order = 1)]
	public class FloatVariable : ScriptableObject {
#if UNITY_EDITOR
		[Multiline]	public string DeveloperDescription = "";
#endif

		public float value;

		public void SetValue(float value) {
			this.value = value;
		}
		
		public void SetValue(FloatVariable value) {
			this.value = value.value;
		}

		public void AddValue(float amount) {
			this.value += amount;
		}

		public void AddValue(FloatVariable amount) {
			this.value += amount.value;
		}

		public static FloatVariable operator + (FloatVariable b, FloatVariable c) {
			FloatVariable a = new FloatVariable();
			a.value = b.value + c.value;
			return a;
		}

		public static FloatVariable operator - (FloatVariable b, FloatVariable c) {
			FloatVariable a = new FloatVariable();
			a.value = b.value - c.value;
			return a;
		}

		public static FloatVariable operator * (FloatVariable b, FloatVariable c) {
			FloatVariable a = new FloatVariable();
			a.value = b.value * c.value;
			return a;
		}

		public static FloatVariable operator / (FloatVariable b, FloatVariable c) {
			FloatVariable a = new FloatVariable();
			a.value = b.value / c.value;
			return a;
		}

		public static bool operator == (FloatVariable lhs, FloatVariable rhs) {
			return lhs.value == rhs.value;
		}

		public static bool operator != (FloatVariable lhs, FloatVariable rhs) {
			return lhs.value != rhs.value;
		}

		public static bool operator > (FloatVariable lhs, FloatVariable rhs) {
			return lhs.value > rhs.value;
		}

		public static bool operator < (FloatVariable lhs, FloatVariable rhs) {
			return lhs.value < rhs.value;
		}

		public static bool operator >= (FloatVariable lhs, FloatVariable rhs) {
			return lhs.value >= rhs.value;
		}

		public static bool operator <= (FloatVariable lhs, FloatVariable rhs) {
			return lhs.value <= rhs.value;
		}

		public override int GetHashCode() => base.GetHashCode();

		public override bool Equals(object other) => base.Equals(other);

		public override string ToString() => value.ToString();

		public static implicit operator float(FloatVariable rhs) {
			return rhs.value;
		}
		public static implicit operator FloatVariable(float rhs) {
			FloatVariable v = new FloatVariable();
			v.value = rhs;
			return v;
		}
	}
}
