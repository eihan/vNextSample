using System;
using MongoDB.Bson;


namespace WebApplication.Models
{
	public class TweetModel
	{
		public BsonObjectId Id {get;set;}
		public string author {get;set;}
		public string body {get;set;}
		public string twid {get;set;}
		public bool active {get;set;}
		
		public string avatar {get;set;}
		
		public DateTime date {get;set;}
		
		public string screenname {get;set;}
		public int __v{get;set;}
	}
}

