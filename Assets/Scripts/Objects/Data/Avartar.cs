using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AvartarData", menuName = "Scriptables/Avartar")]
public class Avartar : ScriptableObject
{
    [SerializeField] private int avertarID;
    [SerializeField] private string avatarName;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private AnimationClip idleAni;
    [SerializeField] private AnimationClip runAni;
    [SerializeField] private AnimatorOverrideController animator;

    public int GetID() { return avertarID; }
    public string GetAvartarName() { return avatarName; }
    public Sprite GetIdleSprite() { return idleSprite; }
    public AnimationClip GetRunAni() { return runAni; }
    public AnimationClip GetIdleAni() { return idleAni; }
    public AnimatorOverrideController GetAnimator() { return animator; }
}