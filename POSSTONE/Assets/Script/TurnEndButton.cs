using UnityEngine;
using System.Collections;

public class TurnEndButton : MonoBehaviour {
    public Material[] TurnMat;
    public bool myturn = true;
    public int turn;

    public Material[] ManaStatus;

    void start()
    {
        turn = 2;
    }

    private void OnMouseEnter()
    {
        if(myturn)
            this.GetComponent<Renderer>().material = TurnMat[1];
    }
    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material = TurnMat[0];
    }

    private void OnMouseDown()
    {
        if (myturn)
        {
            this.GetComponent<Renderer>().material = TurnMat[2];
            myturn = false;
            gameObject.GetComponent<NetworkView>().RPC("addMana", RPCMode.Others, turn);
            turn++;
            // socket send message
        }
    }

    [RPC]
    void addMana(int mana)
    {
        for (int i = 1; i <= mana; i++)
        {
            myturn = true;
            GameObject Mana = GameObject.Find("manacost" + i.ToString());
            Mana.GetComponent<Renderer>().material = ManaStatus[1];
        }
    }
    void set_turn(bool a)
    {
        myturn = a;
    }
}