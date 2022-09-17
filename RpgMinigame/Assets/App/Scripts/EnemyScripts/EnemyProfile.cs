using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Profile", menuName = "Profiles/Enemy")]
public class EnemyProfile : ScriptableObject
{
  public int health;
  public int damage;
}
