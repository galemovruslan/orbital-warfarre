using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PopUpWindow.Instance.Show("Test Text", 
                ()=> Debug.Log("Yes Button"),
                ()=> Debug.Log("No Button"));
        }
    }
}
