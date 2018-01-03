using UnityEngine;
using System.Collections;
public class SO1 : MonoBehaviour
{
    public static SO1 GameMaster;
    public Moves M;
    public AI AI;
    public TargetManager TM;
    public UnitManager UM;
    public ParticleManager PM;
    void Awake()
    {
        M = ScriptableObject.CreateInstance<Moves>();
        AI = ScriptableObject.CreateInstance<AI>();
        TM = ScriptableObject.CreateInstance<TargetManager>();
        UM = ScriptableObject.CreateInstance<UnitManager>();
        PM = ScriptableObject.CreateInstance<ParticleManager>();
        if (GameMaster == null)
        {
            GameMaster = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(GameMaster != this)
        {
            Destroy(gameObject);
        }
    }
}
