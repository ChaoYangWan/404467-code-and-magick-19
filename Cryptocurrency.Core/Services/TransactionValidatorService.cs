using Cryptocurrency.Blockchain;
using Cryptocurrency.Database.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptocurrency.Services
{
    public static class TransactionValidatorService
    {
        public static void ValidateTransaction(Transaction transaction)
        {
            bool isCoinbase = transaction.Inputs.Count == 0;

            decimal
                totalInput = 0,
                totalOutput = 0;

            // verify the