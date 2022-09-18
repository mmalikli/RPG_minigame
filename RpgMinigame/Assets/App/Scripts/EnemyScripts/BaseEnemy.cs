using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicBox.EventManagement;

public class BaseEnemy : MonoBehaviour
{
  private float enemyHealth;
  private Text damageTextUI;
  public float damageAmountText;
  private Animator damageAnim;

  public float EnemyHealth {
    get {
      return enemyHealth;
    }
    set {
      enemyHealth = value;
      if(enemyHealth <= 0) {
        Death();
      }
    }
  }

  public EnemyProfile enemyProfile;

  private void Start() {
    EnemyHealth = enemyProfile.health;
    gameObject.tag = "Enemy";
    damageTextUI = GetComponentInChildren<Text>();
    damageAnim = damageTextUI.transform.parent.GetComponent<Animator>();
  }
  // ???
  public void TakeDamage(int damage) {
    StopAllCoroutines();
    damageAnim.Play("Pop");
    EnemyHealth -= damage;
    Debug.Log(EnemyHealth);
    damageAmountText += damage;
    damageTextUI.text = damageAmountText.ToString();

    if(!gameObject.activeSelf) return;
    StartCoroutine(DamageTimeOut());
  }

  IEnumerator DamageTimeOut() {
    yield return new WaitForSeconds(1.5f);
    damageAnim.Play("FadeOut");
  }
  private void Death() {
    //if()
    gameObject.SetActive(false);
    EventManager.Instance.Raise(new OnEnemyDeathEvent(enemyProfile));
  }
}
