using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HelpDeskServices.AdoConnection
{
    public class SqlParamDefinition
    {
        public SqlParamDefinition(string name, object value)
        {
            this.Name = name;
            //this.DbType = dbType;
            this.Value = value;
        }

        public string Name { get; }
        //public SqlDbType DbType { get; }

        public object Value { get; }
    }
}