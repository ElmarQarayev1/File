using System;
namespace File
{
    [Serializable]
	public class Person
	{
		public string Fullname { get; set; }
		public int Age { get; set; }

        public override string ToString()
        {
            return $"{Fullname}-{Age}";
        }
    }	
}

