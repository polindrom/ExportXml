using System.Collections.Generic;

namespace ExportData.Models
{
    public class Data
    {
        private List<User> _data;

        public Data()
        {
            DataInitializer();
        }

        public List<User> DataList
        {
            get
            {
                return _data;
            }
        }

        private void DataInitializer()
        {
            _data = new List<User>
            {
                new User
                {
                    Age = 5, Name = "Nick", LastName = "Shone"
                },

                new User
                {
                    Age = 8, Name = "Liza", LastName = "Volkvich"
                }
            };
        }


    }
}