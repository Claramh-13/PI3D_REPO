using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipRefSO", menuName = "Audio/AudioClipRef")]
public class AudioClipRefSO : ScriptableObject
{
    public AudioClip[] dryer;
    public AudioClip[] objectDrop;
    public AudioClip[] objectPickUp;
    public AudioClip[] footstep;
    public AudioClip[] wachinemachine;
    public AudioClip[] deliverySucces;
    public AudioClip[] deliveryFail;
}
