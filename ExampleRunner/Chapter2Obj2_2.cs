using System;
using System.Collections.Generic;
using System.Dynamic;
using ConsoleDump;

namespace ExampleRunner
{
    /// <summary>
    /// implement an implicit and explicit conversion operator
    /// </summary>
    public class Example2_24 : Example
    {
        public class Money
        {
            public Money(decimal amount)
            {
                Amount = amount;
            }

            public decimal Amount { get; set; }

            public static implicit operator decimal(Money money)
            {
                return money.Amount;
            }

            public static explicit operator int(Money money)
            {
                return (int)money.Amount;
            }
        }

        public override void Run()
        {
            Money m = new Money(42.42M);
            decimal amount = m;
            int truncatedAmount = (int)m;

            amount.Dump();
            truncatedAmount.Dump();
        }
    }

    /// <summary>
    /// Exporting some data to Excel
    /// </summary>
    public class Example2_28 : Example
    {
        public static void DisplayInExcel(IEnumerable<dynamic> entities)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            excelApp.Workbooks.Add();

            dynamic workSheet = excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = "Header A";
            workSheet.Cells[1, "B"] = "Header B";

            var row = 1;
            foreach (var entity in entities)
            {
                row++;
                workSheet.Cells[row, "A"] = entity.ColumnA;
                workSheet.Cells[row, "B"] = entity.ColumnB;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
        }


        public override void Run()
        {
            var entities = new List<dynamic>
            {
                new {ColumnA = 1, ColumnB = "Foo"},
                new {ColumnA = 2, ColumnB = "Bar"},
            };

            DisplayInExcel(entities);
        }
    }

    /// <summary>
    /// Creating a custom DynamicObject
    /// </summary>
    public class Example2_29 : Example
    {
        public class SampleObject : DynamicObject
        {
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = binder.Name;
                return true;
            }
        }

        public override void Run()
        {
            dynamic obj = new SampleObject();
            Console.WriteLine(obj.SomeProperty);
        }
    }
}