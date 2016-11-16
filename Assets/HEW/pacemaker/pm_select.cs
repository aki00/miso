using UnityEngine;
using System.Collections;

public class pm_select : MonoBehaviour {
	
	//chara１
	public void ButtonClick1(string ima1) {
		Debug.Log("chara1 click!");
		// 非表示にする
		gameObject.SetActive(false);

		Application.LoadLevel("course");
	}
	//chara２
	public void ButtonClick2(string ima2) {
		Debug.Log("chara2 click!");
		// 非表示にする
		gameObject.SetActive(false);

		Application.LoadLevel("course");
	}
	//chara３
	public void ButtonClick3(string ima3) {
		Debug.Log("chara3 click!");
		// 非表示にする
		gameObject.SetActive(false);

		Application.LoadLevel("course");
	}
	//none chara
	public void ButtonClick3(string none_btn) {
		Debug.Log("none chara click!");
		// 非表示にする
		gameObject.SetActive(false);

		Application.LoadLevel("course");
	}
}
