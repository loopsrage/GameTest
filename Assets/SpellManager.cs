using UnityEngine;
using System.Collections;

public class SpellManager : MonoBehaviour
{
    public Transform Target;
    public Transform CastorPos;
    public Moves.NewMove ThisMove;
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Target.position, ForceMode.Impulse);
        ParticleSystem TPS = gameObject.GetComponent<ParticleSystem>();
        SO1.GameMaster.PM.ParticleSelect(ThisMove.MoveType,TPS);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
