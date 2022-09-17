using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHelper : MonoBehaviour
{
  public void SetGameObjectOff() {
    gameObject.SetActive(false);
  }
  public void ResetDamage() {
    BaseEnemy BE = transform.parent.GetComponent<BaseEnemy>();
    BE.damageAmountText = 0;
  }
}
