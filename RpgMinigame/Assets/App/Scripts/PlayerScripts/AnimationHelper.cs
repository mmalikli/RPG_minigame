using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
  private Animator anim;

  private void Start() {
    anim = GetComponentInParent<Animator>();
  }
  
  // this method is used as animation event
  public void StopAttacking() {
     anim.SetBool("isAttacking", false);
  }
}
