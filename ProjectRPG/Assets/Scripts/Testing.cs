using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOArchitecture.Reference;
using TMPro;
using UnityEngine.UI;
using Game.Combat;

public class Testing : MonoBehaviour
{
	public BoolReference test;
	public StringReference test2;
	public StringReference test3;


	public TMP_Text txtHPValue;

	public ICombatAction action;
	public CombatUnitHolder unit;

	private CombatUnitStats stat;

	void Start(){		
		UpdateHP();
	}

	public void DoAction(){
		// unit.ApplyAction(action, 0);
		UpdateHP();
	}

	void UpdateHP(){
	}

	

}
