//--- Aura Script -----------------------------------------------------------
// Ogre Warrior AI
//--- Description -----------------------------------------------------------
// AI for dungeon Ogres.
//---------------------------------------------------------------------------

[AiScript("ogrewarrior")]
public class OgreWarriorAi : AiScript
{
	public OgreWarriorAi()
	{
		SetVisualField(950, 120);
		SetAggroRadius(400);

		Hates("/pc/", "/pet/");

		On(AiState.Aggro, AiEvent.Hit, OnHit);
		On(AiState.Aggro, AiEvent.KnockDown, OnKnockDown);
		On(AiState.Aggro, AiEvent.DefenseHit, OnDefenseHit);
	}

	protected override IEnumerable Alert()
	{
		Do(Say("Make sure no one leaves alive!", "Ha ha", "I dare you come this far.", "You cowards...", "Come on, you vulgar bastards!", "", "", ""));

		if (Random() < 60)
			Do(Wander(300, 500, Random() < 60));

		Do(Wait(2000, 7000));
	}

	protected override IEnumerable Aggro()
	{
		SwitchRandom();
		if (Case(40))
		{
			Do(Say("Attack!", "How much can you take?", "Hahaha", "Just wait till I smash you to bits.", "", "", ""));
			Do(PrepareSkill(SkillId.Stomp));
			Do(Wait(500, 2000));
			Do(UseSkill());
			Do(Wait(1500));
		}
		else if (Case(30))
		{
			Do(Say("Here I come!", "You there!", "", "", ""));

			if (Random() < 80)
			{
				Do(Circle(400, 2000, 2000, false));
			}
			else
			{
				Do(Wander(400, 400, false));
				Do(Wait(1000));
			}

			Do(Attack(3));
		}
		else if (Case(20))
		{
			Do(Say("Wait!", "Ha ha ha", "Here I come!", "", "", ""));
			Do(Attack(3));
		}
		else if (Case(10))
		{
			Do(Say("Grrr... Grrr...", "", "", ""));
			Do(PrepareSkill(SkillId.Defense));

			SwitchRandom();
			if (Case(80))
			{
				Do(Circle(400, 5000, 5000));
			}
			else if (Case(10))
			{
				Do(Wander(400, 400));
				Do(Wait(1000));
			}
			else if (Case(10))
			{
				Do(Follow(600, true, 5000));
			}

			Do(CancelSkill());
		}
	}

	private IEnumerable OnHit()
	{
		Do(Say("Stand still!", "Yap!", "Grrr...", "Ugh!", "Argh!!", "Huk!", "", "", ""));
		Do(Attack(3, 4000));
	}

	private IEnumerable OnKnockDown()
	{
		Do(Say("Here I come!", "Wait!", "", "", ""));

		SwitchRandom();
		if (Case(50))
		{
			Do(Attack(3, 4000));
		}
		else if (Case(40))
		{
			Do(PrepareSkill(SkillId.Defense));
			Do(Wait(2000, 3000));
			Do(CancelSkill());
		}
		else if (Case(10))
		{
			Do(PrepareSkill(SkillId.Smash));
			Do(Attack(1, 4000));
		}
	}

	private IEnumerable OnDefenseHit()
	{
		Do(Attack(3));
		Do(Wait(1000, 3000));
	}
}
