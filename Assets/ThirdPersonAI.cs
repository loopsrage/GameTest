using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAI : MonoBehaviour
{
    private SO1 newSO1;
    public AI.AIUnit ThisUnit;
    public Transform Target;
    private Moves.NewMove CurrentAbility;
    private UnityStandardAssets.Characters.ThirdPerson.AICharacterControl PBS;
    private void Awake()
    {
        ThisUnit = SO1.GameMaster.AI.NewAI(AI.Elements.Fire);
        PBS = gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (CurrentAbility == null)
        {
            CurrentAbility = ThisUnit.Abilities[Random.Range(0, ThisUnit.Abilities.Count)];
        }
        else if(DistFromTarget() <= CurrentAbility.Range)
        {
            CurrentAbility.UseMove();
            CurrentAbility = null;
        }
    }
    private float DistFromTarget()
    {
        Target = PBS.target;
        float Dist = Vector3.Distance(transform.position,Target.position);
        return Dist;
    }
}
