using System;
using System.IO;
using System.Linq;

namespace Task06
{
    static class Program
    {
        private static int ticketLength;
        private static int numSystemBase;

        static void Main()
        {
            Console.WriteLine("Please, enter even length of ticket number:");
            ticketLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the base of numeral system " +
                "(amount of unique digits):");
            numSystemBase = Convert.ToInt32(Console.ReadLine());

            using (var sw = new StreamWriter(@"..\\..\\ANSWER.md"))
            {
                sw.WriteLine(CountLuckyTickets());
            }
        }

        private static int CountLuckyTickets()
        {
            var luckyTicketsCounter = 1; // Ticket with all zeroes
            var isLastTicket = false;
            var ticket = new int[ticketLength];
            while (!isLastTicket)
            {
                isLastTicket = GetNextTicket(ref ticket);
                for (var i = 1; i < ticketLength; i++)
                {
                    var leftSum = 0;
                    var rightSum = 0;
                    for (var j = 0; j < i; j++)
                    {
                        leftSum += ticket[j];
                    }
                    for (var j = i; j < ticket.Length; j++)
                    {
                        rightSum += ticket[j];
                    }
                    if (leftSum != rightSum) continue;
                    luckyTicketsCounter++;
                    break;
                }
            }
            return luckyTicketsCounter;
        }

        private static bool GetNextTicket(ref int[] ticket)
        {
            for (var i = ticketLength - 1; i >= 0; i--)
            {
                if (ticket[i] >= numSystemBase - 1) continue;
                ticket[i]++;
                for (var j = i + 1; j < ticketLength; j++)
                {
                    ticket[j] = 0;
                }
                if (ticket.All(d => d == numSystemBase - 1))
                {
                    return true;
                }
                break;
            }
            return false;
        }
    }
}
