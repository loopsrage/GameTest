using UnityEngine;
using System.Collections;

public class Moves : ScriptableObject
{
    public enum Effects
    {
        Burn,
        Paralyze,
        Bleeding,
        Concussion,
        Drowning
    }
    public int CalculateDamage(AI.Elements MT)
    {
        int Damage;
        switch (MT)
        {
            case AI.Elements.Fire:
                // Medium Damage, Burn
                Damage = Random.Range(20, 50);
                break;
            case AI.Elements.Water:
                // Little Damage, increased Damage if already Drowning
                Damage = Random.Range(5, 20);
                break;
            case AI.Elements.Electric:
                // More Accurate, Less Damage
                Damage = Random.Range(10, 30);
                break;
            case AI.Elements.Nature:
                // More DOT, Not very Accurate
                Damage = Random.Range(10, 20);
                break;
            case AI.Elements.Rock:
                // Most Damage
                Damage = Random.Range(20, 70);
                break;
            default:
                // Shouldn't hit this case
                Damage = Random.Range(0, 0);
                break;
        }
        return Damage;
    }
    public Effects GetEffect(AI.Elements MT)
    {
        Effects ReturnEffect;
        switch (MT)
        {
            case AI.Elements.Fire:
                ReturnEffect = Effects.Burn;
                break;
            case AI.Elements.Water:
                ReturnEffect = Effects.Drowning;
                break;
            case AI.Elements.Electric:
                ReturnEffect = Effects.Paralyze;
                break;
            case AI.Elements.Nature:
                ReturnEffect = Effects.Bleeding;
                break;
            case AI.Elements.Rock:
                ReturnEffect = Effects.Concussion;
                break;
            default:
                // Shouldn't hit this case
                ReturnEffect = Effects.Burn;
                break;
        }
        return ReturnEffect;
    }
    public int getRange(AI.Elements MT)
    {
        int Range;
        switch (MT)
        {
            case AI.Elements.Fire:
                // Low Range
                Range = Random.Range(2, 10);
                break;
            case AI.Elements.Water:
                // Low Range
                Range = Random.Range(0, 3);
                break;
            case AI.Elements.Electric:
                // High Range
                Range = Random.Range(5, 10);
                break;
            case AI.Elements.Nature:
                // Medium Range
                Range = Random.Range(3, 7);
                break;
            case AI.Elements.Rock:
                // Long Range
                Range = Random.Range(0, 10);
                break;
            default:
                // Shouldn't hit this case
                Range = Random.Range(0, 0);
                break;
        }
        return Range;
    }
    public int getAccuracy(int R, AI.Elements MT)
    {
        int Accuracy;
        int BaseAccuracy;
        switch (MT)
        {
            case AI.Elements.Fire:
                // Medium Accuracy
                BaseAccuracy = Random.Range(3, 7);
                Accuracy = Mathf.Abs((R - BaseAccuracy) % 100);
                break;
            case AI.Elements.Water:
                // Medium Accuracy
                BaseAccuracy = Random.Range(3, 7);
                Accuracy = Mathf.Abs((R - BaseAccuracy) % 100);
                break;
            case AI.Elements.Electric:
                // High Accuracy
                BaseAccuracy = Random.Range(7, 10);
                Accuracy = Mathf.Abs((R - BaseAccuracy) % 100);
                break;
            case AI.Elements.Nature:
                // Low Accuracy
                BaseAccuracy = Random.Range(0, 5);
                Accuracy = Mathf.Abs((R - BaseAccuracy) % 100);
                break;
            case AI.Elements.Rock:
                // Low Accuracy
                BaseAccuracy = Random.Range(0, 5);
                Accuracy = Mathf.Abs((R - BaseAccuracy) % 100);
                break;
            default:
                // Shouldn't hit this case
                BaseAccuracy = Random.Range(0, 0);
                Accuracy = Mathf.Abs((R - BaseAccuracy) % 100);
                break;
        }
        return Accuracy;
    }
    public int getEffectChance(int R, int D, AI.Elements MT, int A)
    {
        int effectChance;
        int BaseChance;
        switch (MT)
        {
            case AI.Elements.Fire:
                // high effect chance
                BaseChance = Random.Range(7, 10);
                effectChance = (R + D + A + BaseChance) / 4;
                break;
            case AI.Elements.Water:
                // medium effect chance
                BaseChance = Random.Range(4, 7);
                effectChance = (R + D + A + BaseChance) / 4;
                break;
            case AI.Elements.Electric:
                // low effect chance
                BaseChance = Random.Range(0, 5);
                effectChance = (R + D + A + BaseChance) / 4;
                break;
            case AI.Elements.Nature:
                // medium effect chance
                BaseChance = Random.Range(4, 7);
                effectChance = (R + D + A + BaseChance) / 4;
                break;
            case AI.Elements.Rock:
                // high effect chance
                BaseChance = Random.Range(7, 10);
                effectChance = (R + D + A + BaseChance) / 4;
                break;
            default:
                // shouldn't hit this case
                BaseChance = Random.Range(0, 0);
                effectChance = 0;
                break;
        }
        return effectChance;
    }
    public int getCooldown(int D)
    {
        int CoolDown;
        if (D <= 5 && D >= 1)
        {
            CoolDown = 5;
        }
        else
        {
            CoolDown = 10;
        }
        return CoolDown;
    }
    public class NewMove
    {
        public AI.Elements MoveType; // Set by AI type
        public Moves.Effects Effect; // Set by MoveType
        public string MoveName; // Set by Random
        public int Damage; // Calculated by MoveType
        public int Range; // Set by Move Type
        public int EffectChance; // Set by Range, Damage, Move type and Accuracy
        public int Accuracy; // Set by Range, Move type
        public int CoolDownTime;
        public float ActiveCooldown;
        public Moves MoveMaker = ScriptableObject.CreateInstance<Moves>();
        public NewMove(AI.Elements MT)
        {
            MoveType = MT;
            Effect = MoveMaker.GetEffect(MT);
            Damage = MoveMaker.CalculateDamage(MT);
            Range = MoveMaker.getRange(MT);
            Accuracy = MoveMaker.getAccuracy(Range, MT);
            EffectChance = MoveMaker.getEffectChance(Range, Damage, MT, Accuracy);
            CoolDownTime = MoveMaker.getCooldown(Damage);
        }
    }
}
public static class MoveExtensions
{
    public static void UseMove(this Moves.NewMove MoveU,Transform CurrentPos, Transform Target)
    {
        GameObject G = new GameObject();
        G.AddComponent<SpellManager>();
        G.AddComponent<Rigidbody>();
        G.AddComponent<SphereCollider>();
        G.AddComponent<ParticleSystem>();

        SpellManager SM = G.GetComponent<SpellManager>();
        SM.Target = Target;
        SM.CastorPos = CurrentPos;
        SM.ThisMove = MoveU;
    }
}
