using UnityEngine;
using System.Collections;

public class GameBoardCSharp : MonoBehaviour
{	
	GameObject currentTarget=null;
	GameObject ball;
	public int rate = 10;
	public bool ballSet = true;
	
	void Start ()
	{
		CreateGameBoard(9,9);
		ball = (GameObject)Instantiate((GameObject)Resources.Load("GameBall"),new Vector3(0,.5f,0),Quaternion.identity);
	}
	
	void SetTarget(GameObject target){
		if(currentTarget != null && target!=currentTarget){
			currentTarget.SendMessage("Deactivate");
		}
		currentTarget=target;
		ballSet=false;
		float travelTime = Vector3.Distance(ball.transform.position, target.transform.position)/rate;
		iTween.MoveBy(ball,iTween.Hash("x",target.transform.position.x-ball.transform.position.x,"easetype","easeinoutsine","time",travelTime));
		iTween.MoveBy(ball,iTween.Hash("z",target.transform.position.z-ball.transform.position.z,"time",travelTime,"delay",travelTime,"easetype","easeinoutsine","oncomplete","Reset","oncompletetarget",gameObject));
	}
	
	void Reset(){
		ballSet=true;
	}
		
	void CreateGameBoard(uint cols, uint rows){
		GameObject block = (GameObject)Resources.Load("GamePieceCSharp");
		
		for (int i = 0; i < cols; i++) {
			for (int j = 0; j < rows; j++) {
				GameObject newBlock = (GameObject)Instantiate(block,new Vector3(i,0,j),Quaternion.identity);
				newBlock.name="Block: " + i + "," + j;
				newBlock.SendMessage("SetGameboard",this);
				Color blockColor;
				if((j+i)%2 == 0){
					blockColor=Color.black;
				}else{
					blockColor=Color.white;
				}
				newBlock.GetComponent<Renderer>().material.color=blockColor;
				newBlock.transform.parent=transform;
			}
		}
		transform.position= new Vector3(-cols/2,0,-rows/2);
	}
}

