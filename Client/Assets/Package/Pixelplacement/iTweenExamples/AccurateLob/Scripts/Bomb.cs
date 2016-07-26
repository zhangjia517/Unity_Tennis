using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
	public GameObject core;
	float lobHeight = 4;
	float lobTime = .7f;
	public Vector3 targetPosition;
	
	void Start(){
		iTween.MoveBy(core, iTween.Hash("y", lobHeight, "time", lobTime/2, "easeType", iTween.EaseType.easeOutQuad));
		iTween.MoveBy(core, iTween.Hash("y", -lobHeight, "time", lobTime/2, "delay", lobTime/2, "easeType", iTween.EaseType.easeInCubic));     
		iTween.MoveTo(gameObject, iTween.Hash("position", targetPosition, "time", lobTime, "easeType", iTween.EaseType.linear));
		iTween.FadeTo(gameObject, iTween.Hash("delay", 3, "time", .5, "alpha", 0, "onComplete", "CleanUp"));
	}
	
	void CleanUp(){
		Destroy(gameObject);	
	}
}

