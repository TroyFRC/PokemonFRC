using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstractEnemy : MonoBehaviour {
    private int MAXhp;
    private int MAXmana;
    private int currentHP;
    private int currentMANA;
    private int damage;
    private int count;
    public AbstractEnemy(int HP, int MANA)
    {
        MAXhp = HP;
        MAXmana = MANA;
        currentHP = HP;
        currentMANA = MANA;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
                int chance = 0;
        System.Random rand = new System.Random();
        chance = rand.Next();
        count++;
        if(currentMANA > 0 && (count+ chance)%2 == 0 && currentMANA > 0)
        {
            blocking(damage);//change this value later
        }
		
	}

    public void takeDamage(int damage)
    {
        currentHP -= damage;
    }

    public abstract void takeStatus(string type);

    public abstract void useAbilityOne(int mana);

    public abstract void useAbilityTwo(int mana);

    public abstract void useAbilityThree(int mana);

    public abstract void useAbilityFour(int mana);

    public abstract int returnDamage();

    private void blocking(int dmg)
    {
        dmg -= currentMANA;
        currentMANA -= dmg;
        if (damage > 0)
        {
            currentMANA -= dmg;
            //currentHP -= Math.Abs(dmg - currentMANA);
        }
    }
}
