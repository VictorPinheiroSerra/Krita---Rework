using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EvoLevel
{
    Baby,
    Basic,
    Mature,
    Apex,
    Divine
}
[CreateAssetMenu(fileName = "SpeciesData", menuName = "ScriptableObjects/MonsterCatcher/Species Data", order = 1)]
public class SpeciesData : ScriptableObject
{
    [SerializeField] string speciesName;
    [SerializeField] EvoLevel evoLevel;

    public string SpeciesName => speciesName;
    public EvoLevel EvoLevel => evoLevel;
}
