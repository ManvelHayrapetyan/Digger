using Zenject;
using UnityEngine;

public class TestRunner : MonoBehaviour
{
    [Inject] TestService _testService;

    void Start()
    {
        if (_testService != null)
        {
            _testService.Run();
        }
        else
        {
            Debug.LogError("TestService is not injected!");
        }
    }
}