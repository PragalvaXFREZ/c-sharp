using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankCustomer_1318.Models;

// Maps to the "customer" table in the bank database.
[Table("customer")]
public class Customer
{
    // The user enters the account number, so the database must not generate it.
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("account_no")]
    public int AccountNo { get; set; }

    [Column("name")]
    public string Name { get; set; } = "";

    [Column("address")]
    public string Address { get; set; } = "";

    [Column("balance")]
    public decimal Balance { get; set; }
}
