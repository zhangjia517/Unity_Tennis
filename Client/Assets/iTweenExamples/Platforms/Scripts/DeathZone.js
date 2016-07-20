public var deathFlash : Texture2D ;

function Start(){
	iTween.CameraFadeAdd(deathFlash,100);	
}

function OnTriggerEnter(other:Collider){
	iTween.CameraFadeTo(iTween.Hash("amount",.6,"time",.05));
	iTween.CameraFadeTo(iTween.Hash("amount",0,"time",1.6,"delay",.05,"easetype","linear"));
	other.GetComponent.<Rigidbody>().Sleep();
	other.transform.position=new Vector3(0,8,0);
	other.GetComponent.<Rigidbody>().velocity=Vector3.zero;
	other.GetComponent.<Rigidbody>().WakeUp();
}
