using System;

namespace Models
{
	[Serializable]
	public class Score
	{
		public string name;
		public string score;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

