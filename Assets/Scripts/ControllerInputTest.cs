using UnityEngine;
using VRTK;
public class ControllerInputTest : MonoBehaviour {
	// Use this for initialization
	void Start ()
	{
		if(GetComponent<VRTK_ControllerEvents>() == null)
		{
			Debug.LogError("Need to have VRTK_ControllerEvents component attached to the controller");
			return;
		}
		GetComponent<VRTK_ControllerEvents>().AliasMenuOn += new ControllerInteractionEventHandler(TestInput);
	}
	private void TestInput(object sender, ControllerInteractionEventArgs e)
	{
		Debug.Log("Seems to be working!");
	}
}