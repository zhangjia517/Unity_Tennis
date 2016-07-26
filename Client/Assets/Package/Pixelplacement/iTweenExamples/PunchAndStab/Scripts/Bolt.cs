using UnityEngine;
using System.Collections;

public class Bolt : MonoBehaviour{
	public GameObject ticker1;
	public GameObject ticker2;
	public GameObject ticker3;
	float left = -128.4426f;
	float right = 78.1041f;
	public AudioClip slide;
	public AudioClip impact;
	
	void Start(){
		Move("right");
	}
	
	void Move(string direction){
		if(direction == "right"){
			iTween.ValueTo(gameObject,iTween.Hash("from",left,"to",right,"easetype",iTween.EaseType.easeInExpo,"time",1.4,"delay",.5,"onupdate","ApplySlide","oncomplete","ApplySlam","oncompleteparams","right"));
			iTween.Stab(gameObject,slide,1.1f);
			iTween.Stab(gameObject,impact,1.85f);
		}else{
			iTween.ValueTo(gameObject,iTween.Hash("from",right,"to",left,"easetype",iTween.EaseType.easeInExpo,"time",1.4,"delay",.5,"onupdate","ApplySlide","oncomplete","ApplySlam","oncompleteparams","left"));
			iTween.Stab(gameObject,slide,1.1f);
			iTween.Stab(gameObject,impact,1.85f);
		}
	}
	
	void ApplySlide(float xpos){
		Rect newPixelInset = GetComponent<GUITexture>().pixelInset;
		newPixelInset.x = xpos;
		GetComponent<GUITexture>().pixelInset=newPixelInset;
	}
	
	void ApplySlam(string direction){
		if(direction == "left"){
			Move("right");
			ticker1.SendMessage("Slam",45);
			ticker2.SendMessage("Slam",35);
			ticker3.SendMessage("Slam",25);
			iTween.ShakePosition(Camera.main.gameObject,new Vector3(.4f,0,0),.4f);
		}else{
			Move("left");
			ticker1.SendMessage("Slam",-25);
			ticker2.SendMessage("Slam",-35);
			ticker3.SendMessage("Slam",-45);
			iTween.ShakePosition(Camera.main.gameObject,new Vector3(-.4f,0,0),.4f);
		}
	}
}

