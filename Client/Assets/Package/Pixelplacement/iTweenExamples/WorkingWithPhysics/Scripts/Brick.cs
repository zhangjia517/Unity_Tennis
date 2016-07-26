using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	private Color stableColor = Color.white;
	private Color impactColor = Color.red;
	
	void Update (){
		if(GetComponent<Rigidbody>().velocity.magnitude>2){
			iTween.ColorTo(gameObject,impactColor,.3f);
		}else{
			iTween.ColorTo(gameObject,stableColor,.3f);
		}
	}
}

