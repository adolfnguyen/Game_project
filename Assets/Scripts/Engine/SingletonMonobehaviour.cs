using UnityEngine;

public class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
{


    /// <summary>
    /// The actual instance of this type.
    /// </summary>
    private static MonoBehaviour instance;
    /// <summary>
    /// Do we wanna destroy this GO across levels
    /// </summary>
    [SerializeField] protected bool destroyOnLoad = false;
    /// <summary>
    /// Called when an instance is initialized due to no previous instance found.  Use this to
    /// initialize any resources this singleton requires (eg, if this is a gui item or prefab,
    /// build out the hierarchy in here or instantiate stuff).
    /// </summary>
    protected virtual void Initialize() { }

    /// <summary>
    /// Get an instance to this MonoBehaviour.Always returns a valid object.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // first search the scene for an instance
                T[] scene = FindObjectsOfType<T>();

                if (scene != null && scene.Length > 0)
                {
                    instance = scene[0];

                    for (int i = 1; i < scene.Length; i++)
                    {
                        Destroy(scene[i]);
                    }
                }
                else
                {
                    GameObject gameObject = new GameObject();
                    
                    string type_name = typeof(T).ToString();
                    
                    int i = type_name.LastIndexOf('.') + 1;
                    
                    gameObject.name = (i > 0 ? type_name.Substring(i) : type_name) + " Singleton";
                    
                    T inst = gameObject.AddComponent<T>();

                    SingletonMonobehaviour<T> cast = inst as SingletonMonobehaviour<T>;
                    
                    if (cast != null) cast.Initialize();
                    
                    instance = (MonoBehaviour)inst;
                }

                if (!((SingletonMonobehaviour<T>)instance).destroyOnLoad)
                    Object.DontDestroyOnLoad(instance.gameObject);
            }

            return (T)instance;
        }
    }

    /// <summary>
    /// Return the instance if it has been initialized, null otherwise.
    /// </summary>
    public static T nullableInstance
    {
        get { return (T)instance; }
    }

    /// <summary>
    /// If overriding, be sure to call base.Awake().
    /// </summary>
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;

            if (!((SingletonMonobehaviour<T>)instance).destroyOnLoad)
                Object.DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

