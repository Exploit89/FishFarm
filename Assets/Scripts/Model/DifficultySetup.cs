using UnityEngine;

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

public class DifficultySetup : MonoBehaviour
{
    public Difficulty DifficultyLevel { get; private set; }

    private void OnEnable()
    {
        // TODO ������� ����� ���������
        DifficultyLevel = Difficulty.Easy;
    }
}
