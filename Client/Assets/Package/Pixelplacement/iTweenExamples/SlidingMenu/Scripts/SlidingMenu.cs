using UnityEngine;
using System.Collections;

public class SlidingMenu : MonoBehaviour{
	public Texture2D img;
	public Texture2D prevButton;
	public Texture2D nextButton;
	
	private GUIStyle blankStyle = new GUIStyle(); //an "empty" style to avoid any of Unity's default padding, margin and background defaults
	private Rect container = new Rect(0,0,250,211);
	private Rect content = new Rect(0,0,1250,211);
	private float target = 0;
	private float currentSelection;
	
	void OnGUI () {
		//scroll panel:
		GUI.BeginGroup(container);
		GUI.Label(content,img,blankStyle);
		GUI.EndGroup();
			
		//next button:
		if(GUI.Button(new Rect(180,140,70,71),nextButton,blankStyle) && target > -content.width+container.width){
			target-=container.width;
			EstablishSlide();
		}
		
		//prev button:
		if(GUI.Button(new Rect(0,140,70,71),prevButton,blankStyle) && target < 0){
			target+=container.width;
			EstablishSlide();
		}
		
		//select button:
		if(GUI.Button(new Rect(0,0,250,211),"",blankStyle)){
			Selected();
		}
	}
		
	void EstablishSlide(){
		currentSelection=Mathf.Abs(target)/container.width + 1;
		iTween.Stop(gameObject,"value");
		iTween.ValueTo(gameObject,iTween.Hash("time",.8,"from",content.x,"to",target,"easetype",iTween.EaseType.easeInOutExpo,"onupdate","ApplySlide"));
	}
	
	void ApplySlide(float position){
		content.x=position;
	}
	
	void Selected(){
		print("Item: " + currentSelection + " was selected!");
	}
}