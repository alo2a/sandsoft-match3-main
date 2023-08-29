using UnityEngine;
using DG.Tweening;

public class Gem : MonoBehaviour
{
    public GemsType type;
    float time = 0.3f;
    private void OnEnable()
    {
        transform.DOScale(1, time);
    }
}
public enum GemsType
{
    Apple,Pinapple,Banana,Orange,Straberry,Kiwi
}
