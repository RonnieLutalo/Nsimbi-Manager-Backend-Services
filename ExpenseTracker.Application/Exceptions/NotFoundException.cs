using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
        {

        }
    }
}
