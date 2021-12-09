using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : ICharacter
{
    public float mana = 100;
    public override void TakeTurn(EncounterInstance encounter)
    {
        StartCoroutine(DelayDecision(encounter));

        //have ai choose what to do here
        // do ability
        //subscribe to on ability finished event
        //Debug.Log("AI took turn");
        //if (mana > 24)
        //{
        //    mana -= 25;
        //    UseAbility(Random.Range(0, abilities.Length), this, encounter.Player);
        //}
    }

    IEnumerator DelayDecision(EncounterInstance encounter)
    {
        //Choose what action to do!
        Debug.Log("Enemy taking turn");
        yield return new WaitForSeconds(3.0f);
        encounter.AdvanceTurns();
    }

}