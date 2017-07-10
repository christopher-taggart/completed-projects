using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class TaxRepository : ITaxInfoRepository
    {
        private string _tFileName;

        public TaxRepository(string tFileName)
        {
            _tFileName = tFileName;
        }


        public List<TaxInfo> GetAllTaxInfos()
        {
            List<TaxInfo> taxes = new List<TaxInfo>();
            using (StreamReader sr = new StreamReader(_tFileName))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    TaxInfo t = new TaxInfo();
                    string[] fields = line.Split(',');
                    t.StateAbbrevation = fields[0];
                    t.StateName = fields[1];
                    t.TaxRate = decimal.Parse(fields[2]);
                    taxes.Add(t);
                }
                return taxes;
            }
        }

        public TaxInfo GetTaxInfoByState(string state)
        {
            TaxInfo t = null;
            List<TaxInfo> taxes = GetAllTaxInfos();
            foreach (var tax in taxes)
            {
                if (state.ToUpper() == tax.StateAbbrevation || state.ToUpper() == tax.StateName.ToUpper())
                {
                    t = tax;
                }
            }
            return t;
        }
    }
}
