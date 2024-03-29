﻿using System;
using System.Linq;
using UnityEngine;

namespace SOArchitecture.Singleton{
	/// <summary>
	/// Abstract class for making reload-proof singletons out of ScriptableObjects
	/// Returns the asset created on the editor, or null if there is none
	/// Based on https://www.youtube.com/watch?v=VBA1QCoEAX4 | https://baraujo.net/unity3d-making-singletons-from-scriptableobjects-automatically/
	/// </summary>
	/// <typeparam name="T">Singleton type</typeparam>
	public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject {
		static T _instance = null;
		public static T Instance
		{
			get
			{
				if (!_instance){
					_instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
				}
				Debug.LogWarning("No instance found for SO Singleton. Has Object not been created yet?");
				return _instance;
			}
		}
	}
}