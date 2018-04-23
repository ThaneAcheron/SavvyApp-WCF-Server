using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Filename: ISavvyService.cs
/// Author:  Craig Turner
/// Created: 2016-06-15
/// Operating System: Windows
/// Version: 10 x64
/// Description: This class is used to exposes severice methods to clients.
/// </summary>

[ServiceContract]
public interface ISavvyService
{
	[OperationContract]
	bool ExecuteCommand(string query);

    [OperationContract]
    List<String> ExecuteQuery(string query);

}
