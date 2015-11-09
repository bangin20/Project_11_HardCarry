using UnityEngine;
using System.Collections;

public class TurnEndButton : MonoBehaviour {
    public Material[] TurnMat;
    private int turn;

    public Material[] ManaStatus;

    void Start()
    {
        turn = 2;
    }

    private void OnMouseEnter()
    {
        this.GetComponent<Renderer>().material = TurnMat[1];
    }
    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material = TurnMat[0];
    }
    
    private void OnMouseDown()
    {
        this.GetComponent<Renderer>().material = TurnMat[2];
        // socket send message
        GameObject mana = GameObject.Find("Manacost" + turn.ToString());
        mana.GetComponent<Renderer>().material = ManaStatus[1];
        if(turn != 10)
            turn++;
    }
}
