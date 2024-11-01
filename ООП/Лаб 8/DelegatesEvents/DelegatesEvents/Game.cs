using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{

	public delegate void AttackHero(string hero, int damage);
	public delegate void HealHero(string hero, int heal);
	public delegate void HoldHero(string hero);

	public class Game
	{
		public string HeroesName;
		public int HeroesHP;

	
		public event AttackHero? Attacked;
		public event HealHero? Healed;
		public event HoldHero? Remained;

		public Game() 
		{
			HeroesName = "Player1";
			HeroesHP = 1000;
		}
		public Game(string name, int HP)
		{

			HeroesName = name;
			HeroesHP = HP;
		}

		public void AttackHero(string hero, int damage)
		{
			if (damage < 0)
			{
				throw new ArgumentOutOfRangeException("Урон не может быть отрицателен");
			}
			else if (damage > 0)
			{
				Attacked?.Invoke(hero, damage);
				HeroesHP -= damage;
			}

			else
			{
				Remains(hero);
			}

		}

		public void HealHero(string hero, int HP)
		{
			if (HP < 0)
			{
				throw new ArgumentOutOfRangeException("Урон не может быть отрицателен");
			}
			else if (HP > 0)
			{
				Healed?.Invoke(hero, HP);
				HeroesHP += HP;
			}

			else
			{
				Remains(hero);
			}
		}

		public void Remains(string hero)
		{
			Remained?.Invoke(hero);
		}

		public void ShowHP() => Console.WriteLine($"Текущее значение HP:{this.HeroesHP}");
	}
}
