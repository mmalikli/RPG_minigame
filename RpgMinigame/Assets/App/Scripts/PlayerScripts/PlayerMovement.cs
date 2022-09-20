using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rpg.Player {
  public class PlayerMovement : MonoBehaviour
  {
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;

    // private void Update() {
    // }
    private void FixedUpdate() {
      Move();
    }

    private void Move() {
      Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
      if(DialogueManager.instance.isPlayerInDialogue || DialogueManager.instance.isPlayerInDialogueOption || QuestManager.instance.InQuestUI) {
        movement = Vector2.zero;
        anim.SetBool("isAttacking", false);

      } else {

      // Player is Attacking
      if(Input.GetMouseButton(0)) {
        anim.SetBool("isAttacking", true);
      }
      //Player is Walking
      if ( movement != Vector2.zero) {
        anim.SetBool("isWalking", true);
        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);
      } else {
        anim.SetBool("isWalking", false);
      }
      rigidBody.MovePosition(rigidBody.position + movement.normalized*speed*Time.fixedDeltaTime);
      }
    }
  }
}
