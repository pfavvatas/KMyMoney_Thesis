using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMyMoney_Thesis.Model
{
    class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250 )]
        public string Test1 { get; set; }
    }

    class FileInfo
    {
        [SQLite.NotNull]
        public string Creation_date { get; set; }

        public string Last_Modified_date { get; set; }

        public string Version_id { get; set; }

        public string Fixversion_id { get; set; }
    }


    public class Institution
    {
        //public string Manager { get; set; }

        [Unique][SQLite.NotNull][MaxLength(7)]
        public string Id { get; set; }

        public string Name { get; set; }

        //public string SortCode { get; set; }
    }

    class Account
    {

        [MaxLength(7)][Unique][SQLite.NotNull]
        public string Id { get; set; }

        public string Name { get; set; }

    }
}
