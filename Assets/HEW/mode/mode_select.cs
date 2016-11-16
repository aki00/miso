using UnityEngine;
using System.Collections;

public class mode_select : MonoBehaviour {
	public void traning_btn_click() {
		Debug.Log("traning Button click!");
		// 非表示にする
		gameObject.SetActive(false);

		Application.LoadLevel("pacemaker_select");
	}
	public void running_btn_click() {
		Debug.Log("running Button click!");
		// 非表示にする
		gameObject.SetActive(false);

		Application.LoadLevel("pacemaker_select");
	}
}
