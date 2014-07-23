using UnityEngine;
using System.Collections;

public class Gauge : MonoBehaviour {
	public GameObject inner;
	public GameObject frame;
	public GameObject back;
	public float x;
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

	}
	
	// Update is called once per frame
	void Update () {
		dispValue = dispValue * 0.95f + nowValue * 0.05f;
		float rate = dispValue / maxValue;
		inner.renderer.material.SetTextureScale ("_MainTex", new Vector2(rate, 1));
		inner.renderer.material.SetTextureOffset ("_MainTex", new Vector2(1.0f - rate, 1));
		inner.transform.localScale = new Vector3(rate, 1.0f, 0.3f);
		inner.transform.localPosition = new Vector3(5.0f - rate * 5.0f, 0, 0);
		transform.LookAt (Camera.main.transform);
		Debug.Log (rate);
		/*
		Debug.Log (Camera.main.transform.position.x + ":"
		           + Camera.main.transform.position.y + ":"
		           + Camera.main.transform.position.z);
		Debug.Log (transform.rotation.x + "" + transform.rotation.y + "" + transform.rotation.z);
		*/
	}

	public void SetNowValue(float value){
		nowValue = value;
		dispValue = nowValue;
	}
}
