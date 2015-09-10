using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.Networking;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class LoginManager : Singleton {
	public Text EMail;
	public Text Password;
	public Text Error;
	public String LogURI;

	public String xtoken;
	public String xuser;

	public void SignIn() {
		WWWForm form = new WWWForm();
		form.AddField( "password", Password.text );
		form.AddField( "user", EMail.text );

		new HTTP.Request ("post", LogURI, form).Send (( request) => {
			bool result = false;
			Hashtable resp = (Hashtable)JSON.JsonDecode (request.response.Text, ref result);
			if(result && resp["status"].Equals("success")) {
				xuser = (resp["data"] as Hashtable)["userId"] as String;
				xtoken = (resp["data"] as Hashtable)["authToken"] as String;

				GetSingleton<LevelManager>().LoadLobby();
			} else {
				Error.text = "Something going wrong: check connection and the validity of log/pass.";
			}
		});
	}
}