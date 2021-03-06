﻿using BlackbirdCs.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackbirdCs
{
    internal class Parameters
    {
        public bool DemoMode { get; set; }
        public string Leg1 { get; set; }
        public string Leg2 { get; set; }
        public bool UseFullExposure { get; set; }
        public uint TestedExposure { get; set; }
        public uint MaxExposure { get; set; }
        public uint MaxLength { get; set; }
        public uint DebugMaxOperation { get; set; }
        public bool Verbose { get; set; }
        public string CACert { get; set; }
        public uint Interval { get; set; }
        public decimal SpreadEntry { get; set; }
        public decimal SpreadTarget { get; set; }
        public decimal PriceDeltaLimit { get; set; }
        public decimal TrailingSpreadLim { get; set; }
        public int TrailingSpreadCount { get; set; }
        public int OrderBookFactor { get; set; }
        public bool UseVolatility { get; set; }
        public int VolatilityPeriod { get; set; }
        public bool SendEmail { get; set; }
        public string SenderAddress { get; set; }
        public string SenderUsername { get; set; }
        public string SenderPassword { get; set; }
        public string SmtpServerAddress { get; set; }
        public string ReceiverAddress { get; set; }

        public List<ExchangeConfig> ExchangesConfig { get; set; }
        
        public decimal PriceDeltaLim { get; set; }
        public decimal TrailingLim { get; set; }
        public uint TrailingCount { get; set; }
        
        private Parameters()
        {
        }

        public static Parameters CreateParametersFromJsonFile(string jsonFileName)
        {
            if (!File.Exists(jsonFileName))
            {
                throw new FileNotFoundException("Configuration file not found!", jsonFileName);
            }

            var parameters = new Parameters();

            using (JsonTextReader reader = new JsonTextReader(File.OpenText(jsonFileName)))
            {
                var serializer = new JsonSerializer();
                parameters = serializer.Deserialize<Parameters>(reader);
            }

            return parameters;
        }
    }
}
