using UnityEngine;
using UnityEngine.UI;
using SOArchitecture.Reference;

namespace SOArchitecture.UI
{
	public class TextSetter : ISetter{
		public StringReference variable;
		public TMPro.TMP_Text text;
		
		private void OnEnable(){
			text.text = variable;
		}

		public override void OnUpdate(){
			if (text != null && variable != null){
				text.text = variable;
			} else{
				Debug.LogAssertion("TextReplacer is missing some references.");
			}
		}
	}
}