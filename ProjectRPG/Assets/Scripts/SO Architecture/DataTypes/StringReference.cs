using System;
using SOArchitecture.Variable;

namespace SOArchitecture.Reference {
	[Serializable]
	public class StringReference {
		public bool UseStandard = true;
		public string StandardText;
		public StringVariable Reference;

		public StringReference() { }

		public StringReference(string text) {
			UseStandard = true;
			StandardText = text;
		}

		public string Text {
			get { return UseStandard ? StandardText : Reference.text; }
		}

		#region Operators
		public static implicit operator StringReference(string rhs) {
			return new StringReference(rhs);
		}

		public static implicit operator string(StringReference reference) {
			return reference.Text;
		}
		
		public static implicit operator char[] (StringReference reference) {
			return reference.Text.ToCharArray();
		}
		#endregion
	}
}