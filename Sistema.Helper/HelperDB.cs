using System;
using System.Data;
using System.Collections.Generic;

namespace Sistema.Helper
{
    public static class HelperDB
    {
        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
        public static DateTime MinValue()
        {
            return new DateTime(1900, 01, 01, 00, 00, 00);
        }
        public static DataTable GetColumnsTable(Object _object)
        {
            var table = new DataTable(_object.GetType().Name);

            var columns = _object.GetType().GetFields();

            foreach (var column in columns)
                table.Columns.Add(new DataColumn(column.Name));

            return table;
        }
        public static void GetObjectRowTable(DataTable table, Object _object)
        {
            var fields = _object.GetType().GetFields();

            DataRow registro = table.NewRow();

            foreach (var field in fields)
                registro[field.Name] = field.GetValue(_object).ToString();

            table.Rows.Add(registro);
        }
        public static DataSet GetDataSet(List<Object> lista, Object _object)
        {
            var _dataset = new DataSet();
            var tabela = HelperDB.GetColumnsTable(_object);

            foreach (var obj in lista)
                HelperDB.GetObjectRowTable(tabela, obj);

            _dataset.Tables.Add(tabela);
            return _dataset;            
        }
    }
}
