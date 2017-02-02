using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Models
{
    public class Commit
    {
        /// <summary>
        /// Use to construct a commit from a json array
        /// </summary>
        /// <param name=""></param>
        public Commit(IList<object> values)
        {
            Line = Convert.ToInt32(values[0]);
            Author = (string)values[1];
            Date = Convert.ToDateTime(values[2]);
            Id = (string)values[3];
        }

        public Commit(int line, string author, DateTime date, string id)
        {
            Line = line;
            Author = author;
            Date = date;
            Id = id;
        }

        public int Line{ get; private set; }
        public string Author { get; private set; }
        public DateTime Date { get; private set; }
        public string  Id { get; private set; }
    }
}
