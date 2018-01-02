using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class TargetManager : ScriptableObject
{
    public List<AI.AIUnit> ActiveTargets = new List<AI.AIUnit>();
    public AI.AIUnit SelectTarget(AI.AIUnit Current)
    {
        List<AI.Elements> WeakElement = SO1.GameMaster.AI.GetWeakness(Current.UnitType);
        List<AI.Elements> ResistElement = SO1.GameMaster.AI.GetResistance(Current.UnitType);
        AI.AIUnit NewTarget = ActiveTargets.Where(x=>x.UnitType != WeakElement.First()).First();
        return NewTarget;
    }
}
