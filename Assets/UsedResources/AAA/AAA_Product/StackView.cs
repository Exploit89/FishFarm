using DG.Tweening;
using System.Collections;
using System.Linq;
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
        {
            StartCoroutine(CreateStackView(taker, giver, value));
            ///////////////////////////////////////
            StartCoroutine(DestroyStackView(giver, value));
        }
    }

    private IEnumerator SwitchOff(GameObject stackView, float stackQuantity)
    {
        yield return new WaitForSeconds(_movingDuration);

        if (stackView.GetComponentInParent<Player>())
        {
            stackView.transform.position = gameObject.GetComponentInParent<Transform>().transform.position; //
            Vector3 stackPosition = new Vector3(0, stackQuantity, 0);
            stackView.transform.position += stackPosition;
        }
        else
        {
            stackView.gameObject.SetActive(false);
        }

    }

    private IEnumerator CreateStackView(Stack taker, Stack giver, int value)
    {
        Transform parentTransform = taker.GetComponentInParent<Transform>();
        float stackQuantity = 0;

        for (int i = 0; i < value; i++)
        {
            var stackView = Instantiate(_stackPrefab, parentTransform);
            stackView.GetComponent<SpriteRenderer>().sprite = giver.Image;
            stackView.transform.position = giver.transform.position;
            stackView.transform.DOMove(taker.transform.position, _movingDuration);
            stackQuantity += 0.5f;
            StartCoroutine(SwitchOff(stackView, stackQuantity));
            yield return new WaitForSeconds(_delay);
        }
        stackQuantity = 0;
    }

    //////////////////////////////////////////
    private IEnumerator DestroyStackView(Stack giver, int value)
    {
        foreach (var item in giver.GetComponentsInChildren<Stack>())
        {
            if (item.Quantity == 0)
            {
                Debug.Log("clear capacity");
            }
            else
            {
                Debug.Log(item.GetComponentsInChildren<Transform>().Length);
                for (int i = 1; i < item.GetComponentsInChildren<Transform>().Length; i++)
                {
                    Debug.Log(item.GetComponentsInChildren<Transform>()[i].name);
                    Destroy(item.GetComponentsInChildren<Transform>()[i].gameObject);
                    yield return new WaitForSeconds(_delay);
                }
            }
        }
    }
}
