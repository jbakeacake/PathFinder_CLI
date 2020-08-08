using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Pathfinder_CLI.Game.Commands
{
    public static class CommandParser
    {
        public static List<string> ParseInput(string input)
        {
            if(input.Length == 0)
                return null;
            List<string> parameterValues = new List<string>();

            // First split our input on empty spaces -- assume each parameter is separated by a single space
            string[] parts = input.Split(' ');
            bool isQuoteOpen = false;
            string quotedParam = "";
            //Iterate through each string and determine quoted parameters -- convert those to single entries
            for (int i = 0; i < parts.Length; i++)
            {
                if(parts[i].Length == 0) // skip empty strings
                    continue;

                if (isQuoteOpen && !parts[i].Contains('\"'))
                {
                    quotedParam += (parts[i] + " ");
                }
                else if (isQuoteOpen && parts[i].Contains('\"'))
                {
                    // if we have an open quote, and this part contains a quote, then we must be at the closing quote
                    isQuoteOpen = false;
                    quotedParam += parts[i];
                    // remove the quotes from the start and end of this parameter
                    quotedParam = RemoveOpenAndCloseQuotes(quotedParam);
                    parameterValues.Add(quotedParam);
                    quotedParam = "";
                }
                else if(!isQuoteOpen && hasOpenAndCloseQuotes(parts[i]))
                {
                    var parameter = RemoveOpenAndCloseQuotes(parts[i]);
                    parameterValues.Add(parameter);
                }
                else if (!isQuoteOpen && parts[i].Contains('\"'))
                {
                    //begin quoted parameter
                    isQuoteOpen = true;
                    //Start compiling parts to the quoted parameter
                    quotedParam += (parts[i] + " ");
                }
                else
                {
                    parameterValues.Add(parts[i]);
                }
            }

            return parameterValues;
        }
        private static string RemoveOpenAndCloseQuotes(string part)
        {
            return part.Substring(1, part.Length - 2);
        }
        private static bool hasOpenAndCloseQuotes(string part)
        {
            return part[0] == '\"' && part[part.Length-1] == '\"' ? true : false;
        }
    }
}