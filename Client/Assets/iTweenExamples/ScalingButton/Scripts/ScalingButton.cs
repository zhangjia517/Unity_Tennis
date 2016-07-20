using UnityEngine;
using System.Collections;

public class ScalingButton : MonoBehaviour {
	bool buttonStatus;
	Rect currentButton;
	public Vector2 buttonNormalSize = new Vector2(100,50);
	public Vector2 buttonHoverSize = new Vector2(200,70);
	Vector2 buttonPosition = new Vector2(250/2,211/2);
	
	void Start(){
		//set starting button rect:
		currentButton.x=buttonPosition.x-(buttonNormalSize.x/2);
		currentButton.y=buttonPosition.y-(buttonNormalSize.y/2);
		currentButton.width=buttonNormalSize.x;
		currentButton.height=buttonNormalSize.y;
	}
	
	void OnGUI(){
		//the actual button:
		GUI.Button(currentButton,"Click Me!");
		
		//on mouse over:
		if(OnMouseOver(currentButton) && !buttonStatus){
			iTween.Stop(gameObject,"value");
			buttonStatus=true;
			iTween.ValueTo(gameObject,iTween.Hash("from",CurrentButtonSize(),"to",buttonHoverSize,"easetype",iTween.EaseType.easeOutBack,"onupdate","ScaleButton","time",.2));
		}
		
		//on mouse out:
		if (!OnMouseOver(currentButton) && buttonStatus) {
			iTween.Stop(gameObject,"value");
			buttonStatus=false;
			iTween.ValueTo(gameObject,iTween.Hash("from",CurrentButtonSize(),"to",buttonNormalSize,"easetype",iTween.EaseType.easeOutExpo,"onupdate","ScaleButton","time",.4));
		}
	}
	
	//grabs current rect of button:
	Vector2 CurrentButtonSize(){
		return new Vector2(currentButton.width,currentButton.height);	
	}
	
	//checks if the mouse is over the button:
	bool OnMouseOver(Rect buttonRect){
		if(buttonRect.Contains(Event.current.mousePosition)){
			return true;
		}else{
			return false;
		}		
	}
			
	//applies the values from iTween:
	void ScaleButton(Vector2 size){
		currentButton.width=size.x;
		currentButton.height=size.y;
		currentButton.x=buttonPosition.x - (currentButton.width/2);
		currentButton.y=buttonPosition.y - (currentButton.height/2);
	}
}
