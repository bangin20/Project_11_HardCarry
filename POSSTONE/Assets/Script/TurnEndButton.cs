using UnityEngine;
using System.Collections;

public class TurnEndButton : MonoBehaviour {
    public Material[] TurnMat;
    public bool myturn = true;
    int turn = 1;

    private void OnConnectedToServer()
    {
        int rand = Random.Range(-1, 2);
        if (rand == 0)
           myturn = false;
        this.GetComponent<NetworkView>().RPC("setTurn", RPCMode.Others,!myturn);
        turn = 1;

        for (int i = 2; i <= 10; i++)
        {
            GameObject invisible_mana = GameObject.Find("manacost" + i);
            Color manaColor = invisible_mana.GetComponent<Renderer>().material.color;
            manaColor.a = 0;
            invisible_mana.GetComponent<Renderer>().material.color = manaColor;
        }
    }

    private void OnServerInitialized()
    {
        turn = 1;
        for (int i = 2; i <= 10; i++)
        {
            GameObject invisible_mana = GameObject.Find("manacost" + i);
            Color manaColor = invisible_mana.GetComponent<Renderer>().material.color;
            manaColor.a = 0;
            invisible_mana.GetComponent<Renderer>().material.color = manaColor;
        }
    }

    public Material[] ManaStatus;

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
            myturn = !myturn;
            this.GetComponent<NetworkView>().RPC("setTurn", RPCMode.Others,!myturn);
            if(turn <= 10)
                this.GetComponent<NetworkView>().RPC("TurnEnd", RPCMode.Others);
            // socket send message
        }
    }
    [RPC]
    void setTurn(bool b)
    {
        myturn = b;
    }
    [RPC]
    void TurnEnd()
    {
           turn++;
            string manaTime = "manacost" + turn;
            Debug.Log(manaTime);
            GameObject m = GameObject.Find(manaTime);

            Color manaColor = m.GetComponent<Renderer>().material.color;
            manaColor.a = 1.0f;
            m.GetComponent<Renderer>().material.color = manaColor;

            m.GetComponent<Renderer>().material = ManaStatus[1];
    }
}