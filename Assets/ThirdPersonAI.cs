using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThirdPersonAI : MonoBehaviour
{
    public AI.AIUnit ThisUnit;
    public Transform Target;
    private Moves.NewMove CurrentAbility;
    private float MoveCooldown;
    private UnityStandardAssets.Characters.ThirdPerson.AICharacterControl PBS;
    private void Awake()
    {

    }
    private void Start()
    {
        ThisUnit = SO1.GameMaster.AI.NewAI(AI.Elements.Fire);
        PBS = gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
    }
    private void Update()
    {
        if (CurrentAbility == null)
        {
            CurrentAbility = ThisUnit.Abilities.Where(x=>x.ActiveCooldown <= 0).FirstOrDefault();
        }
        else if(DistFromTarget() <= CurrentAbility.Range && MoveCooldown <= 0)
        {
            CurrentAbility.ActiveCooldown = CurrentAbility.CoolDownTime;
            MoveCooldown = Random.Range(3, 5);
            CurrentAbility.UseMove(this.transform,Target);
            CurrentAbility = null;
        }
        IEnumerable<Moves.NewMove> MovesInCooldown = ThisUnit.Abilities.Where(x => x.ActiveCooldown > 0);
        foreach (Moves.NewMove MIC in MovesInCooldown)
        {
            MIC.ActiveCooldown -= Time.deltaTime;
        }
        if (MoveCooldown > 0)
        {
            MoveCooldown -= Time.deltaTime;
        }
    }
    private float DistFromTarget()
    {
        Target = PBS.target;
        float Dist = Vector3.Distance(transform.position,Target.position);
        return Dist;
    }
}
