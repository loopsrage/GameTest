using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UnitManager : ScriptableObject
{
    public int NumberOfUnits;
    public void CreateUnits()
    {
        for (int i = 0; i < NumberOfUnits; i++)
        {
            AI.Elements UnitElem = (AI.Elements)Random.Range(0, AI.Elements.GetNames(typeof(AI.Elements)).Length);
            SO1.GameMaster.AI.NewAI(UnitElem);
            
        }
    }
}
