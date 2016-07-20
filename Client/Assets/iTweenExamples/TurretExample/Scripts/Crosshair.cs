using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour{
	void Update(){	
		Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.transform.position.y);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
		iTween.MoveUpdate(gameObject,iTween.Hash("position",worldPos,"time",.6));
	}
}