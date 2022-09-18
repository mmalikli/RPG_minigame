using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private Transform target;

  private void LateUpdate() {
    if(target != null) {
      transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Time.fixedDeltaTime);
    } else {
      Debug.Log("Camera doesn't have a target");
    }
    //Camera view must be restricted by the min and max position of the tilemap area
    //Mathf.Clamp()
  }
}
