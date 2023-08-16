using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.SignalR;

namespace ReceptBank.ApplicationLager;
public class Recept
{
 public int ReceptId {get; set;}
 public string Name {get; set;}
 public string Ingredients {get; set;}
}