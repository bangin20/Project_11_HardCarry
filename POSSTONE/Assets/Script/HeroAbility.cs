using UnityEngine;
using System.Collections;

public class HeroAbility : MonoBehaviour {
    public enum HERO{CSE,CITE,PHYS,EE};
    public Material[] HeroMaterial;
    public Material[] PushedHero;

    public HERO Hero = HERO.CSE;
    private int num;

    void Start()
    {
        Hero = HERO.CITE;
        this.GetComponent<Renderer>().material = HeroMaterial[heroToint(Hero)];
    }

    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material = HeroMaterial[heroToint(Hero)];
    }
    private void OnMouseDown()
    {
        this.GetComponent<Renderer>().material = PushedHero[heroToint(Hero)];
    }
    private int heroToint(HERO hero)
    {
        if (hero.Equals(HERO.CSE))
            return 0;
        else if (hero.Equals(HERO.CITE))
            return 1;
        else if (hero.Equals(HERO.PHYS))
            return 2;
        else
            return 3;
    }
}
