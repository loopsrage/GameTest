using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class DynScript : ScriptableObject
{
    public int Test;
    // Use this for initialization
    void Awake()
    {
        Test = 100;
        Debug.Log("Test");
    }

}
