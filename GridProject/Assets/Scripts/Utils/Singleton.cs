// Singleton Class by Willy Campos 
// https://github.com/wcampospro/Unity_References/blob/master/Persistence/Singleton.cs

using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance;

    protected void Awake ()
    {
        if (instance == null)
        {
            instance = GetComponent<T> ();
            DontDestroyOnLoad (instance.gameObject);
            SingletonAwake ();
        }
        else
        {
            Debug.LogWarning ("Warning: There is already an instance of " + typeof (T) + " in the scene!");
            Destroy (this);
        }
    }

    public abstract void SingletonAwake ();

    public static void Require ()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T> ();
            if (instance == null)
            {
                GameObject obj = new GameObject ();
                obj.name = "DDOL_" + typeof (T).Name;
                obj.AddComponent<T> ();
            }
        }
    }
}