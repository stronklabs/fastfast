using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;

public class Connector : MonoBehaviour {
    public int ListSize = 10;
    public uint PlayerCountPerRoom = 4;
    public bool Advertise = true;
    public bool OnlyHost = false;

    NetworkManager manager;
    NetworkMatch matcher;
    bool isHost = false;

    void Start() {
        manager = GetComponent<NetworkManager>();
        manager.StartMatchMaker();
        matcher = manager.matchMaker;

        matcher.ListMatches(0, ListSize, "", (matches) => {
            if (matches.success) {
                if (matches.matches.Count > 0 && !OnlyHost) {
                    matcher.JoinMatch(matches.matches[0].networkId, "", (join) => {
                        if (join.success) {
                            Utility.SetAccessTokenForNetwork(join.networkId, new NetworkAccessToken(join.accessTokenString));
                            NetworkClient client = new NetworkClient();
                            client.RegisterHandler(MsgType.Connect, (connected) => {
                                Debug.Log("Connected");
                            });
                            client.Connect(new MatchInfo(join));
                            manager.StartClient();
                        } else {
                            Debug.LogError("Could not join match"); 
                        }
                    });
                } else {
                    matcher.CreateMatch(Random.value.ToString(), PlayerCountPerRoom, Advertise, "", (created) => {
                        if (created.success) {
                            Debug.Log("Create match succeeded");
                            Utility.SetAccessTokenForNetwork(created.networkId, new NetworkAccessToken(created.accessTokenString));
                            NetworkServer.Listen(new MatchInfo(created), 9000);
                            manager.StartHost();
                            isHost = true;
                        } else {
                            Debug.LogError("Could not create match");
                        }
                    });
                }
            } else {
                Debug.LogError("Could not recieve list of matchces");
            }
        });
	}

	void Update () {
	}

    void OnApplicationQuit() {
        if (isHost) {
            manager.StopHost();
        } else {
            manager.StopClient();
        }
    }
}
