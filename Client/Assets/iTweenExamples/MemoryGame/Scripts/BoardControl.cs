using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardControl : MonoBehaviour{
	public static bool wait = true;
	public GUIText levelText;
	
	public AudioClip choiceSound;
	public AudioClip countSound;
	public AudioClip failSound;
	public AudioClip successSound;
	public AudioClip demoSound;
	
	private List<int> sequenceArray = new List<int>();
	private List<GameObject> boxArray;
	private int level;
	private int sequenceAttempt;
	private float delayTime = .5f;
	private bool gamePlaying=true;
	
	public GUIStyle style;
	
	void Awake(){
		boxArray = new List<GameObject>();
		int childId=0;
		foreach (Transform child in transform) {
			boxArray.Add(child.gameObject);
			child.SendMessage("setId",childId);
			childId++;
		}
		StartCoroutine(countDown());
	}
	
	void OnGUI () {
		if(!gamePlaying){
			if(GUI.Button (new Rect (67,178,113,32), "",style)){
				gamePlaying=true;
				StartCoroutine(countDown());
			}
		}
	}
	
	IEnumerator countDown(){
		GetComponent<AudioSource>().pitch=.8f;
		GetComponent<AudioSource>().PlayOneShot(countSound);
		levelText.material.color=Color.red;
		levelText.text="GET READY";
		yield return new WaitForSeconds(2);
		
		GetComponent<AudioSource>().pitch=1;
		GetComponent<AudioSource>().PlayOneShot(countSound);
		levelText.material.color=Color.yellow;
		levelText.text="GET SET";
		yield return new WaitForSeconds(2);
		
		levelText.material.color=Color.white;	
		startGame();
	}
	
	void startGame(){
		level=0;
		sequenceArray = new List<int>();
		addChallenge();
	}
	
	void addChallenge(){
		level++;
		sequenceAttempt=0;
		levelText.text="LEVEL:" + (level+100).ToString().Substring(1,2);
		addSequence();
		StartCoroutine(playSequence());		
		wait=true;
	}
	
	void addSequence() {
		for (int i = 0; i < level; i++) {
			sequenceArray.Add(Random.Range(0,boxArray.Count-1));
		}
	}
	
	IEnumerator playSequence(){
		for (int i = 0; i < level; i++) {
			int boxId = sequenceArray[i];
			boxArray[boxId].SendMessage("depress");
			GetComponent<AudioSource>().pitch=Random.Range(.7f,1);
			GetComponent<AudioSource>().PlayOneShot(demoSound);
			yield return new WaitForSeconds(delayTime);
		}
		wait=false;
	}
	
	void sequenceCheck(int attempt){
		if(sequenceArray[sequenceAttempt]==attempt){
			GetComponent<AudioSource>().pitch=Random.Range(.7f,1);
			GetComponent<AudioSource>().PlayOneShot(choiceSound);
			sequenceAttempt++;
		}else{
			StartCoroutine(gameOver());
		}
		
		if(sequenceAttempt==level){
			StartCoroutine(success());
		}
	}
	
	IEnumerator success(){		
		wait=true;
		yield return new WaitForSeconds(.4f);
		GetComponent<AudioSource>().pitch=Random.Range(.7f,1);
		GetComponent<AudioSource>().PlayOneShot(successSound);
		flash();
		yield return new WaitForSeconds(1.2f);
		addChallenge();
	}
	
	void flash(){
		for (int i = 0; i < boxArray.Count; i++) {
			iTween.ColorTo(boxArray[i],iTween.Hash("r",3,"g",3,"b",3,"time",.3));
			iTween.ColorTo(boxArray[i],iTween.Hash("r",.202,"g",.528,"b",.877,"delay",.5,"time",.3));
		}
	}
	
	IEnumerator gameOver(){
		GetComponent<AudioSource>().pitch=.7f;
		GetComponent<AudioSource>().PlayOneShot(failSound);
		gamePlaying=false;
		wait=true;
		levelText.material.color=Color.red;
		levelText.text="GAME OVER";
		iTween.ShakePosition(gameObject,iTween.Hash("y",-.2,"time",.8));
		for (int i = 0; i < boxArray.Count; i++) {
			iTween.ColorTo(boxArray[i],iTween.Hash("r",1,"time",2));
		}
		yield return new WaitForSeconds(2);
		flash();
	}
}