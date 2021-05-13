using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Changes the scene/level</summary>
public class SceneChanger : MonoBehaviour
{
	public string SceneDestination;

    ///<summary>Loads scene at inputted destination</summary>
    public void SceneChange()
    {
		SceneManager.LoadScene(SceneDestination);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
      
        SceneChange(); 
    }
}