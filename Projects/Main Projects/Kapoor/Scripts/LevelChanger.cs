
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    public GameObject objectToTriggerScene;
    public Vector3 targetPosToStartTrigger = new Vector3(1,2,-7);

    private int sceneToLoad;
	
	// Update is called once per frame
	void Update () {

        if (objectToTriggerScene.transform.position == targetPosToStartTrigger)
        {
            FadeToScene(1);
        }
    }

    public void FadeToScene (int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
