using UnityEngine;
using System.Collections;

public class NetworkSetting : MonoBehaviour {
    public string IP = "127.0.0.1";
    public int portNum  = 8899;

    private bool hosted = false;
    private bool connected = false;
    private NetworkConnectionError errno;
    private bool failed = false;

    private void OnGUI()
    {
        if (hosted)
            GUILayout.Label("I made Server !!!!!!!!");
        else if (connected)
            GUILayout.Label("I Connected to server !!");
        else if (failed)
            GUILayout.Label("Connection Failed : " + errno);
        else
        {
            IP = GUILayout.TextField(IP);
            int.TryParse(GUILayout.TextField(portNum.ToString()), out portNum);

            if (GUILayout.Button("Connect"))
                Network.Connect(IP, portNum);

            if (GUILayout.Button("Host"))
                Network.InitializeServer(2, portNum, true);
        }
    }
    private void OnServerInitialized()
    {
        hosted = true;
    }
    private void OnConnectedToServer()
    {
        connected = true;
        int rand = Random.Range(-1, 2);
        if (rand == 0)
            GameObject.Find("TurnEndbutton").GetComponent<TurnEndButton>().myturn = false;
        bool test = !(GameObject.Find("TurnEndbutton").GetComponent<TurnEndButton>().myturn);
        //GameObject.Find("TurnEndbutton").GetComponent<NetworkView>().RPC("set_turn", RPCMode.Others,new Object[] {test});
        Debug.Log(test);
    }
    private void OnFailedToConnect(NetworkConnectionError error)
    {
        errno = error;
        failed = true;
    }
    [RPC]
    void set_turn(bool a)
    {
        GameObject.Find("TurnEndbutton").GetComponent<TurnEndButton>().myturn = a;
    }
}
