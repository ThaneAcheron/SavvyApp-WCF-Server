using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Filename: UseDatBase.cs
/// Author:  Craig Turner
/// Created: 2016-06-15
/// Operating System: Windows
/// Version: 10 x64
/// Description: This class is used to establish a connection to the database, methods include writing, gathering and counting results from the database.
/// </summary>
public class UseDataBase
{
    SqlConnection sqlConn;

    //Open a Connection to the database
    public void ConnectDataBase()
    {
        //Use the connectionstring stored in the web.config
        sqlConn = new SqlConnection("Data Source=THANEACHERON;Initial Catalog=SavvyDatabase;Integrated Security=True");
        sqlConn.Open();
    }

    //Close the Connection to the database
    public void Close()
    {
        sqlConn.Close();
    }

    //Method to execute a query with no result 
    public bool ExecuteCommand(String query)
    {
        try
        {
            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            //Indicate Success
            return true;
        }
        catch (SqlException)
        {
            //Indicate Failure
            return false;
        }

    }

    //Method used to return a value (if any) 
    public SqlDataReader ExecuteQuery(string query)
    {
        try
        {
            //Establish a connection 
            SqlCommand cmd = sqlConn.CreateCommand();
            //Apply the query
            cmd.CommandText = query;
            //Execute the reader
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Return the reader
            return dataReader;
        }
        catch (SqlException)
        {
            //No results found return null DataSet
            return null;
        }
    }
}