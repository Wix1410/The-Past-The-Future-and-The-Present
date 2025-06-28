using System.Collections;
using UnityEngine;

[DisallowMultipleComponent] 
public class Crusher : Falling
{
	[Header("References")]
	public Player player;

    [Header("Settings")]
	public float crushTimer = 5f;

	private int fallCount = 0;
	private Coroutine crushCoroutine = null;

	public override void OnFallOnObject(Collider2D box)
	{
		if (box != null && box.gameObject.CompareTag("Player"))
		{

			if (fallCount > 0)
			{
				InstaKill(box.gameObject);
				player.currentHp -= 2;
			}
			else if (crushCoroutine == null)
			{
				crushCoroutine = StartCoroutine(CrushDelay(box.gameObject));
                player.currentHp -= 3;
                return;
			}
		}
		if (isFalling)
		{
			fallCount++;
		}
	}

	private void InstaKill(GameObject gameObject)
	{
		StopAllCoroutines();
		fallCount = 0;
		Saveble.LoadAll();
	}

	IEnumerator CrushDelay(GameObject player)
	{
		if (fallCount < 1)
		{
			yield return new WaitForSeconds(crushTimer);
		}
        Collider2D box = Physics2D.OverlapBox(transform.position + Vector3.down * 1f, new Vector2(0.1f, 0.1f), 0f);
		if (box == null)
		{
			yield break;
		}
		if(box.gameObject != player)
		{
			yield break;
		}
		//moment the player is crushed
		InstaKill(player);
    }
}
