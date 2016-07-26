using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour{
	//guitextures:
	public GameObject onePlayerButton;
	public GameObject splatTexture;
	public GameObject titleText;
	public GameObject titleTextBlock;
	public GameObject twoPlayerButton;
	public GameObject presentationScreen;
	public Texture2D blackScreen;
	
	//Demonstrate how to animate GUITextures through their connected GameObject 
	//You could animate each GUITexture's Pixel Inset rect through iTween's ValueTo as well but this way is easier:
	void OnEnable(){
		//In:
		iTween.ColorFrom(splatTexture,iTween.Hash("color",new Color(1,1,0,0)));
		iTween.ScaleFrom(splatTexture,iTween.Hash("scale",new Vector3(2,2,0),"time",.6));
		iTween.FadeFrom(titleTextBlock,iTween.Hash("alpha",0,"time",.8,"delay",.4));
		iTween.MoveFrom(titleText,iTween.Hash("x",-.8,"time",.8,"delay",.4));
		iTween.MoveFrom(onePlayerButton,iTween.Hash("y",-.5,"delay",1.4));
		iTween.MoveFrom(twoPlayerButton,iTween.Hash("y",-.5,"delay",1.5));
	}
	
	IEnumerator SwitchToPresentationScreen(){
		iTween.CameraFadeAdd(blackScreen,99);
		iTween.CameraFadeTo(1,2);
		yield return new WaitForSeconds(2);
		iTween.CameraFadeDestroy();
		gameObject.SetActive(false);
		presentationScreen.SetActive(true);
	}
	
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			StartCoroutine(SwitchToPresentationScreen());
		}
	}
}