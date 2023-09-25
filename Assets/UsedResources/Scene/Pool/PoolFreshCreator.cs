using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolFreshCreator : MonoBehaviour
{
    [SerializeField] private FishEvents _fishEvents;
    [SerializeField] private StackMover _giverStackMover;
    [SerializeField] private ProductGiver _giver;
    [SerializeField] private GameObject _stackPrefab;
    [SerializeField] private Stack _stack;

    private float _stackQuantity = 0;
    private List<GameObject> _stackViews = new List<GameObject>();

    private void OnEnable()
    {
        _fishEvents.FishAdded += AddFresh;
        _giver.OnStackCleared += TryClearStorage;
    }

    private void OnDisable()
    {
        _fishEvents.FishAdded -= AddFresh;
        _giver.OnStackCleared -= TryClearStorage;
    }

    private void AddFresh(Fish fish)
    {
        fish.FishReady += AddFreshValue;
    }

    private void AddFreshValue(int value)
    {
        foreach (var item in _giverStackMover.GetStacks())
        {
            if (item.ProductType == ProductType.Fresh)
            {
                item.IncreaseQuantity(value);
                var stackView = Instantiate(_stackPrefab, transform);
                stackView.GetComponent<SpriteRenderer>().sprite = _stack.Image;
                stackView.transform.position = transform.position;
                _stackQuantity += 0.5f;
                Vector3 stackPosition = new Vector3(0, _stackQuantity, 0);
                stackView.transform.position += stackPosition;
                _stackViews.Add(stackView);
            }
        }
    }

    private void TryClearStorage(int value)
    {
        if (value <= 0)
        {
            // TODO
            DestroyStackView();
            _stackViews.Clear();
        }
    }

    ///////////////////// TODO
    private IEnumerator DestroyStackView()
    {
        foreach (var item in gameObject.GetComponentsInChildren<Stack>())
        {
            int arrayLenght = item.GetComponentsInChildren<SpriteRenderer>().Length;

            for (int i = arrayLenght; i > 0; i--)
            {
                //yield return new WaitForSeconds(_delay);
                yield return new WaitForSeconds(0.5f);
                item.GetComponentsInChildren<SpriteRenderer>()[i - 1].gameObject.SetActive(false);
            }
        }

        foreach (var item in gameObject.GetComponentsInChildren<Stack>())
        {
            foreach (var disabledObject in item.GetComponentsInChildren<SpriteRenderer>(true))
            {
                Destroy(disabledObject.gameObject);
            }
        }
    }
}
