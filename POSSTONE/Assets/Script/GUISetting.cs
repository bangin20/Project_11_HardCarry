using UnityEngine;
using System.Collections;

public class GUISetting : MonoBehaviour {
    public Rect Myposition = new Rect(145, 490, 150, 150);
	public Rect OPposition = new Rect (154, 105, 120, -120);
    public GUISkin skin = null;
    public Texture2D  texture= null;

    public void OnGUI()
    {
        Myposition.x = Screen.width / 2 - 62;
        OPposition.x = Screen.width / 2 - 64;
        Myposition.y = Screen.height / 2 + 205;
        OPposition.y = Screen.height / 2 - 350;

      GUI.skin = skin;
      GUI.Button(Myposition, texture);
	  GUI.Button(OPposition, texture);
    }
}
