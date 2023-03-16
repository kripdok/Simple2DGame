using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Dead += Reset;
    }

    private void OnDisable()
    {
        _player.Dead -= Reset;
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}