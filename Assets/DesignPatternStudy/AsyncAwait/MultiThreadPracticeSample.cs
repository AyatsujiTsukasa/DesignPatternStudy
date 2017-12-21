using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Events;

public class MultiThreadPracticeSample : MonoBehaviour {
    public ViewControllerSample mViewController;
    int count = 0;
    System.Random mRandom;

	// Use this for initialization
	void Start () {
        mRandom = new System.Random(3453);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Run(){
        mViewController.AddElement(string.Format("Task start, {0}", count));
        string message = string.Format("Task done, {0}", count++);

        // 同期メソッドを用いる場合
        //var currentContext = TaskScheduler.FromCurrentSynchronizationContext();
        //Task.Run(() => {
        //    DoHeavyTask();
        //})
        //    .ContinueWith(task => {
        //    mViewController.AddElement(message);
        //}, currentContext);

        // Asyncメソッドを用いる場合
        var currentContext = TaskScheduler.FromCurrentSynchronizationContext();
        //AsyncMethodSample().ContinueWith(task => {
        //    mViewController.AddElement(message);
        //}, currentContext);

        AsyncMethodWithReturnSample().ContinueWith(task => {
            mViewController.AddElement(message);
            mViewController.AddElement(task.Result.ToString());
        }, currentContext);
    }

    void DoHeavyTask(){
        Thread.Sleep(2000);
    }

    //async Task AsyncMethodSample(){
    //    Debug.Log("AsyncMethodSample Start");
    //    await Task.Delay(System.TimeSpan.FromSeconds(2)).ConfigureAwait(false);
    //    Debug.Log("AsyncMethodSample End");
    //}

    async Task<int> AsyncMethodWithReturnSample()
    {
        await Task.Delay(System.TimeSpan.FromSeconds(2)).ConfigureAwait(false);
        return mRandom.Next();
    }

    public void RunParallel(){
        
    }
}
