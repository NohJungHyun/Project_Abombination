﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SearchWithRayCast
{
    public static RaycastHit hit;
    private static LayerMask basicLayer;
    private static Ray ray;
    private static Camera mainCamera = Camera.main;
    private static LayerMask layer;
    private static LayerMask characterSelectLayer;

    public static Temp_Character selectedCharacter;

    // public delegate void clickEvent(Temp_Character temp_character);
    // public static event clickEvent characterClick;
    
    public static GameObject GetHitSomething()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
            return hit.collider.gameObject;
        else
            return null;
    }

    public static Vector3 GetHitPoint()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
            return hit.point;
        else
            return Vector3.zero;
    }

    public static Temp_Character GetHitCharacter()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        characterSelectLayer = LayerMask.GetMask("Characters");

        if (Physics.Raycast(ray, out hit, 100, characterSelectLayer))
        {
            // characterClick?.Invoke(hit.collider.GetComponent<Temp_Character>());
            selectedCharacter = hit.collider.GetComponent<Temp_Character>();
            return selectedCharacter;
        }
        else
            return null;
    }

    public static void SetLayer(LayerMask _layer)
    {
        layer = _layer;
    }

    public static void SetLayer(string _layerString)
    {
        layer = LayerMask.GetMask(_layerString);
    }

    public static void ReturnBasicLayer()
    {
        layer = basicLayer;
    }
}
