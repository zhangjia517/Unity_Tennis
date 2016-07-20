private var stableColor : Color = Color.white;
private var impactColor : Color = Color.red;

function Update (){
	if(GetComponent.<Rigidbody>().velocity.magnitude>2){
		iTween.ColorTo(gameObject,impactColor,.3);
	}else{
		iTween.ColorTo(gameObject,stableColor,.3);
	}
}
