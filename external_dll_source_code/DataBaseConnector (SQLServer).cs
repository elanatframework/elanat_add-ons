using System.Data;
using System.Data.SqlClient;

namespace Elanat
{
    public class DataBaseConnector : IDisposable
    {
        private SqlConnection con = new SqlConnection(ConnectionString());
        public string ErrorMessage = "";

        /// <param name="command">command = "select * from el_user where user_id=@id" | ParametersName = "@id" | ParametersValue = 1;</param>
        public SqlDataReader GetCommand(string command, List<string> ParametersName = null, List<string> ParametersValue = null)
        {
            try
            {
                var cmd = new SqlCommand(command, con);
                int i = 0;
                if (ParametersName != null)
                    foreach (string element in ParametersName)
                    {
                        cmd.Parameters.AddWithValue(ParametersName[i], ParametersValue[i]);
                        i++;
                    }
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                con.Close();
                ErrorMessage = ex.Message;
                Security.SetLogError(ex);
                return null;
            }
        }

        // Overload
        public SqlDataReader GetCommand(string command, string ParameterName, string ParameterValue)
        {
            try
            {
                var cmd = new SqlCommand(command, con);
                if (ParameterName != null)
                    cmd.Parameters.AddWithValue(ParameterName, ParameterValue);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                con.Close();
                ErrorMessage = ex.Message;
                Security.SetLogError(ex);
                return null;
            }
        }

        /// <param name="command">command = "select * from el_user where user_id=@id" | ParametersName = "@id" | ParametersValue = 1;</param>
        public void SetCommand(string command, List<string> ParametersName = null, List<string> ParametersValue = null)
        {
            try
            {
                var cmd = new SqlCommand(command, con);
                int i = 0;
                if (ParametersName != null)
                    foreach (string element in ParametersName)
                    {
                        cmd.Parameters.AddWithValue(ParametersName[i], ParametersValue[i]);
                        i++;
                    }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                ErrorMessage = ex.Message;
                Security.SetLogError(ex);
            }
        }

        // Overload
        public void SetCommand(string command, string ParameterName, string ParameterValue)
        {
            try
            {
                var cmd = new SqlCommand(command, con);
                if (ParameterName != null)
                    cmd.Parameters.AddWithValue(ParameterName, ParameterValue);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                ErrorMessage = ex.Message;
                Security.SetLogError(ex);
            }
        }

        public SqlDataReader GetProcedure(string ProcedureName, List<string> ParametersName = null, List<string> ParametersValue = null, bool ProcedureRoleAccessCheck = true)
        {
            // If Role Access To Procedure
            Access ac = new Access();
            if (ProcedureRoleAccessCheck)
                if (!ac.ProcedureRoleAccessCheck(ProcedureName))
                    return null;

            try
            {
                var cmd = new SqlCommand(ProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                int i = 0;
                if (ParametersName != null)
                    foreach (string element in ParametersName)
                    {
                        cmd.Parameters.AddWithValue(ParametersName[i], ParametersValue[i]);
                        i++;
                    }
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                con.Close();
                ErrorMessage = ex.Message;

                if (ProcedureRoleAccessCheck)
                    Security.SetLogError(ex);

                return null;
            }
        }

        // Overload
        public SqlDataReader GetProcedure(string ProcedureName, string ParameterName, string ParameterValue, bool ProcedureRoleAccessCheck = true)
        {
            // If Role Access To Procedure
            Access ac = new Access();
            if (ProcedureRoleAccessCheck)
                if (!ac.ProcedureRoleAccessCheck(ProcedureName))
                    return null;

            try
            {
                var cmd = new SqlCommand(ProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                if (ParameterName != null)
                    cmd.Parameters.AddWithValue(ParameterName, ParameterValue);

                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                con.Close();
                ErrorMessage = ex.Message;

                if (ProcedureRoleAccessCheck)
                    Security.SetLogError(ex);

                return null;
            }
        }

        public void SetProcedure(string ProcedureName, List<string> ParametersName = null, List<string> ParametersValue = null, bool ProcedureRoleAccessCheck = true)
        {
            //If Role Access To Procedure
            Access ac = new Access();
            if (ProcedureRoleAccessCheck)
                if (!ac.ProcedureRoleAccessCheck(ProcedureName))
                    return;

            try
            {
                var cmd = new SqlCommand(ProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                int i = 0;
                if (ParametersName != null)
                    foreach (string element in ParametersName)
                    {
                        cmd.Parameters.AddWithValue(ParametersName[i], ParametersValue[i]);
                        i++;
                    }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                ErrorMessage = ex.Message;

                if (ProcedureRoleAccessCheck)
                    Security.SetLogError(ex);
            }
        }

        // Overload
        public void SetProcedure(string ProcedureName, string ParameterName, string ParameterValue, bool ProcedureRoleAccessCheck = true)
        {
            //If Role Access To Procedure
            Access ac = new Access();
            if (ProcedureRoleAccessCheck)
                if (!ac.ProcedureRoleAccessCheck(ProcedureName))
                    return;

            try
            {
                var cmd = new SqlCommand(ProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                if (ParameterName != null)
                    cmd.Parameters.AddWithValue(ParameterName, ParameterValue);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                ErrorMessage = ex.Message;

                if (ProcedureRoleAccessCheck)
                    Security.SetLogError(ex);
            }
        }

        public static string ConnectionString()
        {
            return StaticObject.ConnectionString;
        }

        public void Close()
        {
            con.Close();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                con.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
