using UnityEngine;

public interface IGameRules
{
    public int DefaultAttemps { get; }
    public int Attemps { get; set; }
}

[CreateAssetMenu(menuName = nameof(GameRules))]
public class GameRules : ScriptableObject, IGameRules
{
    [SerializeField] private Attempts _attempts;

    public int DefaultAttemps => _attempts.DefaultNumberAttempts;
    public int Attemps { get => _attempts.NumberAttempts; set => _attempts.NumberAttempts = value; }

    [System.Serializable]
    public class Attempts
    {
        [field: SerializeField] public int DefaultNumberAttempts { get; private set; }

        private int _runtimeNumberAttempts;

        public int NumberAttempts { get => _runtimeNumberAttempts; set => _runtimeNumberAttempts = value; }

        public void Setup()
        {
            NumberAttempts = DefaultNumberAttempts;
        }
    }

    private void OnEnable()
    {
        _attempts.Setup();
    }
}