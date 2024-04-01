using DG.Tweening;
using UnityEngine;

public class SignAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransfrom;
    [SerializeField] private Vector3 _addSingScaleVector;
    [SerializeField] private float _animationDuration;
    private Sequence sequence;

    private void Start()
    {
        sequence = DOTween.Sequence();
        sequence
            .Append(_rectTransfrom.DOScale(_rectTransfrom.localScale + _addSingScaleVector, _animationDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear));
    }
}
