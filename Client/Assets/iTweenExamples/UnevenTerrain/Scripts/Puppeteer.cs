using UnityEngine;
using System.Collections;

public class Puppeteer : MonoBehaviour
{
	public Transform character;
	public Transform arrow; 
	
	void Start(){
		Cursor.visible=false;
	}
	
	void Update (){
		PlaceArrow();
		PlaceCharacter();
		if(Input.GetMouseButton(0)){
			iTween.MoveTo(gameObject,new Vector3(arrow.position.x,arrow.position.y+5,arrow.position.z),2);
		}
	}
	
	void PlaceArrow(){
		RaycastHit hit = new RaycastHit();
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay (cameraRay.origin, cameraRay.direction * 100);
		if (Physics.Raycast (cameraRay.origin,cameraRay.direction,out hit, 100)) {
			iTween.MoveUpdate(arrow.gameObject,hit.point,.9f);
		}	
	}
	
	void PlaceCharacter(){
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (transform.position,Vector3.down,out hit, 10)) {
			character.position=hit.point;
		}		
	}
}

