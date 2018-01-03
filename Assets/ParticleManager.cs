using UnityEngine;
using System.Collections;

public class ParticleManager : ScriptableObject
{
    public void ParticleSelect(AI.Elements SpellType,ParticleSystem SpellPS)
    {
        ParticleSystem.MainModule Main = SpellPS.main;
        ParticleSystem.EmissionModule EM = SpellPS.emission;
        ParticleSystem.ColorOverLifetimeModule CLT = SpellPS.colorOverLifetime;

        switch (SpellType)
        {
            case AI.Elements.Fire:
                Main.startColor = Color.red;
                EM.enabled = true;
                EM.SetBursts(new ParticleSystem.Burst[]
                {
                    new ParticleSystem.Burst(2.0f,1),
                    new ParticleSystem.Burst(4.0f,1)
                });
                Gradient Grad = new Gradient();
                CLT.enabled = true;
                Grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
                CLT.color = Grad;
                break;
            case AI.Elements.Water:
                break;
            case AI.Elements.Electric:
                break;
            case AI.Elements.Nature:
                break;
            case AI.Elements.Rock:
                break;
            default: // Shouldn't hit this case
                break;
        }
    }
}
