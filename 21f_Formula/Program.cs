using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21f_Formula
{
	class Formula
	{
		List<Formula> gyerekei;
		string muvelet;

		public Formula(string muvelet, List<Formula> gyerekei)
		{
			this.muvelet = muvelet;
			this.gyerekei = gyerekei;
		}

		public Formula(string muvelet)
		{
			this.muvelet = muvelet;
			this.gyerekei = new List<Formula>();
		}

		public static Formula operator +(Formula x, Formula y) => new Formula("+", new List<Formula> { x, y });
		public static Formula operator -(Formula x, Formula y) => new Formula("-", new List<Formula> { x, y });
		public static Formula operator -(Formula x) => new Formula("-", new List<Formula> {x});
		public static Formula operator *(Formula x, Formula y) => new Formula("*", new List<Formula> { x, y });
		public static Formula operator /(Formula x, Formula y) => new Formula("/", new List<Formula> { x, y });

		public string Diagnosztika()
		{
			throw new NotImplementedException(); // ide majd jön egy graphviz stringgé alakítás
		}

		public int Levelszam()
		{
			if (gyerekei.Count==0)
				return 1;
			int s = 0;
			foreach (Formula gyerek in gyerekei)
			{
				s += gyerek.Levelszam();
			}
			return s;
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Formula hetes = new Formula("7");
			Formula a = new Formula("a");
			Formula b = new Formula("b");
			Formula ketto = new Formula("2");
			//Formula ketszer_be = new Formula("*", new List<Formula> { ketto, b }); // így lehetne ezt kézzel, manuálisan
			Formula f = (a+(ketto * b)*hetes)-(ketto*(-a)-b);
            Console.WriteLine(f.Levelszam());
		}
	}
}
