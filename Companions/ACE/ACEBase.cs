using Microsoft.Xna.Framework;
using terraguardians;
using Terraria.ID;
using ArknightsMod;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace DocterMain.Companions
{
    //Extending TerraGuardianBase will allow you to create custom companion ready companions.
    //Extending TerrarianBase, allows instead to create Terrarian companions. Check TerraGuardians 1.4 source for example.
    //Extend CompanionCase if you want to try something different for companions.
    public class ACEBase : TerrarianBase
    {
	public override string Name => "ACE";
	public override string Description => "Ace Is a former member from Babel and one of Rhodes Island's elite combatants alongside Blaze, Rosmontis, and Scout, with whom he shared a strong camaraderie. He is also Blaze's senior when she first joined R.I. and helped her in combat training together with Mechanist.";
	public override int Age => 21;
	public override Genders Gender => Genders.Male;
    public override CombatTactics DefaultCombatTactic => CombatTactics.CloseRange;
    public override float AccuracyPercent => .85f;
    public override float MaxRunSpeed => 5.6f;
    public override float RunAcceleration => 0.22f;
    public override float RunDeceleration => 0.37f;
    public override int JumpHeight => 15;
    public override float JumpSpeed => 6.45f;
    public override bool CanUseHeavyItem => true;
    protected override FriendshipLevelUnlocks SetFriendshipUnlocks => new FriendshipLevelUnlocks(){ MoveInUnlock = 0, VisitUnlock = 0, FollowerUnlock = 0 };
	public override int InitialMaxHealth => 200;
	public override int InitialMaxMana => 50;
	public override int HealthPerLifeCrystal => 20;
	public override int HealthPerLifeFruit => 10;
    public override BehaviorBase DefaultFollowLeaderBehavior => (BehaviorBase)(object)new ACEFollowLeaderBehavior();        
    protected override CompanionDialogueContainer GetDialogueContainer => new Docter.ACEDialogues(); //I have split the companion dialogues to another file. Here, you initialize the object containing companion dialogues.
        public override void UpdateAttributes(Companion companion) //This updates whenever the companion status are reset. If you want to change their status, or give them other benefits, here is the place.
        {
            companion.DodgeRate += 25f;
            companion.BlockRate += 65f;
            companion.DefenseRate += 15f;
            ((Player)companion).GetArmorPenetration<RangedDamageClass>() += 35f;
            ((Player)companion).GetAttackSpeed<RangedDamageClass>() += 1.55f;
            ((Player)companion).GetArmorPenetration<MeleeDamageClass>() += 35f;
            ((Player)companion).GetAttackSpeed<MeleeDamageClass>() += 1.35f;
            ((Player)companion).GetCritChance<MeleeDamageClass>() += 27f;
            ((Player)companion).GetCritChance<RangedDamageClass>() += 30f;
            ref StatModifier damage = ref ((Player)companion).GetDamage<MagicDamageClass>();
		    damage -= 55f;
            ref StatModifier damage1 = ref ((Player)companion).GetDamage<MeleeDamageClass>();
		    damage1 *= 2.55f;
            ref StatModifier damage2 = ref ((Player)companion).GetDamage<RangedDamageClass>();
		    damage2 *= 2.5f;
            ref StatModifier damage3 = ref ((Player)companion).GetDamage<SummonDamageClass>();
		    damage3 -= 35f;
            if (companion.FriendshipLevel >= 2) {
                companion.MaxHealth += 50;
            }
            if (companion.FriendshipLevel >= 4) {
                companion.MaxHealth += 50;
            }
            if (companion.FriendshipLevel >= 6) {
                companion.MaxHealth += 50;
            }
            if (Main.hardMode) {
                companion.MaxHealth += 250;
            }
        }
        protected override TerrarianCompanionInfo SetTerrarianCompanionInfo
        {
            get
            {
                return new TerrarianCompanionInfo()
                {
                    HairStyle = 161,
                    SkinVariant = 1,
                    HairColor = new Color(89, 33, 18),
                    EyeColor = new Color(105, 90, 75),
                    SkinColor = new Color(255, 171, 148),
                    ShirtColor = new Color(175, 165, 140),
                    UndershirtColor = new Color(160, 180, 215),
                    PantsColor = new Color(255, 230, 175),
                    ShoesColor = new Color(160, 105, 60)
                };
            }
        }
        
        public override void InitialInventory(out InitialItemDefinition[] InitialInventoryItems, ref InitialItemDefinition[] InitialEquipments)
	    {
		if (ModLoader.TryGetMod("ArknightsMod", out Mod ArknightsMod) && ArknightsMod.TryFind("DoctorJacket", out ModItem DoctorJacket) && ArknightsMod.TryFind("DoctorHood", out ModItem DoctorHood) && ArknightsMod.TryFind("DoctorPants", out ModItem DoctorPants))
        {
            InitialInventoryItems = new InitialItemDefinition[]
            {
                new InitialItemDefinition(97, 750),
                new InitialItemDefinition(188, 100),
                new InitialItemDefinition(204, 1),
                new InitialItemDefinition(95, 1),
            };
            InitialEquipments[11] = new InitialItemDefinition(DoctorJacket.Type);
            InitialEquipments[12] = new InitialItemDefinition(DoctorPants.Type);
            InitialEquipments[13] = new InitialItemDefinition(938);
            InitialEquipments[14] = new InitialItemDefinition(3061);
            InitialEquipments[10] = new InitialItemDefinition(237);
        }
		else
		{
			InitialInventoryItems = (InitialItemDefinition[])(object)new InitialItemDefinition[7]
			{
				new InitialItemDefinition(1306, 1),
				new InitialItemDefinition(533, 1),
				new InitialItemDefinition(1302, 9999),
				new InitialItemDefinition(188, 100),
                new InitialItemDefinition(188, 100),
                new InitialItemDefinition(188, 100),
                new InitialItemDefinition(188, 100),
			};
		}
	}
}
}
