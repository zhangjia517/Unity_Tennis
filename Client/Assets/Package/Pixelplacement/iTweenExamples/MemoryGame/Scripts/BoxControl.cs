using UnityEngine;
using System.Collections;

public class BoxControl : MonoBehaviour{
	public Color depressColor;
	
	Color startColor;
	float depressAmount = .3f;
	float travelTime =.2f;
	float startY;
	float destinationY;
	GameObject go;
	int id;
	
	void Awake(){
		go=gameObject;
		startY = gameObject.transform.position.y;
		destinationY = startY - depressAmount;
		startColor=GetComponent<Renderer>().material.color;
	}
	
	void OnMouseDown () {
		if(!BoardControl.wait){
			depress();
			gameObject.SendMessageUpwards ("sequenceCheck", id);
		}
	}
	
	void depress(){
		iTween.Stop(go);
		GetComponent<Renderer>().material.color = depressColor;
		iTween.ColorTo(go,iTween.Hash("color",startColor,"time",travelTime*2,"delay",travelTime));
		iTween.MoveTo(go,iTween.Hash("y",destinationY,"transition","easeOutCubic","time",travelTime));
		iTween.MoveTo(go,iTween.Hash("y",startY,"transition","easeInCubic","time",travelTime,"delay",travelTime));
	}
	
	void setId(int id){
		this.id=id;
	}
}

