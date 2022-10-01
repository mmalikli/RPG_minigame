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
  public CircleCollider2D zone;
  public DetectionZone detectionZone;
  public float moveSpeed;
  private Animator damageAnim;
  Rigidbody2D rb;
  bool isAlive = true;
  [SerializeField] private Animator animator;

  private bool dealDamage = true;
  private bool isDead = false;

    private void FixedUpdate()
    {
        if (detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;

            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }
    public float EnemyHealth {
    get {
      return enemyHealth;
    }
    set {
      enemyHealth = value;

      if(enemyHealth <= 0) {
        isDead = true;
                Defeated();
      }
    }
  }

  public EnemyProfile enemyProfile;

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
    EnemyHealth = enemyProfile.health;
    gameObject.tag = "Enemy";
    damageTextUI = GetComponentInChildren<Text>();
    damageAnim = damageTextUI.transform.parent.GetComponent<Animator>();
    animator.SetBool("isAlive", isAlive);
  }
  // ???
  private void OnTriggerEnter2D(Collider2D other) {
    //Debug.Log(isAlive);
    // We must avoid the Detection zone trigger
    //if(other.IsTouching(zone)) return;
    if(Vector2.Distance(rb.position, new Vector2(GameManager.instance.player.position.x,GameManager.instance.player.position.y)) < .78f) {
      if(other.gameObject.CompareTag("Player") && dealDamage && other.isTrigger) {
        // Damage is handled by Game Manager
      // Debug.Log(other.gameObject.CompareTag("DetectionZone"));
        TakeDamage(GameManager.instance.playerDamage);
        dealDamage = false;
        //StartCoroutine(damageDealBuffer());
      }
    }

  }
  private void OnTriggerExit2D(Collider2D other) {
    dealDamage = true;
  }
  // IEnumerator damageDealBuffer() {
  //   yield return new WaitForSeconds(0.5f);
  //   dealDamage = true;
  // }
  public void TakeDamage(int damage) {
    StopAllCoroutines();
    damageAnim.Play("Pop");
    animator.SetTrigger("hit");
    EnemyHealth -= damage;
//    Debug.Log(EnemyHealth);
    damageAmountText += damage;
    damageTextUI.text = damageAmountText.ToString();

    if(!gameObject.activeSelf) return;
    StartCoroutine(DamageTimeOut());
  }

  IEnumerator DamageTimeOut() {
    yield return new WaitForSeconds(1.5f);
    damageAnim.Play("FadeOut");
  }
    //for triggering slime death animation
  private void Defeated()
    {
        animator.SetBool("isAlive", false);
    }

    //Death()  triggered in death animation
  private void Death() {
    if(enemyHealth <= 0) {
      Debug.Log("Enemy is dead");
     // isAlive = false;
      StopAllCoroutines();
      gameObject.SetActive(false);
      if(isDead) return;
      EventManager.Instance.Raise(new OnEnemyDeathEvent(enemyProfile));
      return;
    }
  }
}
