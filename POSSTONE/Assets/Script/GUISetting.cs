using UnityEngine;
using System.Collections;

public class GUISetting : MonoBehaviour {
    public Rect Myposition = new Rect(145, 490, 150, 150);
	public Rect OPposition = new Rect (154, 105, 120, -120);
    public GUISkin Myskin = null;
    public GUISkin Opskin = null;
    public Texture2D  texture= null;
    public string IP = "127.0.0.1";
    public int portNum = 8899;

    private bool hosted = false;
    private bool connected = false;
    private NetworkConnectionError errno;
    private bool failed = false;

    private void OnServerInitialized()
    {
        hosted = true;
    }

    private void OnConnectedToServer()
    {
        connected = true;
    }

    private void OnFailedToConnect(NetworkConnectionError error)
    {
        errno = error;
        failed = true;
    }


    public void OnGUI()
    {


        Myposition.x = Screen.width / 2 - 62;
        OPposition.x = Screen.width / 2 - 64;
        Myposition.y = Screen.height / 2 + 205;
        OPposition.y = Screen.height / 2 - 350;

        if (hosted)
        {
            GUILayout.Label("I made Server !!!!!!!!");
            GUI.skin = Myskin;
            GUI.Button(Myposition, texture);
            GUI.skin = Opskin;
            GUI.Button(OPposition, texture);
        }
        else if (connected)
        {
            
            GUILayout.Label("I Connected to server !!");
            GUI.skin = Myskin;
            GUI.Button(Myposition, texture);
            GUI.skin = Opskin;
            GUI.Button(OPposition, texture);
        }
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
}
