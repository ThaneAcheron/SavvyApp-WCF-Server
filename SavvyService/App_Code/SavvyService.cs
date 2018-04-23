using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Filename: SavvyService.cs
/// Author:  Craig Turner
/// Created: 2016-06-15
/// Operating System: Windows
/// Version: 10 x64
/// Description: This class is used to implement the Services
/// </summary>

public class SavvyService : ISavvyService
{

    UseDataBase usedb = new UseDataBase(); //Database Reference

    public bool ExecuteCommand(string query)
    {
        //Open a connection to the database 
        usedb.ConnectDataBase();
        //Execute the command 
        bool result = usedb.ExecuteCommand(query);
        usedb.Close();
        //return the result 
        return result; 
    }

    public List<string> ExecuteQuery(string query)
    {
        //Open a connection to the database
        usedb.ConnectDataBase();
        //Execute the query
        SqlDataReader DataReader = usedb.ExecuteQuery(query);

        //Create a list to store the values
        List<string> dataResults = new List<String>();

        //Read the data and store them in a list
        while (DataReader.Read())
        {
            for (int i = 0; i <= DataReader.FieldCount - 1; i = i + 1)
            {
                dataResults.Add(DataReader.GetValue(i).ToString());
            }

        }

        usedb.Close();
        //Return the datalist 
        return dataResults;
    }
}
