using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;

public class ThreadedJob
{
    private bool m_IsDone = false;
    private object m_Handle = new object();
    private System.Threading.Thread m_Thread = null;
    public bool IsDone
    {
        get
        {
            bool tmp;
            lock (m_Handle)
            {
                tmp = m_IsDone;
            }
            return tmp;
        }
        set
        {
            lock (m_Handle)
            {
                m_IsDone = value;
            }
        }
    }

    public virtual void Start()
    {
        m_Thread = new System.Threading.Thread(Run);
        m_Thread.Start();
    }

    public virtual void Abort()
    {
        m_Thread.Abort();
    }

    protected virtual void ThreadFunction() { }

    /// <summary>
    /// Executed on Unity main thread so it's safe to use Unity API.
    /// </summary>
    protected virtual void OnFinished() { }

    public virtual bool Update()
    {
        if (IsDone)
        {
            OnFinished();
            return true;
        }
        return false;
    }

    public IEnumerator WaitFor()
    {
        while (!Update())
        {
            yield return null;
        }
    }

    private void Run()
    {
        ThreadFunction();
        IsDone = true;
    }
}
 

public class Job : ThreadedJob
 {
public GameObject SingleHall; 
 public bool Statues,Finished;
     protected override void ThreadFunction()
     {
Finished=false;
         // Do your threaded task. DON'T use the Unity API here
       SingleHall.SetActive(Statues);
Debug.Log("Start elmorgeha");
     }
     protected override void OnFinished()
     {
         // This is executed by the Unity main thread when the job is finished
         Finished=true;
Debug.Log("Finish hahah");
     }
 }