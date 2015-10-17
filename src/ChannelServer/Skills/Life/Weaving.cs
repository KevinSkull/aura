﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Aura.Channel.Skills.Base;
using Aura.Channel.World.Entities;
using Aura.Data.Database;
using Aura.Mabi.Const;

namespace Aura.Channel.Skills.Life
{
	/// <summary>
	/// Handles Weaving production skill.
	/// </summary>
	/// <remarks>
	/// Weaving handles usage of looms and spinning wheels.
	/// 
	/// Var20: Success Rate?
	/// </remarks>
	[Skill(SkillId.Weaving)]
	public class Weaving : ProductionSkill
	{
		protected override bool RequiresProp { get { return true; } }

		protected override bool CheckCategory(Creature creature, ProductionCategory category)
		{
			return (category == ProductionCategory.Spinning || category == ProductionCategory.Weaving);
		}

		protected override void SkillTraining(Creature creature, Skill skill, ProductionData data, bool success)
		{
			if (skill.Info.Rank == SkillRank.Novice)
			{
				skill.Train(1); // Use the skill.
				if (success)
					skill.Train(2); // Use the skill successfully.
				return;
			}

			if (!success)
				return;

			if (skill.Info.Rank >= SkillRank.RF && skill.Info.Rank <= SkillRank.RD)
			{
				if (data.ItemData.HasTag("/yarn/01/"))
					skill.Train(1); // Successfully make Thick Thread.
				else if (data.ItemData.HasTag("/yarn/02/"))
					skill.Train(2); // Successfully make Thin Thread.
				else if (data.ItemData.HasTag("/texture/04/"))
					skill.Train(3); // Successfully make Finest Fabric.
				else if (data.ItemData.HasTag("/texture/03/"))
					skill.Train(4); // Successfully make Fine Fabric.
				else if (data.ItemData.HasTag("/texture/02/"))
					skill.Train(5); // Successfully make Common Fabric.
				else if (data.ItemData.HasTag("/texture/01/"))
					skill.Train(6); // Successfully make Cheap Fabric.
				else if (data.ItemData.HasTag("/silk/01/"))
					skill.Train(7); // Successfully make Cheap Silk.

				else if (skill.Info.Rank >= SkillRank.RE && data.ItemData.HasTag("/leather_strap/01/"))
					skill.Train(8); // Successfully make Cheap Leather Strap.

				return;
			}

			if (skill.Info.Rank == SkillRank.RC)
			{
				if (data.ItemData.HasTag("/yarn/02/"))
					skill.Train(1); // Successfully make Thin Thread.
				return;
			}

			if (skill.Info.Rank >= SkillRank.RB && skill.Info.Rank <= SkillRank.RA)
			{
				if (data.ItemData.HasTag("/yarn/02/"))
					skill.Train(1); // Successfully make Thin Thread.
				else if (data.ItemData.HasTag("/texture/04/"))
					skill.Train(2); // Successfully make Finest Fabric.
				else if (data.ItemData.HasTag("/texture/03/"))
					skill.Train(3); // Successfully make Fine Fabric.
				else if (data.ItemData.HasTag("/texture/02/"))
					skill.Train(4); // Successfully make Common Fabric.
				else if (data.ItemData.HasTag("/silk/01/"))
					skill.Train(5); // Successfully make Cheap Silk.
				else if (data.ItemData.HasTag("/leather_strap/01/"))
					skill.Train(6); // Successfully make Cheap Leather Strap.

				return;
			}

			if (skill.Info.Rank == SkillRank.R9)
			{
				if (data.ItemData.HasTag("/yarn/03/"))
					skill.Train(1); // Successfully make a Braid.
				else if (data.ItemData.HasTag("/texture/04/"))
					skill.Train(2); // Successfully make Finest Fabric.
				else if (data.ItemData.HasTag("/texture/03/"))
					skill.Train(3); // Successfully make Fine Fabric.
				else if (data.ItemData.HasTag("/silk/04/"))
					skill.Train(4); // Successfully make Finest Silk.
				else if (data.ItemData.HasTag("/silk/03/"))
					skill.Train(5); // Successfully make Fine Silk.
				else if (data.ItemData.HasTag("/silk/02/"))
					skill.Train(6); // Successfully make Common Silk.
				else if (data.ItemData.HasTag("/leather_strap/01/"))
					skill.Train(7); // Successfully make Cheap Leather Strap.

				return;
			}

			if (skill.Info.Rank == SkillRank.R8)
			{
				if (data.ItemData.HasTag("/silk/04/"))
					skill.Train(1); // Successfully make Finest Silk.
				else if (data.ItemData.HasTag("/silk/03/"))
					return;
			}

			if (skill.Info.Rank == SkillRank.R7)
			{
				if (data.ItemData.HasTag("/yarn/03/"))
					skill.Train(1); // Successfully make a Braid.
				else if (data.ItemData.HasTag("/texture/04/"))
					skill.Train(2); // Successfully make Finest Fabric.
				else if (data.ItemData.HasTag("/texture/03/"))
					skill.Train(3); // Successfully make Fine Fabric.
				else if (data.ItemData.HasTag("/silk/04/"))
					skill.Train(4); // Successfully make Finest Silk.
				else if (data.ItemData.HasTag("/silk/03/"))
					skill.Train(5); // Successfully make Fine Silk.
				else if (data.ItemData.HasTag("/leather_strap/02/"))
					skill.Train(7); // Successfully make Common Leather Strap.

				return;
			}

			if (skill.Info.Rank == SkillRank.R6)
			{
				if (data.ItemData.HasTag("/texture/04/"))
					skill.Train(2); // Successfully make Finest Fabric.
				else if (data.ItemData.HasTag("/texture/03/"))
					skill.Train(3); // Successfully make Fine Fabric.
				else if (data.ItemData.HasTag("/silk/04/"))
					skill.Train(4); // Successfully make Finest Silk.
				else if (data.ItemData.HasTag("/silk/03/"))
					skill.Train(5); // Successfully make Fine Silk.
				else if (data.ItemData.HasTag("/leather_strap/03/"))
					skill.Train(7); // Successfully make Fine Leather Strap.
				else if (data.ItemData.HasTag("/leather_strap/02/"))
					skill.Train(7); // Successfully make Common Leather Strap.

				return;
			}

			if (skill.Info.Rank == SkillRank.R5)
			{
				if (data.ItemData.HasTag("/toughband/"))
					skill.Train(1); // Successfully make a Tough String.
				else if (data.ItemData.HasTag("/texture/04/"))
					skill.Train(2); // Successfully make Finest Fabric.
				else if (data.ItemData.HasTag("/texture/03/"))
					skill.Train(3); // Successfully make Fine Fabric.
				else if (data.ItemData.HasTag("/silk/04/"))
					skill.Train(4); // Successfully make Finest Silk.
				else if (data.ItemData.HasTag("/silk/03/"))
					skill.Train(5); // Successfully make Fine Silk.
				else if (data.ItemData.HasTag("/leather_strap/03/"))
					skill.Train(6); // Successfully make Fine Leather Strap.

				return;
			}

			if (skill.Info.Rank == SkillRank.R4)
			{
				if (data.ItemData.HasTag("/toughband/"))
					skill.Train(1); // Successfully make a Tough String.
				else if (data.ItemData.HasTag("/toughyarn/"))
					skill.Train(2); // Successfully make Tough Thread.

				return;
			}

			if (skill.Info.Rank >= SkillRank.R3 && skill.Info.Rank <= SkillRank.R2)
			{
				if (data.ItemData.HasTag("/toughyarn/"))
					skill.Train(1); // Successfully make Tough Thread.
				else if (data.ItemData.HasTag("/texture/04/"))
					skill.Train(2); // Successfully make Finest Fabric.
				else if (data.ItemData.HasTag("/silk/04/"))
					skill.Train(3); // Successfully make Finest Silk.
				else if (data.ItemData.HasTag("/leather_strap/04/"))
					skill.Train(4); // Successfully make Finest Leather Strap.

				return;
			}

			if (skill.Info.Rank == SkillRank.R1)
			{
				if (data.ItemData.HasTag("/toughyarn/"))
					skill.Train(1); // Successfully make Tough Thread.
				else if (data.ItemData.HasTag("/toughband/"))
					skill.Train(1); // Successfully make a Tough String.
				else if (data.ItemData.HasTag("/texture/04/"))
					skill.Train(2); // Successfully make Finest Fabric.
				else if (data.ItemData.HasTag("/silk/04/"))
					skill.Train(3); // Successfully make Finest Silk.
				else if (data.ItemData.HasTag("/leather_strap/04/"))
					skill.Train(4); // Successfully make Finest Leather Strap.

				return;
			}
		}
	}
}
