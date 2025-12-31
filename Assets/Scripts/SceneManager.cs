using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 싱글턴 기반 씬 로더
/// - PersistentRoot 하위에 1개만 존재
/// - 2개의 씬을 서로 왕복 가능
/// - 로딩 중 중복 호출 방지
/// </summary>
public class SceneLoaderManager : MonoBehaviour
{
    public static SceneLoaderManager Instance { get; private set; }

    [Header("Scenes (Build Settings에 등록 필요)")]
    [SerializeField] private string sceneA = "SceneA";
    [SerializeField] private string sceneB = "SceneB";

    public bool IsLoading { get; private set; }

    private void Start()
    {
        // 싱글턴 중복 방지
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // PersistentRoot에 속해 있다면 여기서 DontDestroyOnLoad는 필요 없음
        // 단독 사용 시 아래 주석 해제
        // DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 현재 씬을 기준으로 SceneA <-> SceneB 토글
    /// </summary>
    public void ToggleAB()
    {
        if (IsLoading) return;

        string current = SceneManager.GetActiveScene().name;
        string target;

        if (current == sceneA) target = sceneB;
        else if (current == sceneB) target = sceneA;
        else target = sceneA; // 예외 처리

        StartCoroutine(LoadSceneRoutine(target));
    }

    /// <summary>
    /// 씬 이름으로 로드
    /// </summary>
    public void Load(string sceneName)
    {
        if (IsLoading) return;
        if (string.IsNullOrEmpty(sceneName)) return;

        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    /// <summary>
    /// Build Index로 로드
    /// </summary>
    public void Load(int buildIndex)
    {
        if (IsLoading) return;
        if (buildIndex < 0) return;

        StartCoroutine(LoadSceneRoutine(buildIndex));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        IsLoading = true;

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        while (!op.isDone)
            yield return null;

        IsLoading = false;
    }

    private IEnumerator LoadSceneRoutine(int buildIndex)
    {
        IsLoading = true;

        AsyncOperation op = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Single);
        while (!op.isDone)
            yield return null;

        IsLoading = false;
    }
}
