using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorCore
{
    public class GuidAccountGenerator : INumberGenerator
    {
        public string GenerateAccountNumber()
        {
            string firstPart = Guid.NewGuid().ToString();
            string secondPart = DateTime.Now.ToString();

            StringBuilder result = new StringBuilder();
            for(int i = 0; i < firstPart.Length; i++)
            {
                if (i < secondPart.Length)
                {
                    result.Append(firstPart[i]);
                    result.Append(secondPart[i]);
                }
                else
                {
                    break;
                }
            }

            return result.ToString().ToUpperInvariant().Replace(' ', '.').Replace(':', '.').Replace('-', '.').Replace("..", ".");
        }
    }
}
