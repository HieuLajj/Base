using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace HieuLajj
{
    public class Utilities : MonoBehaviour
    {
        private AsyncOperation async;
        //load scene
        public void LoadScene_UT(string namescene){
            StartCoroutine(LoadSceneAsync(namescene));
        }

        IEnumerator LoadSceneAsync(string sceneName){
            if(!string.IsNullOrEmpty(sceneName)){
                async = SceneManager.LoadSceneAsync(sceneName);
                //async.allowSceneActivation = false;
                while(!async.isDone){
                    Debug.Log("loadscene %"+async.progress);
                    yield return 0;
                }
                //async.allowSceneActivation = true;
            }
        }
    }
}

