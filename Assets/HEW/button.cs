using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

	public void OnClick() {
		Debug.Log("Button click!");
		// 非表示にする
		gameObject.SetActive(false);

		Application.LoadLevel("Locomotion");
	}
}