using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject visualGameObjecct;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, PlayerController.OnSelectedCounterChangedEventArgs e)
    {
        if  ( e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Show()
    {
        visualGameObjecct.SetActive(true);
     
    } 
    private void Hide()
    {
        visualGameObjecct.SetActive(false);
    }
}
