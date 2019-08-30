using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;

namespace SOArchitecture{
	public class ISetter : MonoBehaviour
	{
		public BoolReference updateEveryFrame = true;

		void Update(){
			if(updateEveryFrame){
				OnUpdate();
			}
		}

		public virtual void OnUpdate(){}
	}
}

