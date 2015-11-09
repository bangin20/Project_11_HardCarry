using UnityEngine;
using System.Collections;

public class ChooseHero : HeroAbility {
    private void OnGUI()
    {
        GameObject Myabil = GameObject.Find("MyHero");
        if (GUILayout.Button("CSE"))
        {
            //Hero = HERO.CSE;
            Myabil.GetComponent<Renderer>().material = HeroMaterial[0];
        }
        if (GUILayout.Button("CITE"))
        {
            //Hero = HERO.CITE;
            Myabil.GetComponent<Renderer>().material = HeroMaterial[1];
        }
        if (GUILayout.Button("PHYS"))
        {
            //Hero = HERO.PHYS;
            Myabil.GetComponent<Renderer>().material = HeroMaterial[2];
        }
        if (GUILayout.Button("EE"))
        {
            //Hero = HERO.EE;
            Myabil.GetComponent<Renderer>().material = HeroMaterial[3];
        }
    }
}
