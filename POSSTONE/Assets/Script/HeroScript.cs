using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour {

    enum HERO_TYPE { CSE, CITE, PHYS, EE };

    class Hero
    {
       HERO_TYPE type;
       int HP;
       int atk;
       int MaxHP;

       public int getHP() { return HP; }
       public void setHP(int hp) { HP = hp; }
       public int getAtk() { return atk; }
       public void setAtk(int atk) { this.atk = atk; }
       public int getMaxHP() { return MaxHP; }
       public void setMaxHP(int hp) { MaxHP = hp; }
       public HERO_TYPE getType() { return type; }
       public void setType(HERO_TYPE a) { type = a; }
    }

	// Use this for initialization
	void Start () {
        Hero MyHero = new Hero();
        MyHero.setHP(30);
        MyHero.setMaxHP(30);
        MyHero.setAtk(0);
        MyHero.setType(HERO_TYPE.CSE);
        Material mat;

        if (MyHero.getType() == HERO_TYPE.CSE)
        {
            mat = (Material)Resources.Load("../Material/" + MyHero.getType() + "HeroMaterial.prefab");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else if (MyHero.getType() == HERO_TYPE.CITE)
        {
            mat = (Material)Resources.Load("../Material/" + MyHero.getType() + "HeroMaterial.prefab");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else if (MyHero.getType() == HERO_TYPE.EE)
        {
            mat = (Material)Resources.Load("../Material/" + MyHero.getType() + "HeroMaterial.prefab");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else
        {
            mat = (Material)Resources.Load("../Material/" + MyHero.getType() + "HeroMaterial.prefab");
            gameObject.GetComponent<Renderer>().material = mat;
        }
	}
}
