using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Collections;
using UnityEngine;

public class CircleCloser : MonoBehaviour
{
    [SerializeField] private LoadingCircle _circle;

    private TweenerCore<float, float, FloatOptions> _tweener;

    private void Start()
    {
        _circle.TweenStarted += StartCounter;
    }

    private void OnDisable()
    {
        _circle.TweenStarted -= StartCounter;
        StopCoroutine(TryCloseTween(_tweener));
    }

    private IEnumerator TryCloseTween(TweenerCore<float, float, FloatOptions> tween)
    {
        yield return tween.WaitForCompletion();

        if (Mathf.Round(_circle.GetFillAmount()) >= 1)
            _circle.gameObject.SetActive(false);
    }

    private void StartCounter(TweenerCore<float, float, FloatOptions> tween)
    {
        _tweener = tween;
        StartCoroutine(TryCloseTween(_tweener));
    }
}
