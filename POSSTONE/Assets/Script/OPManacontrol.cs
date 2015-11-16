using UnityEngine;
using System.Collections;

public class OPManacontrol : MonoBehaviour {
    public int mana = 0;
    public Rect position = new Rect(800, 36, 80, 20);
    public GUIStyle OpManaSkin = null;
    public GUIStyle OpManaout = null;
    public Rect pos2 = new Rect(800,36,80,20);

    void OnGUI()
    {
        GUI.Label(position,mana + " / 10",OpManaSkin);
        GUI.Label(pos2, mana + " / 10", OpManaout);
    }
}
