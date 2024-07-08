using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private bool isBackButton;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonPressed);
    }
    
    private void ButtonPressed()
    {
        if (isBackButton)
        {
            EventHub.UIBack();
        }
        else
        {
            EventHub.UIOK();   
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventHub.UIHower();
    }
}
