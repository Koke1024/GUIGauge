using UnityEngine;
using System.Collections;

public class GUIGauge : MonoBehaviour {
	public GameObject inner;
	public GameObject frame;
	public GameObject back;
	public Vector3 worldPosition;
	public float scale = 1;
	float height = 100.0f;
	float width = 360.0f;
	
	public GameObject point;
	float nowValue;
	float dispValue;
	float maxValue;
	
	public void Init(float _maxValue, float _nowValue){
		maxValue = _maxValue;
		nowValue = _nowValue;
		dispValue = nowValue;
	}
	

	// Use this for initialization
	void Start () {
		Destroy (point);
	}
	
	// Update is called once per frame
	void Update () {
		dispValue = dispValue * 0.95f + nowValue * 0.05f;
		float rate = dispValue / maxValue;
		if (rate < 0.01f) {
			inner.guiTexture.enabled = false;
		}
		else{
			inner.guiTexture.enabled = true;
		}
		inner.guiTexture.pixelInset = new Rect(
			- width / 2.0f * scale, - height / 2.0f * scale,
			width * rate * scale, height * scale);
		frame.guiTexture.pixelInset = new Rect(
			- width / 2.0f * scale, - height / 2.0f * scale,
			width * scale, height * scale);
		back.guiTexture.pixelInset = new Rect(
			- width / 2.0f * scale, - height / 2.0f * scale,
			width * scale, height * scale);
		Vector3 tempPos = Camera.main.WorldToScreenPoint (worldPosition);
		
		transform.position = new Vector3(tempPos.x / Screen.width, tempPos.y / Screen.height, 0);
	}
	
	public void SetPosition(Vector3 pos){
		worldPosition = pos;
	}
	
	public void SetNowValue(float value){
		nowValue = value;
	}
	
	public void SetColor(Color color){
		inner.guiTexture.color = color;
	}
}
