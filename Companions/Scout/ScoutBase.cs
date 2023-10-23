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
    public class ScoutBase : TerrarianBase
    {
	public override string Name => "Scout";
	public override string Description => "Little is known about Scout, other than he is one of those who fought for Theresa during the Kazdel civil war as part of Babel. He becomes more worried for Doctor as they are being used as a commander during Babel, because he fears it will turn the Doctor into a war machine. He was also known as an expert sharpshooter, hence his codename.";
	public override int Age => 21;
	public override Genders Gender => Genders.Male;
    public override float AccuracyPercent => 0.85f;
    public override float MaxRunSpeed => 6.6f;
    public override float RunAcceleration => 0.42f;
    public override float RunDeceleration => 0.57f;
    public override int JumpHeight => 15;
    public override float JumpSpeed => 5.45f;
    public override bool CanUseHeavyItem => true;
	public override int InitialMaxHealth => 200;
	public override int InitialMaxMana => 25;
	public override int HealthPerLifeCrystal => 20;
    public override BehaviorBase DefaultFollowLeaderBehavior => (BehaviorBase)(object)new ScoutFollowLeaderBehavior();
	public override int HealthPerLifeFruit => 10;        
    protected override CompanionDialogueContainer GetDialogueContainer => new Docter.ScoutDialogues(); //I have split the companion dialogues to another file. Here, you initialize the object containing companion dialogues.
        public override void UpdateAttributes(Companion companion) //This updates whenever the companion status are reset. If you want to change their status, or give them other benefits, here is the place.
        {
            companion.DodgeRate += 55f;
            companion.BlockRate += 25f;
            companion.DefenseRate += 0.5f;
            ((Player)companion).GetArmorPenetration<RangedDamageClass>() += 46f;
            ((Player)companion).GetAttackSpeed<RangedDamageClass>() += 1.75f;
            ((Player)companion).GetArmorPenetration<MeleeDamageClass>() += 23f;
            ((Player)companion).GetAttackSpeed<MeleeDamageClass>() += 1.45f;
            ((Player)companion).GetCritChance<MeleeDamageClass>() += 24f;
            ((Player)companion).GetCritChance<RangedDamageClass>() += 32f;
            ref StatModifier damage = ref ((Player)companion).GetDamage<MagicDamageClass>();
		    damage -= 55f;
            ref StatModifier damage1 = ref ((Player)companion).GetDamage<MeleeDamageClass>();
		    damage1 *= 1.8f;
            ref StatModifier damage2 = ref ((Player)companion).GetDamage<RangedDamageClass>();
		    damage2 *= 2.7f;
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
                    HairStyle = 1,
                    SkinVariant = 3,
                    HairColor = new Color(215, 90, 55),
                    EyeColor = new Color(75, 64, 54),
                    SkinColor = new Color(255, 198, 183),
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
                new InitialItemDefinition(97, 1750),
                new InitialItemDefinition(988, 1750),
                new InitialItemDefinition(188, 100),
                new InitialItemDefinition(2269, 1),
                new InitialItemDefinition(3480, 1),
            };
            InitialEquipments[10] = new InitialItemDefinition(3266);
            InitialEquipments[13] = new InitialItemDefinition(4006);
            InitialEquipments[14] = new InitialItemDefinition(4005);
            InitialEquipments[15] = new InitialItemDefinition(984);
            InitialEquipments[11] = new InitialItemDefinition(DoctorJacket.Type);
            InitialEquipments[12] = new InitialItemDefinition(DoctorPants.Type);
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
