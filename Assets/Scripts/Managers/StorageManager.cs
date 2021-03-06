//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;

namespace Assets.Scripts.Managers
{
	public class StorageManager
	{

		public static void SetSound (bool flag){
			ES2.Save (flag, "sound");
		}

		public static bool IsSoundOn (){
			if (ES2.Exists ("sound")){
				return ES2.Load<bool> ("sound");
			}
			else {
				return true;
			}
		}

		public static void SetLevelLocked (string key, bool flag){
			ES2.Save (flag, key);
		}

		public static bool IsLevelLocked (string key){
			if (ES2.Exists (key)) {
				return ES2.Load<bool> (key);
			} 
			else {
				return true;
			}
		}
	}
}

