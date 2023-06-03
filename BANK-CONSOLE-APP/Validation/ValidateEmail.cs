using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP.Validation
{
     internal class ValidateEmail
     {
          public string ValidEmailCollector()
          {
              while (true)
              {
                  Console.Write("Enter Email Address: ");
                  string email = Console.ReadLine()!;

                  if (!IsValidEmail(email))
                  {
                      Console.WriteLine("Invalid Email, please enter  a valid email address");
                      continue;
                  }
                  return email;
              }
          }
          public bool IsValidEmail(string email)
          {
                 return Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@(gmail\.com|yahoo\.com|outlook\.com)$");
          }
     }
}
