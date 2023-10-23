using System;
using Microsoft.Xna.Framework;
using terraguardians;
using Terraria;

public class TexastheOmertosaFollowLeaderBehavior : BehaviorBase
{
	private bool TriedTakingFurnitureToSit;

	private bool GotFurnitureToSit;

	private byte StuckCounter;

	private bool StuckCounterIncreased;

	private int IdleTime;

	public bool AllowIdle = true;

	private byte PathingCooldown;

	public override void Update(Companion companion)
	{
		UpdateFollow(companion);
	}

	private void IncreaseStuckCounter(Companion c)
	{
		if ((c.IsMountedOnSomething && PlayerMod.IsPlayerCharacter(c.GetCharacterMountedOnMe)) || ((Player)c).gross)
		{
			return;
		}
		StuckCounter++;
		StuckCounterIncreased = true;
		if (StuckCounter >= 60)
		{
			StuckCounter = 0;
			if (!c.CreatePathingTo(((Entity)c.Owner).Bottom - Vector2.UnitY * 2f, false, true, false))
			{
				c.BePulledByPlayer();
				c.reviveBehavior.ClearReviveTarget();
			}
			c.Target = null;
		}
	}

	public void UpdateFollow(Companion companion)
	{
		if (companion.IsBeingControlledBySomeone)
		{
			return;
		}
		Player Owner = companion.Owner;
		Vector2 Center = ((Entity)companion).Center;
		Vector2 OwnerPosition = ((Entity)Owner).Center;
		Vector2 OwnerBottom = ((Entity)Owner).Bottom;
		Companion Mount = null;
		bool OwnerUsingFurniture = false;
		bool OwnerIsIdle = false;
		Companion Controlled = PlayerMod.PlayerGetControlledCompanion(Owner);
		if (Controlled != null)
		{
			Owner = (Player)(object)Controlled;
		}
		OwnerPosition = ((Entity)Owner).Center;
		OwnerBottom = ((Entity)Owner).Bottom;
		Mount = PlayerMod.PlayerGetMountedOnCompanion(Owner);
		if (Mount != null)
		{
			OwnerPosition = ((Entity)Mount).Center;
			OwnerBottom = ((Entity)Mount).Bottom;
			OwnerUsingFurniture = Mount.UsingFurniture;
			OwnerIsIdle = ((Entity)Mount).velocity.X == 0f && ((Entity)Mount).velocity.Y == 0f;
		}
		else
		{
			OwnerUsingFurniture = Owner.sitting.isSitting || Owner.sleeping.isSleeping;
			OwnerIsIdle = ((Entity)Owner).velocity.X == 0f && ((Entity)Owner).velocity.Y == 0f;
		}
		if (companion.Data.FollowAhead && !OwnerUsingFurniture)
		{
			OwnerPosition.X += (float)((Entity)Owner).direction * (Owner.GetModPlayer<PlayerMod>().FollowAheadDistancing + companion.SpriteWidth * 0.5f * companion.Scale);
		}
		float MaxDistX = 1000f;
		float MaxDistY = 700f;
		for (int i = 0; i < Main.maxNPCs; i++)
		{
			if (Main.npc[i].boss && ((Entity)Main.npc[i]).active)
			{
				MaxDistX = 10000f;
				MaxDistY = 7000f;
			}
		}
		if (Math.Abs(OwnerPosition.X - Center.X) >= MaxDistX || Math.Abs(OwnerPosition.Y - Center.Y) >= MaxDistY)
		{
			IncreaseStuckCounter(companion);
			companion.reviveBehavior.ClearReviveTarget();
		}
		if (Companion.Is2PCompanion)
		{
			return;
		}
		if (Companion.Behaviour_InDialogue || Companion.Behaviour_AttackingSomething || Companion.Behavior_FollowingPath || Companion.Behavior_RevivingSomeone)
		{
			TriedTakingFurnitureToSit = (GotFurnitureToSit = false);
		}
		else
		{
			if (companion.GetCharacterMountedOnMe == Owner)
			{
				return;
			}
			if (companion.CompanionHasControl && AllowIdle)
			{
				bool FastIdle = OwnerUsingFurniture && !GotFurnitureToSit && TriedTakingFurnitureToSit;
				if (OwnerIsIdle || FastIdle)
				{
					if (FastIdle || !OwnerUsingFurniture || !companion.UsingFurniture)
					{
						IdleTime++;
						if ((IdleTime >= 1800 || FastIdle) && companion.idleBehavior is IdleBehavior)
						{
							BehaviorBase idleBehavior = companion.idleBehavior;
							((IdleBehavior)((idleBehavior is IdleBehavior) ? idleBehavior : null)).UpdateIdle(companion, true);
							return;
						}
					}
				}
				else
				{
					IdleTime = 0;
				}
			}
			if (companion.GoingToOrUsingFurniture || TriedTakingFurnitureToSit)
			{
				if (OwnerUsingFurniture)
				{
					return;
				}
				companion.LeaveFurniture();
				TriedTakingFurnitureToSit = (GotFurnitureToSit = false);
			}
			bool GoAhead = companion.Data.FollowAhead;
			float Distancing = 0f;
			Player p = Owner;
			if (!TriedTakingFurnitureToSit)
			{
				if (Mount != null)
				{
					p = (Player)(object)Mount;
				}
				if (p.sitting.isSitting)
				{
					TriedTakingFurnitureToSit = true;
					if (PlayerMod.IsCompanionLeader(p, companion))
					{
						int tx = (int)(((Entity)p).Center.X * 0.0625f);
						int ty = (int)((((Entity)p).Bottom.Y - 2f) * 0.0625f);
						Tile tile = ((Tilemap)(Main.tile))[tx, ty];
						bool IsChair = ((Tile)(tile)).TileType == 15;
						if ((companion.ShareChairWithPlayer || !IsChair) && companion.UseFurniture((int)(((Entity)p).Center.X * 0.0625f), (int)((((Entity)p).Bottom.Y - 2f) * 0.0625f), false))
						{
							return;
						}
					}
					Point chair = WorldMod.GetClosestChair(((Entity)p).Bottom, 12, 8, (BuildingInfo)null);
					if (chair.X > 0 && chair.Y > 0)
					{
						if (companion.UseFurniture(chair.X, chair.Y, false))
						{
							GotFurnitureToSit = true;
						}
						return;
					}
					GotFurnitureToSit = false;
				}
				if (p.sleeping.isSleeping)
				{
					TriedTakingFurnitureToSit = true;
					if (PlayerMod.IsCompanionLeader(p, companion) && companion.ShareBedWithPlayer && companion.UseFurniture((int)(((Entity)p).Center.X * 0.0625f), (int)((((Entity)p).Bottom.Y - 2f) * 0.0625f), false))
					{
						return;
					}
					Point furniture = WorldMod.GetClosestBed(((Entity)p).Bottom, 8, 6, (BuildingInfo)null);
					if (furniture.X > 0 && furniture.Y > 0)
					{
						if (companion.UseFurniture(furniture.X, furniture.Y, false))
						{
							GotFurnitureToSit = true;
						}
						return;
					}
					furniture = WorldMod.GetClosestChair(((Entity)p).Bottom, 12, 8, (BuildingInfo)null);
					if (furniture.X > 0 && furniture.Y > 0)
					{
						if (companion.UseFurniture(furniture.X, furniture.Y, false))
						{
							GotFurnitureToSit = true;
						}
						return;
					}
					GotFurnitureToSit = false;
				}
			}
			PlayerMod pm = Owner.GetModPlayer<PlayerMod>();
			float MyFollowDistance = companion.FollorOrder.Distance;
			if (!GoAhead || (((Entity)Owner).direction > 0 && OwnerPosition.X < Center.X) || (((Entity)Owner).direction < 0 && OwnerPosition.X > Center.X))
			{
				Distancing = pm.FollowBehindDistancing + MyFollowDistance * 0.5f;
				pm.FollowBehindDistancing += MyFollowDistance;
			}
			else
			{
				Distancing = pm.FollowAheadDistancing + MyFollowDistance * 0.5f;
				pm.FollowAheadDistancing += MyFollowDistance;
			}
			float DistanceFromPlayer = Math.Abs(OwnerPosition.X - Center.X);
			if (((Entity)Owner).velocity.Y == 0f && Owner.TouchedTiles.Count > 0 && Math.Abs(OwnerBottom.Y - ((Entity)companion).Bottom.Y) >= 48f && companion.CreatePathingTo(OwnerBottom - Vector2.UnitY * 2f, false, false, true))
			{
				return;
			}
			if ((!GoAhead && DistanceFromPlayer > 40f + Distancing) || (GoAhead && DistanceFromPlayer > 20f + Math.Abs(((Entity)companion).velocity.X)) || (((Player)companion).breath < ((Player)companion).breathMax && DistanceFromPlayer > 8f && !((Entity)Owner).wet))
			{
				if (((BehaviorBase)this).IsDangerousAhead(companion, (int)MathF.Min(MathF.Abs(((Entity)companion).velocity.X * 1.6f) * 0.0625f, 3f), 0, 0) || ((BehaviorBase)this).CheckForHoles(companion, 0, MathF.Abs(((Entity)companion).velocity.X * 1.2f)))
				{
					if (PathingCooldown == 0)
					{
						companion.CreatePathingTo(OwnerBottom - Vector2.UnitY * 2f, false, false, true);
						PathingCooldown = 12;
					}
					else
					{
						companion.BePulledByPlayer();
					}
				}
				else if (OwnerPosition.X < Center.X)
				{
					companion.MoveLeft = true;
				}
				else
				{
					companion.MoveRight = true;
				}
			}
			if (companion.CompanionHasControl && ((Entity)companion).velocity.X == 0f && ((Entity)companion).velocity.Y == 0f && ((Player)companion).itemAnimation == 0)
			{
				if (OwnerPosition.X < Center.X)
				{
					((Entity)companion).direction = -1;
				}
				else
				{
					((Entity)companion).direction = 1;
				}
			}
			if ((companion.MoveLeft || companion.MoveRight) && ((Entity)companion).velocity.X == 0f && ((Entity)companion).velocity.Y == 0f)
			{
				IncreaseStuckCounter(companion);
			}
			companion.WalkMode = false;
			if (!StuckCounterIncreased)
			{
				StuckCounter = 0;
			}
			StuckCounterIncreased = false;
			if (PathingCooldown > 0)
			{
				PathingCooldown--;
			}
		}
	}
}
