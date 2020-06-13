using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QuizCreator
{
 class connection
    {
        public static MySqlConnection con = null;
            public void constring()
        {
            con = new MySqlConnection("server=localhost;port=3306;username=pong;password=quiz123;database=quiz");
        }
    }
}
