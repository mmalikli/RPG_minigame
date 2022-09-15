using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layering : MonoBehaviour
{
  SpriteRenderer spriteRenderer;
  
  //[SerializeField] private float interactRange = 1.5f;
  [SerializeField] private float offset;

  private void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  private void LateUpdate() {
    LayerSwitch();
    // if(Vector2.Distance(gameObject.transform.position, GameManager.instance.player.position) < interactRange ) {
    // }
  }

  private void LayerSwitch() {
     if(gameObject.transform.position.y + offset < GameManager.instance.player.transform.position.y){
      spriteRenderer.sortingLayerName = "Foreground";
    } else {
      spriteRenderer.sortingLayerName = "Background"; 
    }
  }


  //[]
}
