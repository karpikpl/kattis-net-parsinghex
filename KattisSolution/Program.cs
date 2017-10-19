using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using KattisSolution.IO;

namespace KattisSolution
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Solve(Console.OpenStandardInput(), Console.OpenStandardOutput());
		}

		public static void Solve(Stream stdin, Stream stdout)
		{
			// IScanner scanner = new OptimizedPositiveIntReader(stdin);
			// uncomment when you need more advanced reader
			// IScanner scanner = new Scanner(stdin);
			IScanner scanner = new LineReader(stdin);
			var writer = new BufferedStdoutWriter(stdout);
			var regex = new Regex("0[xX][\\da-fA-F]+");

			string input = scanner.Next();

			while (input != null)
			{

				var match = regex.Match(input);

				while (match.Success)
				{
					int hex;
					bool parsed = int.TryParse(match.Value.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hex);

					if (parsed)
					{
						writer.Write(match.Value);
						writer.Write(" ");

						writer.Write(hex);
						writer.Write("\n");
					}
					match = match.NextMatch();
				}

				input = scanner.Next();
			}

			writer.Flush();
		}
	}
}