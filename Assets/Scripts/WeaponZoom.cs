using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponZoom : MonoBehaviour
{
   [SerializeField] Camera fpsCamera;
   [SerializeField] float zoomOutValue = 60f;
   [SerializeField] float zoomInValue = 20f;
   [SerializeField] bool zoomIn = false;
   

   private void OnDisable() {
      zoomIn = false;
   }
   void Update() {
      CheckZoom();
      ZoomIn();
   }

    void CheckZoom() {
    if(Input.GetMouseButtonDown(1)) {
      zoomIn = !zoomIn;
    }
   }
   void ZoomIn() {
      if (zoomIn) {
         fpsCamera.fieldOfView = zoomInValue;
      } else {
         fpsCamera.fieldOfView = zoomOutValue;

      }
   }

}
