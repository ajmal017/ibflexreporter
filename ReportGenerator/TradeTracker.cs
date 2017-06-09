﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class TradeTracker
    {
        FlexQueryResponseFlexStatementsFlexStatementTrade[] trades;
        public TradeTracker(FlexQueryResponseFlexStatementsFlexStatementTrade[] trades)
        {
            this.trades = trades;
        }

        public decimal getCommisionBySymbol(string symbol)
        {
            decimal commision = 0;
            foreach(FlexQueryResponseFlexStatementsFlexStatementTrade trade in trades)
            {
                if (trade.symbol == symbol)
                    commision += trade.ibCommission;
            }
            return commision;
        }

        public decimal getCommisionByOptionSymbol(string symbol)
        {
            decimal commision = 0;
            foreach (FlexQueryResponseFlexStatementsFlexStatementTrade trade in trades)
            {
                if (trade.underlyingSymbol == symbol)
                    commision += trade.ibCommission;
            }
            return commision;
        }

        public string[] getSymbols()
        {
            HashSet<string> symbols = new HashSet<string>();
            foreach (FlexQueryResponseFlexStatementsFlexStatementTrade trade in trades)
            {
                if(trade.putCall == "")
                    symbols.Add(trade.symbol);
            }
            return symbols.ToArray();
        }
        public string[] getOptionSymbols()
        {
            HashSet<string> symbols = new HashSet<string>();
            foreach (FlexQueryResponseFlexStatementsFlexStatementTrade trade in trades)
            {
                symbols.Add(trade.underlyingSymbol);
            }
            symbols.Remove("");
            return symbols.ToArray();
        }
    }
}
