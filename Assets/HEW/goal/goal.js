#pragma strict

function OnTriggerEnter (other : Collider) {
	if (other.name == "unitychan_dynamic_locomotion") {
		Application.LoadLevel("goal");
	}
}