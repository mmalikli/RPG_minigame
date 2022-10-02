using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private Transform target;
  [SerializeField] private Vector2 maxPos;
  [SerializeField] private Vector2 minPos;

  private void LateUpdate() {
    if(target != null) {
      Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
      targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x);
      targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y);

      transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime);
    } else {
      Debug.Log("Camera doesn't have a target");
    }
    //Camera view must be restricted by the min and max position of the tilemap area
    //Mathf.Clamp()
    //public Transform target;
  //public float smoothing;
  }
}
