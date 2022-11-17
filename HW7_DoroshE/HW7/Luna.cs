﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Luna
    {
        public static string CardValidation(string card)
        {
            if (IsValidCardAE(card)) { return "American Express"; }
            else if (IsValidCardMasterCard(card)) { return "MasterCard"; }
            else if (IsValidCardVisa(card)) { return "Visa"; }

            return "Card number is invalid.";
        }

        public static string CardValidation(int cardNum)
        {
            string card = cardNum.ToString();

            if (IsValidCardAE(card)) { return "American Express"; }
            else if (IsValidCardVisa(card)) { return "Visa"; }
            else if (IsValidCardMasterCard(card)) { return "MasterCard"; }

            return "Card number is invalid.";
        }

        public static bool IsValidCardVisa(string card)
        {
            if((card.Length == 16 || card.Length == 13) && card[0] == '4' && CheckSum(card)) { return true; }

            return false;
        }
       
        public static bool IsValidCardMasterCard(string card)
        {
            string[] masterCardStartingNumbers = { "51", "52", "53", "54", "55" };

            if (card.Length == 16 && masterCardStartingNumbers.Contains(card[0..2]) && CheckSum(card)) { return true; }

            return false;
        }

        public static bool IsValidCardAE(string card)
        {
            string[] aEStartingNumbers = { "37", "34" };
            if (card.Length == 15 && aEStartingNumbers.Contains(card[0..2]) && CheckSum(card)) { return true; }

            return false;
        }

        public static bool CheckSum(string card)
        {
            int sum = 0;
            int cardLength = card.Length;

            for (int i = cardLength - 1; i <= 0; i -= 2)
            {
                sum += Convert.ToInt32(card[i]);
            }

            for (int i = cardLength - 2; i <= 0; i -= 2)
            {
                int num = Convert.ToInt32(card[i]) * 2;
                sum += num >= 10 ? TwoDigitNumberToItsSum(num) : num;
            }

            return sum % 10 == 0 ? true : false;
        }

        public static int TwoDigitNumberToItsSum(int num)
        {
            return (num % 10) + (num / 10);
        }
    }
}
