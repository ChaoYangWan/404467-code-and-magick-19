﻿using Cryptocurrency.Blockchain;
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

            // verify the inputs are able to be spent with the public key the transaction is signed with
            for (int i = 0; i < transaction.Inputs.Count; i++)
            {
                TransactionInput txIn = transaction.Inputs[i];

                Transaction lastTxInTrans = TransactionFactory.TransactionFromTxInput(txIn);
                Trans