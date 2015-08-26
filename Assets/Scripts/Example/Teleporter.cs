using UnityEngine;
using UObject = UnityEngine.Object;
using GObject = UnityEngine.GameObject;
using URandom = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.Networking;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : ExtBehaviour {
	void Start () {
	}

	void Update () {
		transform.position += new Vector3 (
			Input.GetAxis ("Horizontal")*0.1f,
			Input.GetAxis ("Vertical")*0.1f
		);
	}

	public void Teleport(GameObject collider) {
		Debug.Log (collider + " collided with " + this);
		transform.position = new Vector3 ();
	}
}
