using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : ICharacter
{
    [SerializeField]
    private AICharacter opponent;
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
        //myEncounter = encounter;
        opponent = encounter.Enemy;
        Debug.Log("Player taking turn");
       // throw new System.NotImplementedException();
    }

    public void UseAbility(int slot)
    {
        abilities[slot].Cast(this, opponent, myEncounter);
        //encounterUI.GetAbilityName(abilities[slot].Name);
        myEncounter.AdvanceTurns();
    }
}