using UnityEngine;
using System.Collections;

public class FlythroughCameraController : MonoBehaviour {
	public Transform[] movePath;
	public Transform[] lookPath;
	public Transform lookTarget;
	public float percentage;
	
	private float redPosition = .16f;
	private float bluePosition = .53f;
	private float greenPosition = 1;
	
	//gui styling
	public Font font;
	private GUIStyle style = new GUIStyle();
	
	void Start(){
		style.font=font;
	}
		
	void OnGUI(){
		percentage=GUI.VerticalSlider(new Rect(Screen.width-20,20,15,Screen.height-40),percentage,1,0);
		iTween.PutOnPath(gameObject,movePath,percentage);
		iTween.PutOnPath(lookTarget,lookPath,percentage);
		transform.LookAt(iTween.PointOnPath(lookPath,percentage));
		//
		if(GUI.Button(new Rect(5,Screen.height-25,50,20),"Red")){
			SlideTo(redPosition);
		}
		if(GUI.Button(new Rect(60,Screen.height-25,50,20),"Blue")){
			SlideTo(bluePosition);
		}
		if(GUI.Button(new Rect(115,Screen.height-25,50,20),"Green")){
			SlideTo(greenPosition);
		}
	}
	
	void OnDrawGizmos(){
		iTween.DrawPath(movePath,Color.magenta);
		iTween.DrawPath(lookPath,Color.cyan);
		Gizmos.color=Color.black;
		Gizmos.DrawLine(transform.position,lookTarget.position);
	}
	
	void SlideTo(float position){
		iTween.Stop(gameObject);
		iTween.ValueTo(gameObject,iTween.Hash("from",percentage,"to",position,"time",2,"easetype",iTween.EaseType.easeInOutCubic,"onupdate","SlidePercentage"));	
	}
	
	void SlidePercentage(float p){
		percentage=p;
	}
}
