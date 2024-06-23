using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonPressed);
    }


    private void ButtonPressed()
    {
        EventHub.UIOK();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventHub.UIHower();
    }
}
