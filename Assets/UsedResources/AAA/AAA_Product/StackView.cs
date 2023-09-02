using DG.Tweening;
using System.Collections;
using UnityEngine;

public class StackView : MonoBehaviour
{
    [SerializeField] private PlayerEvents _playerEvents;
    [SerializeField] private GameObject _stackPrefab;

    private float _movingDuration = 0.5f;
    private float _delay = 0.2f;


    private void OnEnable()
    {
        _playerEvents.StackChanged += UpdateStackView;
    }

    private void OnDisable()
    {
        _playerEvents.StackChanged -= UpdateStackView;
    }

    private void UpdateStackView(Stack taker, Stack giver, int value)
    {
        if (value > 0)
            StartCoroutine(CreateStackView(taker, giver, value));
    }

    private IEnumerator SwitchOff(GameObject stackView)
    {
        yield return new WaitForSeconds(_movingDuration);
        stackView.gameObject.SetActive(false);
    }

    private IEnumerator CreateStackView(Stack taker, Stack giver, int value)
    {
        Transform parentTransform = taker.GetComponentInParent<Transform>();

        for (int i = 0; i < value; i++)
        {
            var stackView = Instantiate(_stackPrefab, parentTransform);
            stackView.GetComponent<SpriteRenderer>().sprite = giver.Image;
            stackView.transform.position = giver.transform.position;
            stackView.transform.DOMove(taker.transform.position, _movingDuration);

            if (taker.GetComponentInParent<Transform>().gameObject.TryGetComponent(out Player player))
                StartCoroutine(SwitchOff(stackView));
            yield return new WaitForSeconds(_delay);
        }
    }
}
