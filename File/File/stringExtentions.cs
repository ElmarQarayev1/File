using System;
namespace File
{
	public static class stringExtentions
	{
        public static bool CheckFullname(this string fullname)
        {

            string[] namesArr = fullname.Split(' ');

            if (namesArr.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (String.IsNullOrWhiteSpace(namesArr[i]) || !CheckIsLetter(namesArr[i]) || namesArr[i].Length < 3)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static bool CheckIsLetter(this string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i])) return false;

            }
            return true;

        }
       
    }
}

