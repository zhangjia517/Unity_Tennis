using UnityEngine;
using System.Collections;

public class AnimatingUnityGUI : MonoBehaviour{
	public bool buttonState = false;	
	public Rect button  = new Rect(75,20,100,55); //holds actual button rect coordinates
	public Rect initialPosition = new Rect(75,20,100,55); //holds starting rect coordinates
	public Rect activePosition = new Rect(75,130,100,55); //holds ending rect coordinates
	
	void OnGUI(){
		if(GUI.Button(button,"Click Me!")){
			
			if(buttonState){
				iTween.ValueTo(gameObject,iTween.Hash("from",button,"to",initialPosition,"onupdate","MoveButton","easetype","easeinoutback"));	
			}else{
				iTween.ValueTo(gameObject,iTween.Hash("from",button,"to",activePosition,"onupdate","MoveButton","easetype","easeinoutback"));
			}
			buttonState = !buttonState;
		}
	}
	
	void MoveButton(Rect newCoordinates){
		button=newCoordinates;
	}
}

