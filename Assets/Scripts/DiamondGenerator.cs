using UnityEngine;
using System.Collections;

public class DiamondGenerator : MonoBehaviour {

	public ObjectPooler diamondPool;

	public float distanceBetweenDiamonds;
	public void SpawnDiamonds(Vector3 startPosition){
		GameObject diamond1 = diamondPool.GetPooledObject ();
		diamond1.transform.position = startPosition;
		diamond1.SetActive (true);
	}
}
