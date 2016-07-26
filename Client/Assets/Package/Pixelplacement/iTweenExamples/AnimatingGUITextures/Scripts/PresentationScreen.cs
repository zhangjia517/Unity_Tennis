using UnityEngine;
using System.Collections;

public class PresentationScreen : MonoBehaviour{
	public GameObject iTweenLogoGT;
	public GameObject presentsTextGT;
	public GameObject whiteDiagonalGradient;
	public GameObject titleScreen;
	
	//Demonstrate how to animate GUITextures through their connected GameObject 
	//You could animate each GUITexture's Pixel Inset rect through iTween's ValueTo as well but this way is easier:
	void OnEnable(){
		//Reset (only needed since this example loops):
		iTweenLogoGT.transform.position=new Vector3(.5f,.5f,.5f);
		presentsTextGT.transform.position=new Vector3(.5f,.5f,.5f);
		whiteDiagonalGradient.GetComponent<GUITexture>().color=new Color(.5f,.5f,.5f,.5f);
		
		//In:
		iTween.FadeFrom(whiteDiagonalGradient,iTween.Hash("alpha",0,"time",.6,"delay",1));
		iTween.MoveFrom(whiteDiagonalGradient,iTween.Hash("position",new Vector3(1.3f,1.3f,0),"time",.6,"delay",1));
		iTween.MoveFrom(iTweenLogoGT,iTween.Hash("x",-.4,"time",.6,"delay",1.2));
		iTween.MoveFrom(presentsTextGT,iTween.Hash("x",1.2,"time",.6,"delay",1.4));
		
		//Out:	
		iTween.MoveTo(presentsTextGT,iTween.Hash("x",-.2,"time",.6,"delay",2.5,"easetype","easeincubic"));
		iTween.MoveTo(iTweenLogoGT,iTween.Hash("x",1.5,"time",.6,"delay",2.6,"easetype","easeincubic"));
		iTween.FadeTo(whiteDiagonalGradient,iTween.Hash("alpha",0,"time",.6,"delay",2.8,"easetype","easeincubic","oncomplete","SwitchToTitleScreen","oncompletetarget",gameObject));
	}
	
	void SwitchToTitleScreen(){
		gameObject.SetActive(false);
		titleScreen.SetActive(true);
	}
}

