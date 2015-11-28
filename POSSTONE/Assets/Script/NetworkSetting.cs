using UnityEngine;
using System.Collections;

public class NetworkSetting : MonoBehaviour
{

    [RPC]
    void set_turn(bool a)
    {
        GameObject.Find("TurnEndbutton").GetComponent<TurnEndButton>().myturn = a;
    }
}