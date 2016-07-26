using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour
{
	void Start (){
		GetComponent<Rigidbody>().useGravity=false;
		GetComponent<Rigidbody>().isKinematic=true;
		iTween.RotateTo(gameObject,iTween.Hash("y",-30,"time",.7,"delay",1,"easetype",iTween.EaseType.easeInOutSine));
		iTween.RotateTo(gameObject,iTween.Hash("y",60,"z",-30,"time",.4,"delay",2,"easetype",iTween.EaseType.spring));
	}
}

