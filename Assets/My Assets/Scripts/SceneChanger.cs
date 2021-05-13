//--------------------------------
using UnityEngine;
using UnityEngine.SceneManagement;
//--------------------------------
//Scene changer based on fades
public class SceneChanger : MonoBehaviour
{
    //Scene to change
    // public int SceneDestination = 0;
	public string SceneDestination;
   
    //--------------------------------*/
    public void SceneChange()
    {
        // SceneManager.LoadScene(SceneDestination);
		SceneManager.LoadScene(SceneDestination);
    }
    //--------------------------------
    void OnTriggerEnter2D(Collider2D other)
    {
        //If not player entered, then exit
        if (!other.gameObject.CompareTag("Player")) return;
      
        SceneChange(); 
    }
    //--------------------------------
}
//--------------------------------

