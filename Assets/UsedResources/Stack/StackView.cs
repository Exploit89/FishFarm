using UnityEngine;
using UnityEngine.Events;

public class StackView : MonoBehaviour
{
    [SerializeField] private Stack _stack;
    [SerializeField] private GameObject _addCountPrefab;
    [SerializeField] private GameObject _removeCountPrefab;

    private StackExchanger _stackExchanger;
    private int _value;

    public event UnityAction OnStackExist;

    private void Start()
    {
        _value = _stack.Quantity;
    }

    private void OnEnable()
    {
        if(_stackExchanger != null)
            _stackExchanger.UpdateStackCount += UpdateStackView;
    }

    private void OnDisable()
    {
        if (_stackExchanger != null)
            _stackExchanger.UpdateStackCount -= UpdateStackView;
    }

    private void UpdateStackView()
    {
        if (_value == 0 && _stack.Quantity > 0)
            OnStackExist?.Invoke();

        if (_value < _stack.Quantity)
            RenderAddCount(_stack.Quantity - _value);

        else if (_value > _stack.Quantity)
            RenderRemoveCount(_value - _stack.Quantity);

        else if (_stack.Quantity <= 0)
            _stack.gameObject.SetActive(false);

        _value = _stack.Quantity;
    }

    private void RenderAddCount(int value)
    {
        GameObject addingImage = Instantiate(_addCountPrefab, transform);
        addingImage.transform.position += new Vector3(0, 3,0);
    }
    private void RenderRemoveCount(int value)
    {
        GameObject removingImage = Instantiate(_removeCountPrefab, transform);
        removingImage.transform.position += new Vector3(2, 2, 0);
    }

    public void SetStackExchanger(StackExchanger stackExchanger)
    {
        _stackExchanger = stackExchanger;
        _stackExchanger.UpdateStackCount += UpdateStackView;
    }
}
