using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetSqlQueryTableModel : CodeBehindModel
    {
        public string SqlQueryValue { get; set; }

        public string CommandTableValue { get; set; }

        public void SetValue()
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetCommand(SqlQueryValue);

            XmlDocument FetchDocument = new XmlDocument();
            FetchDocument.Load(StaticObject.ServerMapPath(StaticObject.AdminPath + "/sql_command/template/sql_query_table.xml"));

            string TableBoxTemplate = FetchDocument.SelectSingleNode("template_root/table/table_box").InnerText;
            string TableRowTemplate = FetchDocument.SelectSingleNode("template_root/table/table_row").InnerText;
            string TableCellTemplate = FetchDocument.SelectSingleNode("template_root/table/table_cell").InnerText;
            string SumTableRowTemplate = "";
            string SumTableCellTemplate = "";
            string TmpTableCellTemplate = "";

            do
            {
                SumTableRowTemplate = "";
                SumTableCellTemplate = "";

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    for (int i = 0; i < dbdr.dr.FieldCount; i++)
                    {
                        TmpTableCellTemplate = TableCellTemplate;

                        TmpTableCellTemplate = TmpTableCellTemplate.Replace("$_asp cell;", dbdr.dr.GetName(i));

                        SumTableCellTemplate += TmpTableCellTemplate;
                    }

                SumTableRowTemplate += TableRowTemplate.Replace("$_asp row;", SumTableCellTemplate);

                if (dbdr.dr != null && dbdr.dr.HasRows)
                    while (dbdr.dr.Read())
                    {
                        SumTableCellTemplate = "";

                        for (int i = 0; i < dbdr.dr.FieldCount; i++)
                        {
                            TmpTableCellTemplate = TableCellTemplate;

                            TmpTableCellTemplate = TmpTableCellTemplate.Replace("$_asp cell;", dbdr.dr[dbdr.dr.GetName(i)].ToString().Replace("<", "&lt;").Replace(">", "&gt;"));

                            SumTableCellTemplate += TmpTableCellTemplate;
                        }

                        SumTableRowTemplate += TableRowTemplate.Replace("$_asp row;", SumTableCellTemplate);
                    }

                CommandTableValue += TableBoxTemplate.Replace("$_asp item;", SumTableRowTemplate);
            }
            while (dbdr.dr.NextResult());

            db.Close();

            Write(GlobalClass.AlertAddOnsLanguageVariant("command_has_been_set", StaticObject.GetCurrentAdminGlobalLanguage(), "success", StaticObject.AdminPath + "/sql_command/"));
        }
    }
}
