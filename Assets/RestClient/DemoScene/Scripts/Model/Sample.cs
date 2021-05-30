using System;

namespace Models
{
	[Serializable]
	public class Sample
	{
        public Sample(int amount){
            this.amount = amount;
        }
		public int amount;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
    public class Token{
		public Access access;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
    public class Access
	{
		public string access;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

