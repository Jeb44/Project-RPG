using UnityEngine;

namespace SOArchitecture.Variable {
	[CreateAssetMenu(fileName = "New String Variable", menuName = "Variables/String", order = 3)]
	public class StringVariable : ScriptableObject {
#if UNITY_EDITOR
		[Multiline]	public string DeveloperDescription = "";
#endif

		public string text = "";

		public void SetText(string text) {
			this.text = text;
		}

		public void SetText(StringVariable text) {
			this.text = text.text;
		}

		public void AddText(string text){
			this.text += text;
		}

		public void AddText(StringVariable text){
			this.text += text;
		}

		public static StringVariable operator + (StringVariable b, StringVariable c) {
			StringVariable a = new StringVariable();
			a.text = b.text + c.text;
			return a;
		}

		public static bool operator == (StringVariable lhs, StringVariable rhs) {
			return lhs.text == rhs.text;
		}

		public static bool operator != (StringVariable lhs, StringVariable rhs) {
			return lhs.text != rhs.text;
		}

		public override int GetHashCode() => base.GetHashCode();

		public override bool Equals(object other) => base.Equals(other);

		public override string ToString() => text;

		public static implicit operator string(StringVariable rhs) {
			return rhs.text;
		}
		public static implicit operator StringVariable(string rhs) {
			StringVariable v = new StringVariable();
			v.text = rhs;
			return v;
		}
	}
}
