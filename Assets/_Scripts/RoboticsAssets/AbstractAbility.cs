using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAbility : MonoBehaviour {

    private int duration;
    private int damage;
    private int healing;
    private AbstractEnemy enemy;
    private Status status;

    public AbstractAbility(int duration, int damage, int healing, AbstractEnemy enemy, Status status)
    {
        this.duration = duration;
        this.damage = damage;
        this.healing = healing;
        this.enemy = enemy;
        this.status = status;
    }

    public void reduceDuration()
    {
        duration--;
    }

    public int getDuration()
    {
        return duration;
    }

    public abstract void useAbility();
}
