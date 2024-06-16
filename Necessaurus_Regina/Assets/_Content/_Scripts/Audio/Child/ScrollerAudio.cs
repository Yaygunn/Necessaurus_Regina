using UnityEngine;
using Audio.FmodCommunication;
using Audio.Events;

public class ScrollerAudio 
{
    public ScrollerAudio(FmodCommunication com, EventBindingSO data)
    {
        _com = com;
        _data = data;
    }

    public void Activate()
    {
        EventHub.Event_PlayerJump += OnJumped;
        Debug.Log("Activated");
    }

    public void DeActivate()
    {
        EventHub.Event_PlayerJump -= OnJumped;
    }


    private FmodCommunication _com { get; }

    private EventBindingSO _data {  get; }


    private void OnJumped()
    {
        _com.PlayOneShot(_data.Jump);
        Debug.Log("Jump Jump");
    }
}
