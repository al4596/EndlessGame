using UnityEngine;
using System.Collections;

public class DiamondGenerator : MonoBehaviour {

	public ObjectPooler diamondPool;

	public float distanceBetweenDiamonds;
	public void SpawnDiamonds(Vector3 startPosition){
		GameObject diamond1 = diamondPool.GetPooledObject ();
		diamond1.transform.position = startPosition;
		diamond1.SetActive (true);

		GameObject diamond2 = diamondPool.GetPooledObject ();
		diamond2.transform.position = new Vector3 (startPosition.x - distanceBetweenDiamonds, startPosition.y, startPosition.z);
		diamond2.SetActive (true);

		GameObject diamond3 = diamondPool.GetPooledObject ();
		diamond3.transform.position = new Vector3 (startPosition.x + distanceBetweenDiamonds, startPosition.y, startPosition.z);
		diamond3.SetActive (true);
	}
}
