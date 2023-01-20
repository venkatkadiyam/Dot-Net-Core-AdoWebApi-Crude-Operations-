using System.Data;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlDataAdapter = Microsoft.Data.SqlClient.SqlDataAdapter;
using WebApplication1.models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Azure.Core;

namespace WebApplication1.models
{
    public class EmplistImplementation:Iinterface
    {
        private IConfiguration Configuration;
        public string connectionStrong;
        public EmplistImplementation(IConfiguration configuration1)
        {
            this.Configuration = configuration1;
            connectionStrong = configuration1["ConnectionStrings:DataConnect"];
        }
        [HttpGet]
        public IEnumerable<Emplistclass> getall()
        {
            List<Emplistclass> list = new List<Emplistclass>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrong))
                {
                    SqlCommand cmd = new SqlCommand("sp_emplist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    dataAdapter.Fill(ds);
                    foreach (DataRow dr in ds.Rows)
                    {
                        list.Add(new Emplistclass
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = dr["Name"].ToString(),
                            Designation = dr["Designation"].ToString(),
                            Salary = Convert.ToInt32(dr["Salary"]),
                        });                      
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        [HttpPost]
        public Emplistclass Postdata(Emplistclass emplistclass )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrong))
                {

                    con.Open();
                    // SqlCommand cmd = new SqlCommand("insert into EmpList(Name,Designation,Salary) values('"+emplistclass.Name+"','"+emplistclass.Designation+"','"+emplistclass.Salary+"')", con);
                    SqlCommand cmd = new SqlCommand("EmplistInsert1", con);
                    cmd.CommandType = CommandType.StoredProcedure;               
                    cmd.Parameters.AddWithValue("@Ename", emplistclass.Name);
                    cmd.Parameters.AddWithValue("@Dsgn", emplistclass.Designation);
                    cmd.Parameters.AddWithValue("@salary", Convert.ToInt16(emplistclass.Salary));
                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int i = cmd.ExecuteNonQuery();
                    string? getid = cmd.Parameters["@id"].Value.ToString();
                    emplistclass.Id = Convert.ToInt32(getid);
                    if (i == 0)
                    {
                        return emplistclass;
                    }
                  

                }
                return emplistclass;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            
           return emplistclass;

        }
        [HttpPut]
        [Route("UpdateEmployees/{id}")]
        public Emplistclass Updatedata(Emplistclass emplistclass1,int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrong))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateEmplist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", emplistclass1.Name);
                    cmd.Parameters.AddWithValue("@desg", emplistclass1.Designation);
                    cmd.Parameters.AddWithValue("@sly", Convert.ToInt32(emplistclass1.Salary));              
                    int i = cmd.ExecuteNonQuery();
                    string? getid = cmd.Parameters["@id"].Value.ToString();
                    emplistclass1.Id = Convert.ToInt32(getid);
                    //if (i == 0)
                    //{
                    //    return emplistclass1;
                    //}
                }
                return emplistclass1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return emplistclass1;
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public Emplistclass deletdata(Emplistclass emplistclass5 ,int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrong))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Deleteemplist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    int i = cmd.ExecuteNonQuery();
                    string? getid = cmd.Parameters["@id"].Value.ToString();
                    emplistclass5.Id = Convert.ToInt32(getid);
                }     
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return emplistclass5;
        }
    }

   



}
