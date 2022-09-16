using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
  [SerializeField] private float interactRange = 1.5f;

  private void LateUpdate() {
    if(Vector2.Distance(gameObject.transform.position, GameManager.instance.player.position ) < interactRange) {
      if(Input.GetKeyDown(KeyCode.I)) {
        Interact();
      }
    }
  }

  public virtual void Interact() {

  }

  private void OnDrawGizmosSelected() {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, interactRange);
  }
}