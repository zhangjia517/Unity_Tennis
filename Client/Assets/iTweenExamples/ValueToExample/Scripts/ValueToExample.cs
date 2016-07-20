using UnityEngine;
using System.Collections;

public class ValueToExample : MonoBehaviour {
	public int score = 0;
	public int bonus = 15;
	public Color initialColor;
	public Vector3 initialScale;
	public GUIText scoreDisplay;
	
	void Awake(){
		initialColor = GetComponent<Renderer>().material.color;
		initialScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
	}
	
	void OnMouseDown(){
		//iTween will ignore additional calls on a gameObject that have all of the same properties so we need to interrupt current iTweens:
		//Remember: iTween follows the "Doesn't Destroy Duplicates" approach.
		iTween.Stop(gameObject);
		
		//increment the score:
		iTween.ValueTo(gameObject,iTween.Hash("from",score,"to",score+bonus,"time",.6,"onUpdate","UpdateScoreDisplay"));
		score+=bonus;
	}	
	
	void OnMouseUp(){
		//reset:
		GetComponent<Renderer>().material.color = initialColor;
		transform.localScale = initialScale;
		
		//visual feedback:
		iTween.ColorFrom(gameObject,new Color(1f,1f,.1f),.3f);
		iTween.ScaleFrom(gameObject,new Vector3(1.5f,initialScale.y,1.5f),.5f);
	}	
	
	void UpdateScoreDisplay(int newScore){
		scoreDisplay.text = "High Score: " + newScore.ToString();
	}
}