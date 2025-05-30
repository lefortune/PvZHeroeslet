using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BungeePlumber : Card
{
	protected override IEnumerator OnThisPlay()
	{
		yield return new WaitForSeconds(1);
		if (row == -1 && col == -1) yield return GameManager.Instance.plantHero.ReceiveDamage(2, this);
		else yield return Tile.plantTiles[row, col].planted.ReceiveDamage(2, this);
		yield return base.OnThisPlay();
	}

	public override bool IsValidTarget(BoxCollider2D bc)
	{
		Tile t = bc.GetComponent<Tile>();
		if (t != null)
		{
			if (t.planted == null || t.planted.team == Team.Zombie) return false;
		}
		else
		{
			if (bc.GetComponent<Hero>().team == Team.Zombie) return false;
		}
		return true;
	}

}
