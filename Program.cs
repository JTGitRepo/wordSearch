using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchAgain;
            string newSentance;
            string sentenceSegment;
            string keyword;
            char firstLetterOfKeyword;
            int index;
            bool keywordFound;
            string originalSentence;
            string sentence;

            do
            {
                originalSentence = retrieveSentence();    

                do
                {
                    keywordFound = false;
                    sentence = originalSentence;
                    try
                    {
                        keyword = retrieveKeyword();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        keyword = retrieveKeyword();
                    }

                    do
                    {
                        try
                        {
                            firstLetterOfKeyword = getFirstLetterOfKeyword(keyword);
                            index = getIndexOfKeywordFirstLetterInSentence(sentence, firstLetterOfKeyword);
                            sentenceSegment = sentence.Substring(index, keyword.Length);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            break;
                        }

                        if (sentenceSegment == keyword)
                        {
                            keywordFound = true;
                        }
                        else
                        {
                            try
                            {
                                sentence = sentence.Substring(index);
                                sentence = sentence.Substring(1);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                break;
                            }
                        }

                    } while (keywordFound == false);


                    if (keywordFound == true)
                    {
                        Console.WriteLine("Keyword: {0} was found in your sentance.", keyword);
                    }
                    else
                    {
                        Console.WriteLine("Keyword: {0} was NOT found in your sentance.", keyword);
                    }

                    Console.WriteLine("Would you like to search for another word?(y/n)");
                    searchAgain = Console.ReadLine();
                    Console.Clear();
                } while (searchAgain == "y" || searchAgain == "Y");
                Console.WriteLine("Would you like to submit a new text to search?(y/n)");
                newSentance = Console.ReadLine();
                Console.Clear();
            } while (newSentance == "y" || newSentance == "Y");
                


   // method difinitions



             // gets and returns sentence to be searched from input 
            string retrieveSentence()
            {
                string sent;
                Console.WriteLine("Please enter a searchable sentance.");
                return sent = Console.ReadLine();
            }

            // gets and returns keyword to be searched
            string retrieveKeyword()
            {
                string key;
                do
                {
                    Console.WriteLine("Please enter a searchable keyword.");
                    key = Console.ReadLine();
                } while (key == "");
                return key;
            }

            // takes keyword as argument and returns first letter of type "char".
            char getFirstLetterOfKeyword(string key)
            {
                    return key[0];

            }

            // takes sentence and first letter of keyword as arguments and returns 
            // the index of the first letter of the keyword in the sentence
            int getIndexOfKeywordFirstLetterInSentence(string sent, char firstLetter)
            {
                return index = sent.IndexOf(firstLetter);
            }
        }
    }
}

