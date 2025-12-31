using UnityEngine;

public class PersistentBootstrap : MonoBehaviour
{
    [Header("PersistentRoot 프리팹을 넣으세요")]
    [SerializeField] private GameObject persistentRootPrefab;

    private static bool created;

    private void Awake()
    {
        if (created) return;
        created = true;

        var root = Instantiate(persistentRootPrefab);
        root.name = "[PersistentRoot]";
        DontDestroyOnLoad(root);

        // Bootstrap 오브젝트 자체는 필요 없으면 제거
        Destroy(gameObject);
    }
}
