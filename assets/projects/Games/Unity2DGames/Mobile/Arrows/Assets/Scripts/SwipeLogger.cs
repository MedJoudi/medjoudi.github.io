using UnityEngine;
using System;
using TMPro;

public class SwipeLogger : MonoBehaviour
{
    private SwipeD swipeD;



    private void Awake()
    {
        SwipeD.OnSwipe += SwipeD_OnSwipe;
    }

    public void SwipeD_OnSwipe(SwipeData data)
    {
        swipeD = GameObject.FindObjectOfType<SwipeD>();

    }
}