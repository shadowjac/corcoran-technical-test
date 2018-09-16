using Corcoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using Corcoran.DataAccess.Interfaces;
using Corcoran.DataAccess.Infraestructure;

namespace Corcoran.DataAccess.Implementations
{
    public class PresidentsContext : IPresidentsContext
    {
        private readonly List<PresidentModel> _presidents;
        private string _path;

        public PresidentsContext(string dataPath)
        {
            if (string.IsNullOrEmpty(dataPath))
                throw new ArgumentNullException(nameof(dataPath), "Data path cannot be null");
            _presidents = new List<PresidentModel>();
            _path = dataPath;
            LoadData();
        }

        private void LoadData()
        {
            using (TextReader reader = File.OpenText(_path))
            {
                var csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.RegisterClassMap<CsvConfiguration>();

                while (csv.Read())
                {
                    var record = csv.GetRecord<PresidentModel>();
                    _presidents.Add(record);
                }
            }
        }

        public IEnumerable<PresidentModel> GetAll(string order = "ASC")
        {
            if (string.Equals(order, "ASC", StringComparison.InvariantCultureIgnoreCase))
                return _presidents.OrderBy(p => p.Name);
            else if (string.Equals(order, "DESC", StringComparison.InvariantCultureIgnoreCase))
                return _presidents.OrderByDescending(p => p.Name);
            else
                return _presidents.OrderBy(p => p.Name);
        }
    }
}
