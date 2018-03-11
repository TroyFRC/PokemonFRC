using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    private AbstractEnemy enemy;
    private PlayerCombatManager player;
    private int targetGroup;
    private string statusName;
    
    public Status(AbstractEnemy enemy, PlayerCombatManager player, int targetGroup, string statusName)
    {
        this.enemy = enemy;
        this.player = player;
        this.targetGroup = targetGroup;
        this.statusName = statusName;
        applyEffect();
    }

    private void applyEffect()
    {
        
    }
    
    private void delay()
    {
        player.createDelay(1000);
    }
}
