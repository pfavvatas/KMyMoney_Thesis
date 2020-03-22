using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace KMyMoney_Thesis.DataStorage
{


		[XmlRoot(ElementName = "CREATION_DATE")]
		public class CREATION_DATE
		{
			[XmlAttribute(AttributeName = "date")]
			public string Date { get; set; }
		}

		[XmlRoot(ElementName = "LAST_MODIFIED_DATE")]
		public class LAST_MODIFIED_DATE
		{
			[XmlAttribute(AttributeName = "date")]
			public string Date { get; set; }
		}

		[XmlRoot(ElementName = "VERSION")]
		public class VERSION
		{
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
		}

		[XmlRoot(ElementName = "FIXVERSION")]
		public class FIXVERSION
		{
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
		}

		[XmlRoot(ElementName = "FILEINFO")]
		public class FILEINFO
		{
			[XmlElement(ElementName = "CREATION_DATE")]
			public CREATION_DATE CREATION_DATE { get; set; }
			[XmlElement(ElementName = "LAST_MODIFIED_DATE")]
			public LAST_MODIFIED_DATE LAST_MODIFIED_DATE { get; set; }
			[XmlElement(ElementName = "VERSION")]
			public VERSION VERSION { get; set; }
			[XmlElement(ElementName = "FIXVERSION")]
			public FIXVERSION FIXVERSION { get; set; }
		}

		[XmlRoot(ElementName = "ADDRESS")]
		public class ADDRESS
		{
			[XmlAttribute(AttributeName = "street")]
			public string Street { get; set; }
			[XmlAttribute(AttributeName = "telephone")]
			public string Telephone { get; set; }
			[XmlAttribute(AttributeName = "county")]
			public string County { get; set; }
			[XmlAttribute(AttributeName = "city")]
			public string City { get; set; }
			[XmlAttribute(AttributeName = "zipcode")]
			public string Zipcode { get; set; }
			[XmlAttribute(AttributeName = "zip")]
			public string Zip { get; set; }
			[XmlAttribute(AttributeName = "postcode")]
			public string Postcode { get; set; }
			[XmlAttribute(AttributeName = "state")]
			public string State { get; set; }
		}

		[XmlRoot(ElementName = "USER")]
		public class USER
		{
			[XmlElement(ElementName = "ADDRESS")]
			public ADDRESS ADDRESS { get; set; }
			[XmlAttribute(AttributeName = "email")]
			public string Email { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "ACCOUNTID")]
		public class ACCOUNTID
		{
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
		}

		[XmlRoot(ElementName = "ACCOUNTIDS")]
		public class ACCOUNTIDS
		{
			[XmlElement(ElementName = "ACCOUNTID")]
			public List<ACCOUNTID> ACCOUNTID { get; set; }
		}

		[XmlRoot(ElementName = "PAIR")]
		public class PAIR
		{
			[XmlAttribute(AttributeName = "key")]
			public string Key { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "KEYVALUEPAIRS")]
		public class KEYVALUEPAIRS
		{
			[XmlElement(ElementName = "PAIR")]
			public List<PAIR> PAIR { get; set; }
		}

		[XmlRoot(ElementName = "INSTITUTION")]
		public class INSTITUTION
		{
			[XmlElement(ElementName = "ADDRESS")]
			public ADDRESS ADDRESS { get; set; }
			[XmlElement(ElementName = "ACCOUNTIDS")]
			public ACCOUNTIDS ACCOUNTIDS { get; set; }
			[XmlElement(ElementName = "KEYVALUEPAIRS")]
			public KEYVALUEPAIRS KEYVALUEPAIRS { get; set; }
			[XmlAttribute(AttributeName = "manager")]
			public string Manager { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "sortcode")]
			public string Sortcode { get; set; }
		}

		[XmlRoot(ElementName = "INSTITUTIONS")]
		public class INSTITUTIONS
		{
			[XmlElement(ElementName = "INSTITUTION")]
			public List<INSTITUTION> INSTITUTION { get; set; }
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "PAYEE")]
		public class PAYEE
		{
			[XmlElement(ElementName = "ADDRESS")]
			public ADDRESS ADDRESS { get; set; }
			[XmlAttribute(AttributeName = "matchingenabled")]
			public string Matchingenabled { get; set; }
			[XmlAttribute(AttributeName = "email")]
			public string Email { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "reference")]
			public string Reference { get; set; }
		}

		[XmlRoot(ElementName = "PAYEES")]
		public class PAYEES
		{
			[XmlElement(ElementName = "PAYEE")]
			public List<PAYEE> PAYEE { get; set; }
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "TAG")]
		public class TAG
		{
			[XmlAttribute(AttributeName = "tagcolor")]
			public string Tagcolor { get; set; }
			[XmlAttribute(AttributeName = "notes")]
			public string Notes { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "closed")]
			public string Closed { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "TAGS")]
		public class TAGS
		{
			[XmlElement(ElementName = "TAG")]
			public TAG TAG { get; set; }
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "SUBACCOUNT")]
		public class SUBACCOUNT
		{
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
		}

		[XmlRoot(ElementName = "SUBACCOUNTS")]
		public class SUBACCOUNTS
		{
			[XmlElement(ElementName = "SUBACCOUNT")]
			public List<SUBACCOUNT> SUBACCOUNT { get; set; }
		}

		[XmlRoot(ElementName = "ACCOUNT")]
		public class ACCOUNT
		{
			[XmlElement(ElementName = "SUBACCOUNTS")]
			public SUBACCOUNTS SUBACCOUNTS { get; set; }
			[XmlElement(ElementName = "KEYVALUEPAIRS")]
			public KEYVALUEPAIRS KEYVALUEPAIRS { get; set; }
			[XmlAttribute(AttributeName = "currency")]
			public string Currency { get; set; }
			[XmlAttribute(AttributeName = "description")]
			public string Description { get; set; }
			[XmlAttribute(AttributeName = "parentaccount")]
			public string Parentaccount { get; set; }
			[XmlAttribute(AttributeName = "opened")]
			public string Opened { get; set; }
			[XmlAttribute(AttributeName = "number")]
			public string Number { get; set; }
			[XmlAttribute(AttributeName = "lastmodified")]
			public string Lastmodified { get; set; }
			[XmlAttribute(AttributeName = "type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "lastreconciled")]
			public string Lastreconciled { get; set; }
			[XmlAttribute(AttributeName = "institution")]
			public string Institution { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "ACCOUNTS")]
		public class ACCOUNTS
		{
			[XmlElement(ElementName = "ACCOUNT")]
			public List<ACCOUNT> ACCOUNT { get; set; }
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "SPLIT")]
		public class SPLIT
		{
			[XmlAttribute(AttributeName = "payee")]
			public string Payee { get; set; }
			[XmlAttribute(AttributeName = "reconcileflag")]
			public string Reconcileflag { get; set; }
			[XmlAttribute(AttributeName = "shares")]
			public string Shares { get; set; }
			[XmlAttribute(AttributeName = "reconciledate")]
			public string Reconciledate { get; set; }
			[XmlAttribute(AttributeName = "action")]
			public string Action { get; set; }
			[XmlAttribute(AttributeName = "bankid")]
			public string Bankid { get; set; }
			[XmlAttribute(AttributeName = "account")]
			public string Account { get; set; }
			[XmlAttribute(AttributeName = "number")]
			public string Number { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "memo")]
			public string Memo { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlElement(ElementName = "TAG")]
			public TAG TAG { get; set; }
		}

		[XmlRoot(ElementName = "SPLITS")]
		public class SPLITS
		{
			[XmlElement(ElementName = "SPLIT")]
			public List<SPLIT> SPLIT { get; set; }
		}

		[XmlRoot(ElementName = "TRANSACTION")]
		public class TRANSACTION
		{
			[XmlElement(ElementName = "SPLITS")]
			public SPLITS SPLITS { get; set; }
			[XmlAttribute(AttributeName = "postdate")]
			public string Postdate { get; set; }
			[XmlAttribute(AttributeName = "commodity")]
			public string Commodity { get; set; }
			[XmlAttribute(AttributeName = "memo")]
			public string Memo { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "entrydate")]
			public string Entrydate { get; set; }
		}

		[XmlRoot(ElementName = "TRANSACTIONS")]
		public class TRANSACTIONS
		{
			[XmlElement(ElementName = "TRANSACTION")]
			public List<TRANSACTION> TRANSACTION { get; set; }
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "SCHEDULED_TX")]
		public class SCHEDULED_TX
		{
			[XmlElement(ElementName = "PAYMENTS")]
			public string PAYMENTS { get; set; }
			[XmlElement(ElementName = "TRANSACTION")]
			public TRANSACTION TRANSACTION { get; set; }
			[XmlAttribute(AttributeName = "paymentType")]
			public string PaymentType { get; set; }
			[XmlAttribute(AttributeName = "autoEnter")]
			public string AutoEnter { get; set; }
			[XmlAttribute(AttributeName = "occurenceMultiplier")]
			public string OccurenceMultiplier { get; set; }
			[XmlAttribute(AttributeName = "startDate")]
			public string StartDate { get; set; }
			[XmlAttribute(AttributeName = "lastDayInMonth")]
			public string LastDayInMonth { get; set; }
			[XmlAttribute(AttributeName = "lastPayment")]
			public string LastPayment { get; set; }
			[XmlAttribute(AttributeName = "occurence")]
			public string Occurence { get; set; }
			[XmlAttribute(AttributeName = "weekendOption")]
			public string WeekendOption { get; set; }
			[XmlAttribute(AttributeName = "type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "endDate")]
			public string EndDate { get; set; }
			[XmlAttribute(AttributeName = "fixed")]
			public string Fixed { get; set; }
		}

		[XmlRoot(ElementName = "SCHEDULES")]
		public class SCHEDULES
		{
			[XmlElement(ElementName = "SCHEDULED_TX")]
			public SCHEDULED_TX SCHEDULED_TX { get; set; }
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "SECURITIES")]
		public class SECURITIES
		{
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "CURRENCY")]
		public class CURRENCY
		{
			[XmlAttribute(AttributeName = "saf")]
			public string Saf { get; set; }
			[XmlAttribute(AttributeName = "symbol")]
			public string Symbol { get; set; }
			[XmlAttribute(AttributeName = "type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "ppu")]
			public string Ppu { get; set; }
			[XmlAttribute(AttributeName = "scf")]
			public string Scf { get; set; }
		}

		[XmlRoot(ElementName = "CURRENCIES")]
		public class CURRENCIES
		{
			[XmlElement(ElementName = "CURRENCY")]
			public List<CURRENCY> CURRENCY { get; set; }
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "PRICE")]
		public class PRICE
		{
			[XmlAttribute(AttributeName = "price")]
			public string Price { get; set; }
			[XmlAttribute(AttributeName = "source")]
			public string Source { get; set; }
			[XmlAttribute(AttributeName = "date")]
			public string Date { get; set; }
		}

		[XmlRoot(ElementName = "PRICEPAIR")]
		public class PRICEPAIR
		{
			[XmlElement(ElementName = "PRICE")]
			public PRICE PRICE { get; set; }
			[XmlAttribute(AttributeName = "from")]
			public string From { get; set; }
			[XmlAttribute(AttributeName = "to")]
			public string To { get; set; }
		}

		[XmlRoot(ElementName = "PRICES")]
		public class PRICES
		{
			[XmlElement(ElementName = "PRICEPAIR")]
			public List<PRICEPAIR> PRICEPAIR { get; set; }
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "REPORTS")]
		public class REPORTS
		{
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "BUDGETS")]
		public class BUDGETS
		{
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "ONLINEJOBS")]
		public class ONLINEJOBS
		{
			[XmlAttribute(AttributeName = "count")]
			public string Count { get; set; }
		}

		[XmlRoot(ElementName = "KMYMONEY-FILE")]
		public class KMYMONEYFILE
		{
			[XmlElement(ElementName = "FILEINFO")]
			public FILEINFO FILEINFO { get; set; }
			[XmlElement(ElementName = "USER")]
			public USER USER { get; set; }
			[XmlElement(ElementName = "INSTITUTIONS")]
			public INSTITUTIONS INSTITUTIONS { get; set; }
			[XmlElement(ElementName = "PAYEES")]
			public PAYEES PAYEES { get; set; }
			[XmlElement(ElementName = "TAGS")]
			public TAGS TAGS { get; set; }
			[XmlElement(ElementName = "ACCOUNTS")]
			public ACCOUNTS ACCOUNTS { get; set; }
			[XmlElement(ElementName = "TRANSACTIONS")]
			public TRANSACTIONS TRANSACTIONS { get; set; }
			[XmlElement(ElementName = "KEYVALUEPAIRS")]
			public KEYVALUEPAIRS KEYVALUEPAIRS { get; set; }
			[XmlElement(ElementName = "SCHEDULES")]
			public SCHEDULES SCHEDULES { get; set; }
			[XmlElement(ElementName = "SECURITIES")]
			public SECURITIES SECURITIES { get; set; }
			[XmlElement(ElementName = "CURRENCIES")]
			public CURRENCIES CURRENCIES { get; set; }
			[XmlElement(ElementName = "PRICES")]
			public PRICES PRICES { get; set; }
			[XmlElement(ElementName = "REPORTS")]
			public REPORTS REPORTS { get; set; }
			[XmlElement(ElementName = "BUDGETS")]
			public BUDGETS BUDGETS { get; set; }
			[XmlElement(ElementName = "ONLINEJOBS")]
			public ONLINEJOBS ONLINEJOBS { get; set; }
		}

	

}
