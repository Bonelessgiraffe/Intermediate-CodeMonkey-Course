using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform TomatoPrefab;
    [SerializeField] private Transform CountertopPoint;
    public void Interact()
    {
        Debug.Log("Interact!");
        Instantiate(TomatoPrefab, CountertopPoint.position, Quaternion.identity);
    }
}
