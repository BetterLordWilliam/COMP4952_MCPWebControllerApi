using System;
using System.ComponentModel;
using ModelContextProtocol.Server;

namespace MCPWebControllerApi.McpTool;

[McpServerToolType]
public sealed class EchoTool {
  public EchoTool() { }
  
  [McpServerTool, Description("Says Hello to a user")]
  public static string Echo(string username) {
    return "Hello " + username;
  }
}
