using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBControll
{
    public class DB
    {
        private NpgsqlCommand command;

        /// <summary>
        /// Если запрос подразумевает собой получение данных из базы, то метод вернет NpgsqlDataReader, иначе вернет код результата.
        /// При возникновении ошибки код результата будет -1
        /// Если запрос содержит параметры, обозначьте их в коде с помощью '$' и номера параметра
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object Query(string sql, object[] parameters = null)
        {
            if (!Connection.IsOpen())
                return null;
            command = new NpgsqlCommand(sql);
            if (sql.ToLower().Contains("select") || sql.ToLower().Contains("returning"))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteReader();
            }
            return command.ExecuteNonQuery();
           
        }
    }
}
