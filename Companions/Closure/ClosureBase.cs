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
    public class ClosureBase : TerrarianBase
    {
	public override string Name => "Closure";
	public override string Description => "Closure has a mischievous personality and enjoys making jokes and pulling pranks. She appears to be rather lazy and prefers to delegate tasks to others instead of handling them herself. However, without her, R.I. would be incapable of functioning.";
	public override int Age => 21;
	public override Genders Gender => Genders.Female;
    public override float AccuracyPercent => 0.85f;
    public override float MaxRunSpeed => 4.6f;
    public override float RunAcceleration => 0.22f;
    public override float RunDeceleration => 0.37f;
    public override int JumpHeight => 15;
    public override float JumpSpeed => 5.45f;
    public override bool CanUseHeavyItem => true;
	public override int InitialMaxHealth => 250;
	public override int InitialMaxMana => 250;
	public override int HealthPerLifeCrystal => 20;
	public override int HealthPerLifeFruit => 10;        
    public override BehaviorBase DefaultFollowLeaderBehavior => (BehaviorBase)(object)new ClosureFollowLeaderBehavior();
    protected override CompanionDialogueContainer GetDialogueContainer => new Docter.ClosureDialogues(); //I have split the companion dialogues to another file. Here, you initialize the object containing companion dialogues.
        public override void UpdateAttributes(Companion companion) //This updates whenever the companion status are reset. If you want to change their status, or give them other benefits, here is the place.
        {
            companion.DodgeRate += 45f;
            companion.BlockRate += 25f;
            companion.DefenseRate += 25f;
            ((Player)companion).aggro = ((Player)companion).aggro + 250;
            ((Player)companion).luck = ((Player)companion).luck + 500f;
		    ((Player)companion).lifeRegen = ((Player)companion).lifeRegen + 45;
            ((Player)companion).GetArmorPenetration<RangedDamageClass>() += 35f;
            ((Player)companion).GetAttackSpeed<RangedDamageClass>() += 1.25f;
            ((Player)companion).GetArmorPenetration<MeleeDamageClass>() += 35f;
            ((Player)companion).GetAttackSpeed<MeleeDamageClass>() += 1.25f;
            ((Player)companion).GetCritChance<MeleeDamageClass>() += 25f;
            ((Player)companion).GetCritChance<RangedDamageClass>() += 25f;
            ((Player)companion).GetCritChance<MagicDamageClass>() += 25f;
            ((Player)companion).GetArmorPenetration<MagicDamageClass>() += 35f;
            ((Player)companion).GetAttackSpeed<MagicDamageClass>() += 1.25f;
            ref StatModifier damage = ref ((Player)companion).GetDamage<MagicDamageClass>();
		    damage *= 2f;
            ref StatModifier damage1 = ref ((Player)companion).GetDamage<MeleeDamageClass>();
		    damage1 *= 2f;
            ref StatModifier damage2 = ref ((Player)companion).GetDamage<RangedDamageClass>();
		    damage2 *= 2f;
            ref StatModifier damage3 = ref ((Player)companion).GetDamage<SummonDamageClass>();
		    damage3 *= 2f;
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
                    HairStyle = 51,
                    SkinVariant = 6,
                    HairColor = new Color(255, 255, 255),
                    EyeColor = new Color(39, 147, 30),
                    SkinColor = new Color(255, 223, 214),
                    ShirtColor = new Color(255, 255, 255),
                    UndershirtColor = new Color(255, 255, 255),
                    PantsColor = new Color(66, 66, 66),
                    ShoesColor = new Color(38, 240, 255)
                };
            }
        }

        
        public override void InitialInventory(out InitialItemDefinition[] InitialInventoryItems, ref InitialItemDefinition[] InitialEquipments)
	    {
		if (ModLoader.TryGetMod("ArknightsMod", out Mod ArknightsMod))
        {
            InitialInventoryItems = new InitialItemDefinition[]
            {
                new InitialItemDefinition(188, 100),
            };
            InitialEquipments[10] = new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.Closurehat>());
            InitialEquipments[11] = new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.ClosureJacket>());
            InitialEquipments[12] = new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.ClosurePants>());
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
