using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : ScriptableObject
{
    public List<AIUnit> Units = new List<AIUnit>();
    public enum Attributes
    {
        Health,
        Mana,
        Stamina

    }
    public enum Stats
    {
        Strength,
        Dexterity,
        Intelegence,
        Wisdom,
        Charisma,
        Constitution
    }
    public enum Elements
    {
        Fire,
        Water,
        Electric,
        Nature,
        Rock
    }
    public Dictionary<Elements, List<Elements>> Resistances = new Dictionary<Elements, List<Elements>>()
            {
                { Elements.Fire, new List<Elements>(){ Elements.Rock } },
                { Elements.Water, new List<Elements>(){ Elements.Fire } },
                { Elements.Electric, new List<Elements>(){ Elements.Nature } },
                { Elements.Nature, new List<Elements>(){ Elements.Rock } },
                { Elements.Rock, new List<Elements>(){ Elements.Electric } }

            };
    public Dictionary<Elements, List<Elements>> Weaknesses = new Dictionary<Elements, List<Elements>>()
            {
                { Elements.Fire, new List<Elements>(){ Elements.Water } },
                { Elements.Water, new List<Elements>(){ Elements.Electric } },
                { Elements.Electric, new List<Elements>(){ Elements.Rock } },
                { Elements.Nature, new List<Elements>(){ Elements.Fire } },
                { Elements.Rock, new List<Elements>(){ Elements.Nature } }
            };
    public List<Elements> GetWeakness(Elements E)
    {
        List<Elements> Weakness = Weaknesses[E];
        return Weakness;
    }
    public List<Elements> GetResistance(Elements E)
    {
        List<Elements> Resistance = Resistances[E];
        return Resistance;
    }
    public AIUnit NewAI(Elements E)
    {
        AIUnit NU = new AIUnit(E);
        return NU;
    }
    public class AIUnit
    {
        public int Health;
        public int Mana;
        public int Stamina;
        public AI.Elements UnitType;
        public List<Moves.NewMove> Abilities = new List<Moves.NewMove>();
        public 
        public AIUnit(AI.Elements UT)
        {
            UnitType = UT;
            Health = 100;
            Mana = 100;
            Stamina = 100;
            for (int i = 0; i <= 4; i++)
            {
                Moves.NewMove Move = new Moves.NewMove(UnitType);
                Abilities.Add(Move);
            }
        }
    }
}
