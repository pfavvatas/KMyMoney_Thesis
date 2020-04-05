using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

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

    //Tags
    [Table("Tags")]
    public class Tag
    {
        public string tagcolor { get; set; }
        public string notes { get; set; }
        public string id { get; set; }
        public string closed { get; set; }
        public string name { get; set; }

    }
    //Tags end

    //Institution tag
    [Table("Institutions")]
    public class Institution
    {
        //Institution
        [Unique][SQLite.NotNull][MaxLength(7)]
        public string Id { get; set; }

        public string Name { get; set; }

        //public string SortCode { get; set; }

        //public string Manager { get; set; }

        ////Address
        //public string Street { get; set; }

        //public string Telephone { get; set; }

        //public string City { get; set; }

        //public string Zip { get; set; }

        //AccountsIds
        [OneToMany]
        public List<AccountId> AccountIds { get; set; }
    }

    //AccountsIds
    [Table("AccountIds")]
    public class AccountId
    {
        public string Id { get; set; }
        
        [ForeignKey(typeof(Institution))]
        public int InstitutionId { get; set; }
    }

    //Address tag
    public class Address
    {
        public string Street { get; set; }

        public string Telephone { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string Zipcode { get; set; }


    }

    class Account
    {

        [MaxLength(7)][Unique][SQLite.NotNull]
        public string Id { get; set; }

        public string Name { get; set; }

    }
}
