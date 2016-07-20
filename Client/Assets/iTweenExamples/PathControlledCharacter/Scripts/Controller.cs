using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public Transform[] controlPath;
	public Transform character;
	public enum Direction {Forward,Reverse};
	
	private float pathPosition=0;
	private RaycastHit hit;
	private float speed = .2f;
	private float rayLength = 5;
	private Direction characterDirection;
	private Vector3 floorPosition;	
	private float lookAheadAmount = .01f;
	private float ySpeed=0;
	private float gravity=.5f;
	private float jumpForce=.12f;
	private uint jumpState=0; //0=grounded 1=jumping
	
	void OnDrawGizmos(){
		iTween.DrawPath(controlPath,Color.blue);	
	}	
	
	
	void Start(){
		//plop the character pieces in the "Ignore Raycast" layer so we don't have false raycast data:	
		foreach (Transform child in character) {
			child.gameObject.layer=2;
		}
	}
	
	
	void Update(){
		DetectKeys();
		FindFloorAndRotation();
		MoveCharacter();
		MoveCamera();
	}
	
	
	void DetectKeys(){
		//forward path movement:
		if(Input.GetKeyDown("right")){
			characterDirection=Direction.Forward;	
		}
		if(Input.GetKey("right")) {
			pathPosition += Time.deltaTime * speed;
		}
		
		//reverse path movement:
		if(Input.GetKeyDown("left")){
			characterDirection=Direction.Reverse;
		}
		if(Input.GetKey("left")) {
			//handle path loop around since we can't interpolate a path percentage that's negative(well duh):
			float temp = pathPosition - (Time.deltaTime * speed);
			if(temp<0){
				pathPosition=1;	
			}else{
				pathPosition -= (Time.deltaTime * speed);
			}
		}	
		
		//jump:
		if (Input.GetKeyDown("space") && jumpState==0) {
			ySpeed-=jumpForce;
			jumpState=1;
		}
	}
	
	
	void FindFloorAndRotation(){
		float pathPercent = pathPosition%1;
		Vector3 coordinateOnPath = iTween.PointOnPath(controlPath,pathPercent);
		Vector3 lookTarget;
		
		//calculate look data if we aren't going to be looking beyond the extents of the path:
		if(pathPercent-lookAheadAmount>=0 && pathPercent+lookAheadAmount <=1){
			
			//leading or trailing point so we can have something to look at:
			if(characterDirection==Direction.Forward){
				lookTarget = iTween.PointOnPath(controlPath,pathPercent+lookAheadAmount);
			}else{
				lookTarget = iTween.PointOnPath(controlPath,pathPercent-lookAheadAmount);
			}
			
			//look:
			character.LookAt(lookTarget);
			
			//nullify all rotations but y since we just want to look where we are going:
			float yRot = character.eulerAngles.y;
			character.eulerAngles=new Vector3(0,yRot,0);
		}

		if (Physics.Raycast(coordinateOnPath,-Vector3.up,out hit, rayLength)){
			Debug.DrawRay(coordinateOnPath, -Vector3.up * hit.distance);
			floorPosition=hit.point;
		}
	}
	
	
	void MoveCharacter(){
		//add gravity:
		ySpeed += gravity * Time.deltaTime;
		
		//apply gravity:
		character.position=new Vector3(floorPosition.x,character.position.y-ySpeed,floorPosition.z);
		
		//floor checking:
		if(character.position.y<floorPosition.y){
			ySpeed=0;
			jumpState=0;
			character.position=new Vector3(floorPosition.x,floorPosition.y,floorPosition.z);
		}		
	}
	
	
	void MoveCamera(){
		iTween.MoveUpdate(Camera.main.gameObject,new Vector3(character.position.x,2.7f,character.position.z-5f),.9f);	
	}
}