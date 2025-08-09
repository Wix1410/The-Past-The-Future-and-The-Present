
using System.Collections;
using UnityEngine;

public class Singleton
{
    private static Singleton instance;

    private Singleton() 
    {
        
    }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    public IEnumerator InvokeUnscaledCoroutiine(System.Action action, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        action?.Invoke();
    }
}
