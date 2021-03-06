using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICharacter : ICharacter
{
    [SerializeField]
    private PlayerCharacter player;
    [SerializeField]
    private EncounterInstance myEncounter;

    private void Start()
    {
        myEncounter = GetComponentInParent<EncounterInstance>();
        characterManaSlider = transform.GetChild(0).gameObject.GetComponent<Slider>();
        characterHealthSlider = transform.GetChild(1).gameObject.GetComponent<Slider>();

        HealthBarText = characterHealthSlider.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        ManaBarText = characterManaSlider.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    public override void TakeTurn(EncounterInstance encounter)
    {
        myEncounter = encounter;
        player = encounter.Player;
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

        if(mana > 24 || pHealth > 24)
        {
            UseAbility(Random.Range(0, abilities.Count - 1), encounter);
        }
        else if(pHealth < 24 || mana < 24)
        {
            // Uses rest ability when mana or health is low
            UseAbility(3, encounter);
        }

        encounter.AdvanceTurns();
    }

    public void UseAbility(int slot, EncounterInstance EN)
    {
        abilities[slot].Cast(this, player, EN);
    }

}
