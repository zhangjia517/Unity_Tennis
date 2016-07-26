using UnityEngine;
using System.Collections;

public class Ticker : MonoBehaviour{
	public AudioClip squeak;
	
	void Slam(int amount){
		iTween.PunchRotation(gameObject,iTween.Hash("y",amount,"time",2));	
		iTween.Stab(gameObject,iTween.Hash("audioclip",squeak,"pitch",Random.Range(.9f,1),"volume",Random.Range(.5f,1)));
	}
}

